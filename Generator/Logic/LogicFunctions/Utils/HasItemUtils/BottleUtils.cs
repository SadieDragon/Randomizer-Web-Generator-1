using System.Collections.Generic;
using System.Linq;
using TPRandomizer;

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

            return CanUseUtils.CanUse(Item.Lantern)
                && (bottles.Count(ItemList.Contains) >= minimumBottles);
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
                    ERLogicFunctions.HasReachedRoom("Lower Kakariko Village")
                    || (
                        ERLogicFunctions.HasReachedRoom("Death Mountain Elevator Lower")
                        && CanDefeatCommonEnemy.CanDefeatGoron()
                    )
                );
        }

        public static bool CanUseBottledFairy()
        {
            return HasBottle() && ERLogicFunctions.HasReachedRoom("Lake Hylia");
        }

        public static bool CanUseBottledFairies()
        {
            return HasBottles() && ERLogicFunctions.HasReachedRoom("Lake Hylia");
        }

        public static bool CanUseOilBottle()
        {
            return CanUseUtils.CanUse(Item.Lantern) && CanUseUtils.CanUse(Item.Coro_Bottle);
        }
    }
}
