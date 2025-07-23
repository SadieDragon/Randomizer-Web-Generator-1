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
        private static List<Item> AddItemsToBase(params Item[] itemToAdd)
        {
            return (List<Item>)baseItems.Concat(itemToAdd);
        }

        // A placeholder for the bomb bag to be recognized
        private static readonly Item bombBag = Item.Filled_Bomb_Bag;

        private static bool HasAnyItems(List<Item> itemsToCheck)
        {
            // Note: This could be `itemsToCheck.Any(CanUseUtils.CanUse), technically,
            //   but I wanted to code this so that there were special cases for bombs and
            //   the sword and bombs.
            // This could also be in `CanUseUtils`, but I decided to do it here, for now.
            // - Lupa (SadieDragon)
            foreach (Item itemToCheck in itemsToCheck)
            {
                // Special checks for sword, in case it is made unique
                if ((itemToCheck == Item.Progressive_Sword) && HasSwordLevel.HasSword())
                {
                    return true;
                }
                // Sepcial case for bomb bag
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
            // If did not short circuit, then the user does not have any of the items.
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
            return HasAnyItems(AddItemsToBase(bombBag));
        }

        /// <summary>
        /// E for excluding. Checks for Sword, B&C, Bow, Spinner, and Crystal.
        /// </summary>
        /// <returns></returns>
        public static bool HasDamagingItemEBombs()
        {
            return HasAnyItems(AddItemsToBase(Item.Shadow_Crystal));
        }

        /// <summary>
        /// Checks for Sword, B&C, Bow, Spinner, Bombs, and Crystal.
        /// </summary>
        /// <returns></returns>
        public static bool HasDamagingItem()
        {
            return HasAnyItems(AddItemsToBase(bombBag, Item.Shadow_Crystal));
        }

        /// <summary>
        /// I for including. Checks for Sword, B&C, Bow, Spinner, Bombs, Crystal, and Clawshot.
        /// </summary>
        /// <returns></returns>
        public static bool HasDamagingItemIClawshot()
        {
            return HasDamagingItem() || HasClawshotCount.HasSingleClawshot();
        }

        /// <summary>
        /// I for including. Checks for Sword, B&C, Bow, Spinner, Bombs, Crystal, and Slingshot.
        /// </summary>
        /// <returns></returns>
        public static bool HasDamagingItemISlingshot()
        {
            return HasDamagingItem() || CanUseUtils.CanUse(Item.Slingshot);
        }
    }
}
