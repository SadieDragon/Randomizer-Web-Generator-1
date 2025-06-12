using TPRandomizer;
using TPRandomizer.SSettings.Enums;
using LF = TPRandomizer.LogicFunctionsUpdatedRefactored;

// Notes:
//   - Can I break this down?
//     - Hidden Skill counting
//     - General item counting (Sword, claws, active dr)

namespace LogicFunctionsNS
{
    class HelperFunctions
    {
        // wrappers to later be removed
        public static int GetItemCount(Item ItemToBeCounted)
        {
            return LF.getItemCount(ItemToBeCounted);
        }

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

        public static bool HasShieldAttack()
        {
            return GetItemCount(Item.Progressive_Hidden_Skill) >= 2;
        }

        public static bool CanShieldAttack()
        {
            return LF.hasShield() && HasShieldAttack();
        }

        public static bool HasBackslice()
        {
            return GetItemCount(Item.Progressive_Hidden_Skill) >= 3;
        }

        public static bool HasJumpStrike()
        {
            return GetItemCount(Item.Progressive_Hidden_Skill) >= 6;
        }
    }
}
