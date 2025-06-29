// TODO: Doesn't belong here; but change the different states to flags. so flags for Glitched,
//  Niche, etc logic. Probs break the niche and DC into diff cats of flags? I assume they'll be
//  diff...
// TODO: also doesn't belong here, but look into that last ?

using System.Linq;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;
using NLU = LogicFunctionsNS.NicheLogicUtils;

namespace LogicFunctionsNS
{
    public class DifficultCombatLogicUtils
    {
        /// <summary>
        /// Checks the setting for difficult combat. Difficult combat includes: difficult, annoying, or time consuming combat
        /// </summary>
        public static bool CanDoDifficultCombat()
        {
            // TODO: Change to use setting once it's made
            return false;
        }

        public static bool CanUseBacksliceInDC()
        {
            return CanDoDifficultCombat() && NLU.CanUseBacksliceAsSword();
        }

        public static bool CanUseItemInDC(params Item[] damagingItemList)
        {
            return CanDoDifficultCombat() && damagingItemList.Any(CUU.CanUse);
        }

        public static bool CanUseBombsInDC()
        {
            return CanDoDifficultCombat() && BU.HasBombs();
        }

        public static bool CanUseIronBootsInDC()
        {
            return CanDoDifficultCombat() && CUU.CanUse(Item.Iron_Boots);
        }

        public static bool CanUseSpinnerInDC()
        {
            return CanDoDifficultCombat() && CUU.CanUse(Item.Spinner);
        }

        public static bool CanUseSpinnerOrIronBootsInDC()
        {
            return CanUseItemInDC([Item.Spinner, Item.Iron_Boots]);
        }

        public static bool CanUseShadowCrystalInDC()
        {
            return CanDoDifficultCombat() && CUU.CanUse(Item.Shadow_Crystal);
        }
    }
}
