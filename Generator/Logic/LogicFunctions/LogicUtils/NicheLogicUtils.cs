using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtils;
using HHSL = LogicFunctionsNS.HasHiddenSkillLevel;

namespace LogicFunctionsNS
{
    public class NicheLogicUtils
    {
        public static bool CanDoNicheCombat(bool includeBackslice = true, bool includeBoots = true)
        {
            return SettingUtils.CanDoNicheStuff()
                && (
                    (includeBackslice && HHSL.HasBackslice())
                    || (includeBoots && CUU.CanUse(Item.Iron_Boots))
                );
        }

        public static bool CanUseBacksliceAsSword()
        {
            return SettingUtils.CanDoNicheStuff() && HHSL.HasBackslice();
        }

        public static bool CanUseMagicArmorNiche()
        {
            return SettingUtils.CanDoNicheStuff() && CUU.CanUse(Item.Magic_Armor);
        }

        public static bool CanUseIronBootsNiche()
        {
            return SettingUtils.CanDoNicheStuff() && CUU.CanUse(Item.Iron_Boots);
        }
    }
}
