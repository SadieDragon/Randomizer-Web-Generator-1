using System.Linq;
using TPRandomizer;

namespace LogicFunctionsNS
{
    public class DifficultCombatLogicUtils
    {
        public static bool CanUseBacksliceInDC()
        {
            return SettingUtils.CanDoDifficultCombat() && NicheLogicUtils.CanUseBacksliceAsSword();
        }

        public static bool CanUseItemInDC(params Item[] damagingItemList)
        {
            return SettingUtils.CanDoDifficultCombat() && damagingItemList.Any(CanUseUtils.CanUse);
        }

        public static bool CanUseBombsInDC()
        {
            return SettingUtils.CanDoDifficultCombat() && BombUtils.HasBombs();
        }

        public static bool CanUseIronBootsInDC()
        {
            return SettingUtils.CanDoDifficultCombat() && CanUseUtils.CanUse(Item.Iron_Boots);
        }

        public static bool CanUseSpinnerInDC()
        {
            return SettingUtils.CanDoDifficultCombat() && CanUseUtils.CanUse(Item.Spinner);
        }

        public static bool CanUseSpinnerOrIronBootsInDC()
        {
            return CanUseItemInDC([Item.Spinner, Item.Iron_Boots]);
        }

        public static bool CanUseShadowCrystalInDC()
        {
            return SettingUtils.CanDoDifficultCombat() && CanUseUtils.CanUse(Item.Shadow_Crystal);
        }
    }
}
