using System;
using System.Collections.Generic;
using System.Linq;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtils;
using HSL = LogicFunctionsNS.HasSwordLevel;
using MIU = LogicFunctionsNS.MiscItemUtils;

// TODO: Clean up the summary blocks.

namespace LogicFunctionsNS
{
    public class DamagingItems
    {
        private static bool HasDamagingItemInList(
            List<Item> listOfItems,
            bool includeExtraDefault,
            Func<bool> testForExtraDefault,
            params Item[] extraItems
        )
        {
            // Bow and B&C are *always* checked for with these functions.
            List<Item> damagingItemList = [Item.Ball_and_Chain, Item.Progressive_Bow];
            // Add the list of items, and the list of extra items.
            damagingItemList.AddRange(listOfItems);
            damagingItemList.AddRange(extraItems);

            // Check if any of them are in the held items.
            return damagingItemList.Any(CUU.CanUse)
                || (includeExtraDefault && testForExtraDefault());
        }

        /// <summary>
        /// Sword, B&C, Bow, SC, spinner
        /// </summary>
        /// <param name="includeBombs">False if no bombs; default true</param>
        /// <param name="extraItem">Any extra item</param>
        /// <returns></returns>
        public static bool HasBaseDamagingItem(bool includeBombs = true, params Item[] extraItems)
        {
            return HSL.HasSword()
                || HasDamagingItemInList(
                    [Item.Shadow_Crystal, Item.Spinner],
                    includeBombs,
                    BU.HasBombs,
                    extraItems
                );
        }

        public static bool HasBaseDamagingItemOrClawshot(bool includeBombs = true)
        {
            return HasBaseDamagingItem(includeBombs, extraItems: Item.Progressive_Clawshot);
        }

        public static bool HasBaseDamagingItemOrSlingshot(bool includeBombs = true)
        {
            return HasBaseDamagingItem(includeBombs, extraItems: Item.Slingshot);
        }

        /// <summary>
        /// b&C, bow, slingshot. Claw, unless told not claw. provide extra item, expects
        /// spinner as default but takes any.
        /// </summary>
        /// <param name="includeClawshot"></param>
        /// <param name="extraItem"></`1param>
        /// <returns></returns>
        public static bool HasAltDamagingItem(
            bool includeClawshot = true,
            Item extraItem = Item.Spinner
        )
        {
            /// Slingshot and Clawshot were consistent across the ones that needed the
            /// `AnyDamagingItem`, although 1 instance did not use the clawshot. Spinner
            /// was the most common "extra item" on that list, though once it was the
            /// crystal and once it was the rang.
            static bool testForClaw() => CUU.CanUse(Item.Progressive_Clawshot);
            return HasDamagingItemInList([Item.Slingshot, extraItem], includeClawshot, testForClaw);
        }

        // TODO: better name
        // a collection of remaining extra repeated checks?
        public static bool HasMeleeAltDamagingItem(
            bool includeSword = true,
            bool includeBow = true,
            bool includeCrystal = true,
            bool includeBombs = true
        )
        {
            return (includeSword && HSL.HasSword())
                || CUU.CanUse(Item.Ball_and_Chain)
                || (includeBow && CUU.CanUse(Item.Progressive_Bow))
                || (includeCrystal && CUU.CanUse(Item.Shadow_Crystal))
                || (includeBombs && BU.HasBombs());
        }

        // TOOD: better name. seriously.
        public static bool HasAltDamagingItemExtended(bool includeShieldAttack = true)
        {
            return HSL.HasSword()
                || HasAltDamagingItem()
                || (includeShieldAttack && MIU.CanShieldAttack())
                || BU.HasBombs();
        }
    }
}
