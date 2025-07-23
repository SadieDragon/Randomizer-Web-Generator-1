// The one in HLF, minus bombs & crystal (HasDamagingItemExcludingCrystalAndBombs)
// That, + bombs (HasDamagingItemExcludingCrystal)
// The first, + crystal (HasDamagingItemExcludingBombs)
// The first, + bombs and crystal (HasDamagingItem)
// The fourth + claw (HasDamagingItemIncludingClaw)
// The fourth + sling (HasDamagingItemIncludingSling)

using System.Collections.Generic;
using System.Linq;
using TPRandomizer;

namespace LogicFunctionsNS
{
    public static class HasDamagingItemUtils
    {
        private static readonly List<Item> baseItems =
        [
            Item.Progressive_Sword,
            Item.Ball_and_Chain,
            Item.Progressive_Bow,
            Item.Spinner,
        ];

        // Wrapper for adding items to the list for HAI
        private static List<Item> AddItemsToBase(Item params itemToAdd);
        private static readonly List<Item> bombBag = [Item.Filled_Bomb_Bag];

        private static bool HasAnyItems(List<Item> itemsToCheck)
        {
            // Note: This could be `itemsToCheck.Any(CanUseUtils.CanUse), technically,
            //   but I wanted to code this so that there were special cases for bombs and
            //   the sword.
            // This could also be in `CanUseUtils`, but I decided to do it here, for now.
            // - Lupa (SadieDragon)
            foreach (Item itemToCheck in itemsToCheck)
            {
                // Special checks for sword, in case it is made unique
                if ((itemToCheck == Item.Progressive_Sword) && HasSwordLevel.HasSword())
                {
                    return true;
                }
                // Sepcial case for bomb bag.
                else if ((itemToCheck == Item.Filled_Bomb_Bag) && BombUtils.HasBombs())
                {
                    return true;
                }
                // Otherwise, use `CanUse`
                else if (CanUseUtils.CanUse(itemToCheck))
                {
                    return true;
                }
            }
            // If did not short circuit, then false.
            return false;
        }

        /// <summary>
        /// E for excluding. Checks for Sword, B&C, Bow, and Spinner.
        /// </summary>
        /// <returns></returns>
        public static bool HasDamagingItemECrystalAndBombs() => HasAnyItems(baseItems);

        /// <summary>
        /// E for excluding. Checks for Sword, B&C, Bow, Spinner, and Bombs.
        /// </summary>
        /// <returns></returns>
        public static bool HasDamagingItemECrystal()
        {
            return HasAnyItems((List<Item>)baseItems.Concat(bombBag));
        }

        /// <summary>
        /// E for excluding. Checks for Sword, B&C, Bow, Spinner, and Crystal.
        /// </summary>
        /// <returns></returns>
        public static bool HasDamagingItemEgBombs()
        {
            return HasDamagingItemECrystalAndBombs() || CanUseUtils.CanUse(Item.Shadow_Crystal);
        }

        /// <summary>
        /// Checks for Sword, B&C, Bow, Spinner, Bombs, and Crystal.
        /// </summary>
        /// <returns></returns>
        public static bool HasDamagingItem()
        {
            return HasDamagingItemECrystalAndBombs()
                || BombUtils.HasBombs()
                || CanUseUtils.CanUse(Item.Shadow_Crystal);
        }
    }
}
