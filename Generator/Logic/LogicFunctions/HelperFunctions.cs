using System;
using System.Collections.Generic;
using System.Linq;
using TPRandomizer;
using TPRandomizer.SSettings.Enums;
using CUU = LogicFunctionsNS.CanUseUtilities;
using HHSL = LogicFunctionsNS.HasHiddenSkillLevel;
using LF = TPRandomizer.LogicFunctionsUpdatedRefactored;

// Notes:
//   - Can I break this down?
//     - Hidden Skill counting
//     - General item counting (Sword, claws, active dr)

namespace LogicFunctionsNS
{
    class HelperFunctions
    {
        public static SharedSettings SharedSettings = Randomizer.SSettings;

        /// <summary>
        /// Checks for the ability to survive damage done by bonks in OHKO mode.
        /// </summary>
        /// /// <returns>`true` if so, else `false`.</returns>
        public static bool CanSurviveBonkDamage()
        {
            // Check the setting "bonksDoDamage"
            bool BonksDamageEnabled = SharedSettings.bonksDoDamage;

            // Check the setting "damageMagnification"
            bool IsOHKO = SharedSettings.damageMagnification == DamageMagnification.OHKO;

            return !BonksDamageEnabled
                || (BonksDamageEnabled && (!IsOHKO || LF.CanUseBottledFairies()));
        }

        public static bool CanShieldAttack()
        {
            return LF.hasShield() && HHSL.HasShieldAttack();
        }

        // TODO: Name better? I just need to get this out
        public static bool CheckRules(
            List<Func<bool>> glitchlessRules = null,
            List<Func<bool>> glitchedRules = null,
            List<Func<bool>> nicheRules = null,
            List<Func<bool>> difficultCombatRules = null
        )
        {
            // This is only temporary; replace niche once its setting is added
            bool isGlitched = SharedSettings.logicRules == LogicRules.Glitched;

            // Create a table of the logic flags and their rulesets
            Dictionary<bool, List<Func<bool>>> ruleGroups = new()
            {
                { true, CreateBlankRuleList(glitchlessRules) },
                { isGlitched, CreateBlankRuleList(glitchedRules) },
                { isGlitched, CreateBlankRuleList(nicheRules) }, // Change once niche is implemented
                { false, CreateBlankRuleList(difficultCombatRules) }, // Change once difficult combat is implemented
            };

            // The key is the flag for "Is this glitched?" for ex,
            // the val is a list of rules to check for if a check is in logic
            foreach (var (flag, rules) in ruleGroups)
            {
                // Check first if the flag is true. if so, then check if any rules
                //  are satisfied. Return true if so. Else, continue to search the
                //  rulesets.
                if (flag && rules.Any(rule => rule()))
                {
                    return true;
                }
            }
            return false; // This check is not in logic.
        }

        private static List<Func<bool>> CreateBlankRuleList(List<Func<bool>> listOfRules)
        {
            // Use a blank list if none provided
            listOfRules ??= new List<Func<bool>>();
            return listOfRules;
        }

        public static Func<bool> WrapExpressionAsLambda(bool expression)
        {
            return () => expression;
        }

        public static Func<bool> CanUseLambda(Item item)
        {
            return WrapExpressionAsLambda(CUU.CanUse(item));
        }

        public static Func<bool> CanUseAnyItemLambda(params Item[] listOfItems)
        {
            return WrapExpressionAsLambda(listOfItems.Any(CUU.CanUse));
        }
    }
}
