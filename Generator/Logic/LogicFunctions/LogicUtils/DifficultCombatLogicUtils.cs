using System.Linq;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtils;
using NLU = LogicFunctionsNS.NicheLogicUtils;

// in the JSON, all calls to these functions should pretend the setting is already checked

namespace LogicFunctionsNS
{
    public class DifficultCombatLogicUtils
    {
        public static bool CanUseBacksliceInDC()
        {
            return SettingUtils.CanDoDifficultCombat() && NLU.CanUseBacksliceAsSword();
        }

        public static bool CanUseItemInDC(params Item[] damagingItemList)
        {
            return SettingUtils.CanDoDifficultCombat() && damagingItemList.Any(CUU.CanUse);
        }

        public static bool CanUseBombsInDC()
        {
            return SettingUtils.CanDoDifficultCombat() && BU.HasBombs();
        }

        public static bool CanUseIronBootsInDC()
        {
            return SettingUtils.CanDoDifficultCombat() && CUU.CanUse(Item.Iron_Boots);
        }

        public static bool CanUseSpinnerInDC()
        {
            return SettingUtils.CanDoDifficultCombat() && CUU.CanUse(Item.Spinner);
        }

        public static bool CanUseSpinnerOrIronBootsInDC()
        {
            return CanUseItemInDC([Item.Spinner, Item.Iron_Boots]);
        }

        public static bool CanUseShadowCrystalInDC()
        {
            return SettingUtils.CanDoDifficultCombat() && CUU.CanUse(Item.Shadow_Crystal);
        }
    }
}
