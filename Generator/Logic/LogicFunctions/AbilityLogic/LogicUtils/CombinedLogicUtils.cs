using TPRandomizer;

// Logic utils for commonly combined logic checks

namespace LogicFunctionsNS
{
    public class CombinedLogicUtils
    {
        #region GlitchlessAndDifficultCombat

        public static bool CanUseSwordOrDifficultBackslice()
        {
            return HasSwordLevel.HasSword() || DifficultCombatLogicUtils.CanUseBacksliceInDC();
        }

        #endregion

        #region GlitchlessAndNiche

        public static bool CanUseBootsOrNicheMagicArmor()
        {
            return CanUseUtils.CanUse(Item.Iron_Boots) || NicheLogicUtils.CanUseMagicArmorNiche();
        }

        #endregion

        #region GlitchlessAndGlitched

        public static bool CanUseBootsOrGlitchedMagicArmor()
        {
            return CanUseUtils.CanUse(Item.Iron_Boots)
                || (SettingUtils.IsGlitchedLogic() && CanUseUtils.CanUse(Item.Magic_Armor));
        }

        #endregion
    }
}
