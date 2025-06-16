using System.Collections.Generic;
using System.Linq;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;

// TODO: Clean up the summary blocks.

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

        // Private? Different file?
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

        /// <summary>
        /// b&C, bow, slingshot. Claw, unless told not claw. provide extra item.
        /// </summary>
        /// <param name="includeClawshot"></param>
        /// <param name="extraItem"></`1param>
        /// <returns></returns>
        public static bool HasAltDamagingItem(
            bool includeClawshot = true,
            Item extraItem = Item.Spinner
        )
        {
            /// B&C, Bow, Slingshot, and Clawshot were consistent across the ones that needed the
            ///  `AnyDamagingItem`, although 1 instance did not use the clawshot. Spinner was the
            ///  most common "extra item" on that list, though once it was the crystal and once it
            ///  was the rang.
            List<Item> alternateDIList =
            [
                Item.Ball_and_Chain,
                Item.Progressive_Bow,
                Item.Slingshot,
                extraItem,
            ];

            if (includeClawshot)
            {
                alternateDIList.Add(Item.Progressive_Clawshot);
            }

            return HasAnyDamagingItem(alternateDIList);
        }
    }
}
