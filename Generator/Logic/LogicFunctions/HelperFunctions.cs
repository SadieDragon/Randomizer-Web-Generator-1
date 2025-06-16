using System;
using TPRandomizer;
using TPRandomizer.SSettings.Enums;
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
        public static bool AnyTrue(params Func<bool>[] conditions)
        {
            foreach (var condition in conditions)
            {
                if (condition())
                    return true;
            }
            return false;
        }

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
    }
}
