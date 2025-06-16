using System.Collections.Generic;
using System.Linq;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;

namespace LogicFunctionsNS
{
    public class DamagingItems
    {
        private static readonly List<Item> BaseDIList =
        [
            Item.Progressive_Sword,
            Item.Ball_and_Chain,
            Item.Progressive_Bow,
            Item.Shadow_Crystal,
            Item.Spinner,
        ];

        public static bool HasAnyDamagingItem(List<Item> listOfItems)
        {
            return listOfItems.Any(CUU.CanUse);
        }

        public static bool HasBaseDamagingItem()
        {
            return HasAnyDamagingItem(BaseDIList);
        }

        /// <summary>
        /// Sword, B&C, Bow, SC, spinner
        /// </summary>
        /// <param name="includeBombs">False if no bombs; default true</param>
        /// <param name="extraItems">Any extra items</param>
        /// <returns></returns>
        public static bool HasDamagingItem(bool includeBombs = true, params Item[] extraItems)
        {
            return HasBaseDamagingItem()
                || (includeBombs && BU.HasBombs())
                // [.. extraItems] is suggested; is this valid?? Can't find info - Lupa
                // Need to convert to a proper list; won't change the other fn's param typing
                || HasAnyDamagingItem(extraItems.ToList());
        }

        public static bool HasDamagingItemOrClawshot(bool includeBombs = true)
        {
            return HasDamagingItem(includeBombs, Item.Progressive_Clawshot);
        }

        public static bool HasDamagingItemOrSlingshot(bool includeBombs = true)
        {
            return HasDamagingItem(includeBombs, Item.Slingshot);
        }
    }
}
