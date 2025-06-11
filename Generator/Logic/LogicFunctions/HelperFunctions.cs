using TPRandomizer;
using TPRandomizer.SSettings.Enums;
using LF = TPRandomizer.LogicFunctionsUpdatedRefactored;

namespace LogicFunctionsNS
{
    class HelperFunctions
    {
        // Shorthand for the SharedSettings
        public static SharedSettings SSettings = Randomizer.SSettings;

        /// <summary>
        /// Checks for the ability to survive damage done by bonks in OHKO mode.
        /// </summary>
        /// /// <returns>`true` if so, else `false`.</returns>
        public static bool CanSurviveBonkDamage()
        {
            // Check the setting "bonksDoDamage"
            bool BonksDamageEnabled = SSettings.bonksDoDamage;

            // Check the setting "damageMagnification"
            bool IsOHKO = SSettings.damageMagnification == DamageMagnification.OHKO;

            return !BonksDamageEnabled
                || (BonksDamageEnabled && (!IsOHKO || LF.CanUseBottledFairies()));
        }
    }
}
