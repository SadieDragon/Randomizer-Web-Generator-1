using TPRandomizer;

namespace LogicFunctionsNS
{
    public class NicheLogicUtils
    {
        public static bool CanDoNicheCombat()
        {
            return SettingUtils.CanDoNicheStuff()
                && (HasHiddenSkillLevel.HasBackslice() || CanUseUtils.CanUse(Item.Iron_Boots));
        }

        public static bool CanUseBacksliceAsSword()
        {
            return SettingUtils.CanDoNicheStuff() && HasHiddenSkillLevel.HasBackslice();
        }

        public static bool CanUseMagicArmorNiche()
        {
            return SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Magic_Armor);
        }

        public static bool CanUseIronBootsNiche()
        {
            return SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots);
        }
    }
}
