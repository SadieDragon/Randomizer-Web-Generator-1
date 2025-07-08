using System;
using System.Reflection;

// using Core = LogicFunctionsNS.CoreLogic;
// using DifficultCombat = LogicFunctionsNS.DifficultCombatLogic;
// using Glitched = LogicFunctionsNS.GlitchedLogic;
// using Glitchless = LogicFunctionsNS.GlitchlessLogic;
// using Niche = LogicFunctionsNS.NicheLogic;

namespace LogicFunctionsNS
{
    public class LogicAggregator
    {
        // Update this, and the imports, as new logic settings are added.
        private static readonly string[] logicSettings =
        [
            "Glitchless",
            "Glitched",
            "Niche",
            "DifficultCombat",
        ];

        /// <summary>
        /// Takes the supplied namespace, class, and function, and combines them into a function.
        /// Then evaluate said function. Assumes it will get a bool back.
        /// </summary>
        /// <param name="typeName">`Glitched.class`, for example.</param>
        /// <param name="functionName">The function to evaluate.</param>
        /// <returns>The boolean result of the function.</returns>
        private static bool EvaluateFunction(string typeName, string functionName)
        {
            // Get the type
            Type type = Type.GetType(typeName);

            // If it is missing, then *assume* that it is not defined because it
            //   has no unique logic.
            if (type == null)
            {
                // This is a debug line that can be commented out when not writing logic.
                Console.WriteLine(
                    $"Unable to find {typeName} while aggregating logic, assumed true."
                );

                return true;
            }

            // Get the function
            MethodInfo method = type.GetMethod(functionName);

            // If it is missing (null), then the function does not have unique logic for
            //   that setting. Return true as a stand in.
            if (method == null)
            {
                return true;
            }

            // Evaluate the expression.
            object result = method.Invoke(null, null);

            // Any non boolean result is a mistake, and should be caught and fixed immediately.
            if (result is not bool)
            {
                Console.WriteLine($"logic function {functionName} returned non-bool {result}.");
                Environment.Exit(1);
            }

            // Return the result, known to be a boolean.
            return (bool)result;
        }

        public static bool AggregateFunction(string className, string functionName)
        {
            // Wrapper for evaluating the function.
            bool Evaluate(string nsName)
            {
                return EvaluateFunction($"{nsName}.{className}", functionName);
            }

            // Try to evaluate the core. If false, then the action cannot be done anyway. Return early.
            if (!Evaluate("Core"))
            {
                return false;
            }

            // Go through each logic setting, and see if the action can be done in any of them.
            foreach (string ns in logicSettings)
            {
                // Break early if ever true.
                if (Evaluate(ns))
                {
                    return true;
                }
            }

            // Default of false.
            return false;
        }
    }
}
