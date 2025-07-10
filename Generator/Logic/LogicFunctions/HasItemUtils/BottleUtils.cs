using System.Collections.Generic;
using System.Linq;
using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtils;
using ERLF = LogicFunctionsNS.ERLogicFunctions;
using GLLCE = LogicFunctionsNS.GlitchlessLogic.CanDefeatCommonEnemy;

namespace LogicFunctionsNS
{
    public class BottleUtils
    {
        private static readonly List<Item> ItemList = Randomizer.Items.heldItems;

        private static bool HasAtLeastXBottles(int minimumBottles)
        {
            List<Item> bottles =
            [
                Item.Empty_Bottle,
                Item.Sera_Bottle,
                Item.Jovani_Bottle,
                Item.Coro_Bottle,
            ];

            return CUU.CanUse(Item.Lantern) && (bottles.Count(ItemList.Contains) >= minimumBottles);
        }

        /// <summary>
        /// Check for a usable bottle (requires lantern to avoid issues with lantern oil in all bottles)
        /// </summary>
        public static bool HasBottle() => HasAtLeastXBottles(1);

        public static bool HasBottles() => HasAtLeastXBottles(2);

        public static bool CanGetHotSpringWater()
        {
            return HasBottle()
                && (
                    ERLF.HasReachedRoom("Lower Kakariko Village")
                    || (
                        ERLF.HasReachedRoom("Death Mountain Elevator Lower")
                        && GLLCE.CanDefeatGoron()
                    )
                );
        }

        public static bool CanUseBottledFairy()
        {
            return HasBottle() && ERLF.HasReachedLakeHylia();
        }

        public static bool CanUseBottledFairies()
        {
            return HasBottles() && ERLF.HasReachedLakeHylia();
        }

        public static bool CanUseOilBottle()
        {
            return CUU.CanUse(Item.Lantern) && CUU.CanUse(Item.Coro_Bottle);
        }
    }
}
