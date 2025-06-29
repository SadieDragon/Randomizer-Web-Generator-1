using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

#nullable enable
namespace TPRandomizer
{
    // Expression         := <Boolean> { <BooleanOperator> <Boolean> } ...
    // Boolean            := <BooleanConstant> | <ItemOrFunction> | <ProgressiveItem> | <Room> | <Setting> | "(" <Expression> ")"
    // BooleanOperator    := "and" | "or"
    // BooleanConstant    := "true" | "false"
    // ItemOrFunction     := <Name>
    // Room               := Room.<Name>
    // Setting            := "(" <Name> { "equals" | "not_equal" } <Value> ")"
    // ProgressiveItem    := "(" <Name> "," <Count> ")"

    /// <summary>
    /// Base class for logic parse tree nodes.
    /// </summary>
    public abstract class LogicAST
    {
        public abstract bool Evaluate();
    }

    namespace AST
    {
        public class True : LogicAST
        {
            public override bool Evaluate() => true;
        }

        public class False : LogicAST
        {
            public override bool Evaluate() => false;
        }

        public class Function : LogicAST
        {
            string FunctionName { get; }

            public Function(string function) => FunctionName = function;

            public override bool Evaluate()
            {
                MethodInfo? method = typeof(LogicFunctions).GetMethod(FunctionName);
                if (method == null)
                {
                    Console.WriteLine($"unknown logic function {FunctionName}");
                    return false;
                }

                object? result = method.Invoke(null, null);
                if (result is bool resultBool)
                {
                    return resultBool;
                }
                else
                {
                    Console.WriteLine($"logic function {FunctionName} returned non-bool {result}");
                    return false;
                }
            }
        }

        public class Item : LogicAST
        {
            TPRandomizer.Item ItemId { get; }
            int Count { get; }

            public Item(TPRandomizer.Item item, int count) => (ItemId, Count) = (item, count);

            public override bool Evaluate()
            {
                int heldCount = LogicFunctions.getItemCount(ItemId);
                // Console.WriteLine($"Item.Evaluate {heldCount} {Count} {ItemId}");
                return heldCount >= Count;
            }
        }

        public class Room : LogicAST
        {
            string RoomName { get; }

            public Room(string room) => RoomName = room;

            public override bool Evaluate() =>
                Randomizer.Rooms.RoomDict[RoomName].ReachedByPlaythrough;
        }

        public class Setting : LogicAST
        {
            string SettingName { get; }
            string SettingValue { get; }
            bool Sense { get; }

            public Setting(string setting, string value, bool sense) =>
                (SettingName, SettingValue, Sense) = (setting, value, sense);

            public override bool Evaluate() =>
                LogicFunctions.EvaluateSetting(SettingName, SettingValue) == Sense;
        }

        public class Conjunction : LogicAST
        {
            LogicAST Left { get; }
            LogicAST Right { get; }

            public Conjunction(LogicAST left, LogicAST right) => (Left, Right) = (left, right);

            public override bool Evaluate() => Left.Evaluate() && Right.Evaluate();
        }

        public class Disjunction : LogicAST
        {
            LogicAST Left { get; }
            LogicAST Right { get; }

            public Disjunction(LogicAST left, LogicAST right) => (Left, Right) = (left, right);

            public override bool Evaluate() => Left.Evaluate() || Right.Evaluate();
        }
    }

    public class Parser
    {
        // (Sword, 3) or (Progressive_Item, 10); returns Groups[1] "Sword" Groups[2] 3
        static Regex progressiveItemRegex = new(@"^\((\w+\s*),\s*(\d+)\)");

        // (Setting.Difficulty equals Hard); returns Groups[1] "Difficulty" Groups[2] "Hard"
        static Regex settingRegex = new(@"^\(Setting.(\w+)\s+equals\s+(\w+)\)");

        // same as above but for "not_equals"
        static Regex settingInverseRegex = new(@"^\(Setting.(\w+)\s+not_equal\s+(\w+)\)");

        // Room.Kak; returns Groups[1] "Kak"
        static Regex roomRegex = new(@"^Room.(\w+)");

        // "true" at the beginning
        static Regex trueRegex = new(@"^true");

        // "false" at the beginning
        static Regex falseRegex = new(@"^false");

        // CanFly; Groups[1] "CanFly"
        static Regex itemOrFunctionRegex = new(@"^(\w+)");

        // and ___; see the if branch for exs
        static Regex conjunctionRegex = new(@"^and\s+");

        // or ___; see the if branch for exs
        static Regex disjunctionRegex = new(@"^or\s+");

