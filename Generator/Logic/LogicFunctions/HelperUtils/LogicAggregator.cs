using System;
using System.Reflection;

/// Lupa's rough explanation of hacked together implementation:
///   I noticed when refactoring that most functions could be defined:
///     `CoreLogic && (GlitchlessLogic || GlitchedLogic || NicheLogic || DifficultCombatLogic)`
///   So I cobbled this together to more easily combine the separate files back into one function,
///    as they were before I started this project.
///   `logicSettings` is for the different categories of logic.
///     - While `Niche` and `DifficultCombat` were not yet options you could select, they were coded for,
///       and were included.
///     - If you add any settings that have their own categorization of logic, make a new file for each
///       category (`CategoryLogic` is the subdir), and then add the tag to the list. Use the pre-existing
///       categories for an example.
///   `EvaluateFunction` takes the namespace, and then evaluates the function from the namespace.
///     - `LogicFunctionsNS.GlitchedLogic.CanDefeatBoss` is `namepsace`, `CanDefeatStallord` is a
///       function.
///     - If the namespace is missing, then it assumes that it was not defined because there is no unique
///       logic. This can be changed to a "break" later if desired, but it currently defaults "true"
///     - Like the Tokenizer, this expects that any functions going through have no parameters and always
///       have return type bool. It will break if it catches anything that doesn't follow this.
///   `AggregateFunction` does the `Core && (Glitched || Glitchless || Niche || DifficultCombat)`.
///     - Helper wrapper fn for the eval of a function across the categories.
///     - If the core is false, `false && x` will always return `false`, return false.
///     - If any of the settings eval to `true`, `true || x` will always return `true`, return true.
///     - Otherwise, the expression evaluated to `false`.
namespace LogicFunctionsNS
{
    public class LogicAggregator
    {
        // Update this as logic settings are added.
        // Note that "Logic" doesn't need to be appended, as it is appended in the aggregate fn.
        private static readonly string[] logicSettings =
        [
            "Glitchless",
            "Glitched",
            "Niche",
            "DifficultCombat",
        ];

        /// <summary>
        /// Evaluate given function from given file. Assumes it will get a bool back.
        /// </summary>
        /// <param name="typeName">`Glitched.class`, for example.</param>
        /// <param name="functionName">The function to evaluate.</param>
        /// <returns>The boolean result of the function.</returns>
        private static bool EvaluateFunction(string typeName, string functionName)
        {
            // Tell the program "Hey, you'll be calling from `type`"
            // ex: "Hey, you'll be calling from `LogicFunctionsNS.CoreLogic.CanDefeatBoss`"
            Type type = Type.GetType(typeName);

            // If it is missing, then *assume* that it is not defined because it
            //   has no unique logic. The default case here is "true".
            if (type == null)
            {
                // This is a debug line that can be commented out when not writing logic.
                Console.WriteLine(
                    $"Unable to find {typeName} while aggregating logic, assumed true."
                );

                return true;
            }

            // Get the function to be run.
            MethodInfo method = type.GetMethod(functionName);

            // If it is missing (null), then the function does not have unique logic for
            //   that setting. Return the default case.
            if (method == null)
            {
                return true;
            }

            // Call the function.
            object result = method.Invoke(null, null);

            // Any non boolean result is assumed a mistake that should be caught and fixed immediately.
            if (result is not bool)
            {
                Console.WriteLine($"logic function {functionName} returned non-bool {result}.");
                Environment.Exit(1);
            }

            // Return the result, known to be a boolean.
            return (bool)result;
        }

        // Core && (Glitchless || Glitched || Niche || DifficultCombat)
        public static bool AggregateFunction(string className, string functionName)
        {
            // Wrapper for evaluating the function.
            bool Evaluate(string nsName)
            {
                return EvaluateFunction(
                    $"LogicFunctionsNS.{nsName}Logic.{className}",
                    functionName
                );
            }

            // Try to evaluate the core.
            // If the core is false, `false && x` will always return `false`, so short circuit.
            if (!Evaluate("Core"))
            {
                return false;
            }

            // Go through each logic setting, and see if the action can be done in any of them.
            // If any of the settings eval to `true`, `true || x` will always return `true`, so short circuit.
            // TODO: Given `logicSettings` is a list, this could probably use `Any` to be more readable?
            // TODO: separate function
            foreach (string ns in logicSettings)
            {
                // Break early if ever true.
                if (Evaluate(ns))
                {
                    return true;
                }
            }

            // If no settings returned `true`, then the result is `false`.
            return false;
        }
    }
}
