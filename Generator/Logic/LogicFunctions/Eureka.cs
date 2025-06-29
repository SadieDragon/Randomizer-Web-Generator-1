// // TODO: Name better? I just need to get this out
// public static bool CheckRules(
//     List<Func<bool>> glitchlessRules = null,
//     List<Func<bool>> glitchedRules = null,
//     List<Func<bool>> nicheRules = null,
//     List<Func<bool>> difficultCombatRules = null
// )
// {
//     // This is only temporary; replace niche once its setting is added
//     bool isGlitched = SharedSettings.logicRules == LogicRules.Glitched;

//     // Create a table of the logic flags and their rulesets
//     Dictionary<bool, List<Func<bool>>> ruleGroups = new()
//     {
//         { true, CreateBlankRuleList(glitchlessRules) },
//         { isGlitched, CreateBlankRuleList(glitchedRules) },
//         { isGlitched, CreateBlankRuleList(nicheRules) }, // Change once niche is implemented
//         { false, CreateBlankRuleList(difficultCombatRules) }, // Change once difficult combat is implemented
//     };

//     // The key is the flag for "Is this glitched?" for ex,
//     // the val is a list of rules to check for if a check is in logic
//     foreach (var (flag, rules) in ruleGroups)
//     {
//         // Check first if the flag is true. if so, then check if any rules
//         //  are satisfied. Return true if so. Else, continue to search the
//         //  rulesets.
//         if (flag && rules.Any(rule => rule()))
//         {
//             return true;
//         }
//     }
//     return false; // This check is not in logic.
// }

// private static List<Func<bool>> CreateBlankRuleList(List<Func<bool>> listOfRules)
// {
//     // Use a blank list if none provided
//     listOfRules ??= new List<Func<bool>>();
//     return listOfRules;
// }