        static Dictionary<string, LogicAST> parseCache = [];

        /// <summary>
        /// Parses logic expressions into AST objects. This function uses an internal parse cache,
        /// but it's still better to cache the returned AST yourself if possible.
        /// </summary>
        /// <param name="expression">Logic expression as text.</param>
        /// <returns>Logic expression as an AST object.</returns>
        public static LogicAST Parse(string expression)
        {
            if (parseCache.TryGetValue(expression, out LogicAST? value))
            {
                return value;
            }

            string exprClone = expression;
            LogicAST parsed;
            try
            {
                parsed = ParseInner(ref exprClone, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to parse logic expression {expression}: {e}");
                throw;
            }

            parseCache[expression] = parsed;
            return parsed;
        }

        // this function does the actual work, because taking `ref string` on a public method
        // would be a little weird. internally, though, it's easier (and likely faster) to keep
        // one reference to expression and substring it as we consume characters.
        //
        // you could also do this with a pointer that gets passed to Match but it's more boilerplate
        static LogicAST ParseInner(ref string expression, int depth)
        {
            LogicAST? tree = null;

            while (expression.Length > 0)
            {
                expression = expression.Trim();
                var notRefExpression = expression; // So local fn's can use this
                Match? matchedExpression = null;
                LogicAST thisNode;

                // Helper fns for checking if a regex is matched
                bool TryMatch(Regex regexExpression, bool updateMatchedExpression = false)
                {
                    Match? matchedExpression = Re(regexExpression, ref notRefExpression);

                    return matchedExpression != null;
                }

                // Helper fns for getting the values off of index 1 and 2
                string GetIndexValue(int index)
                {
                    return matchedExpression?.Groups[index].Value ?? "";
                }

                if (TryMatch(progressiveItemRegex, true))
                {
                    thisNode = new AST.Item(
                        Enum.Parse<Item>(GetIndexValue(1)),
                        int.Parse(GetIndexValue(2))
                    );
                }
                else if (TryMatch(settingRegex, true))
                {
                    thisNode = new AST.Setting(GetIndexValue(1), GetIndexValue(2), true);
                }
                else if (TryMatch(settingInverseRegex, true))
                {
                    thisNode = new AST.Setting(GetIndexValue(1), GetIndexValue(2), false);
                }
                else if (TryMatch(roomRegex, true))
                {
                    thisNode = new AST.Room(GetIndexValue(1).Replace('_', ' '));
                }
                else if (expression.StartsWith('('))
                {
                    // Start of a subexpression. We know it's not a progressive item check because
                    // we looked for that earlier.
                    expression = expression[1..];
                    thisNode = ParseInner(ref expression, depth + 1);
                    // skip the final )
                    if (expression.Length == 0 || expression[0] != ')')
                    {
                        throw new Exception("Expected closing parenthesis");
                    }
                    expression = expression[1..];
                }
                else if (TryMatch(trueRegex))
                {
                    thisNode = new AST.True();
                }
                else if (TryMatch(falseRegex))
                {
                    thisNode = new AST.False();
                }
                else if (TryMatch(conjunctionRegex))
                {
                    thisNode = new AST.Conjunction(tree!, ParseInner(ref expression, depth));
                }
                else if (TryMatch(disjunctionRegex))
                {
                    thisNode = new AST.Disjunction(tree!, ParseInner(ref expression, depth));
                }
                else if (TryMatch(itemOrFunctionRegex, true))
                {
                    if (Enum.TryParse(GetIndexValue(1), out Item item))
                    {
                        thisNode = new AST.Item(item, 1);
                    }
                    else
                    {
                        thisNode = new AST.Function(GetIndexValue(1));
                    }
                }
                else if (expression.StartsWith(')'))
                {
                    // If not already in a subexpression, then something has gone wrong
                    if (depth == 0)
                    {
                        throw new Exception("Unexpected closing parenthesis");
                    }

                    // Assuming within a subexpression, let the caller handle advancing the read pointer
                    break;
                }
                else
                {
                    Console.WriteLine(
                        $"failed to parse remainder of logic expression: {expression}"
                    );
                    expression = "";
                    thisNode = new AST.False();
                }

                tree = thisNode;
            }

            return tree!;
        }

        // helper function to match and advance or return null for comparison chains
        static Match? Re(Regex source, ref string expression)
        {
            Match m = source.Match(expression);
            if (m.Success)
            {
                expression = expression[m.Length..];
                return m;
            }
            else
            {
                return null;
            }
        }
    }
}
