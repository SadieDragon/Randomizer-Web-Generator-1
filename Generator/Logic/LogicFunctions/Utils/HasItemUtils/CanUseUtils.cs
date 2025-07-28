using System;
using System.Collections.Generic;
using System.Linq;
using TPRandomizer;

namespace LogicFunctionsNS
{
    public class CanUseUtils
    {
        private static readonly List<Item> ItemList = Randomizer.Items.heldItems;

        public static bool CanUse(Item item)
        {
            return ItemList.Contains(item) && CanReplenishUtils.CanReplenishItem(item);
        }

        // unused override for passing in a str.
        public static bool CanUse(string item) => CanUse(HelperFunctions.ConvertStrToItem(item));

        private static int CountItem(Item itemToBeCounted)
        {
            return ItemList.Count(item => item == itemToBeCounted);
        }

        /// <summary>
        /// Count the number of a given item available, including if the item can
        /// be replenished.
        /// </summary>
        /// <param name="itemToBeCounted">(Item) Item to be counted.</param>
        /// <returns>Returns the amount available.</returns>
        public static int GetItemCount(Item itemToBeCounted)
        {
            // Only count how many of the item there are if it can be replenished
            if (CanReplenishUtils.CanReplenishItem(itemToBeCounted))
            {
                return CountItem(itemToBeCounted);
            }
            // Fallback of "0"
            return 0;
        }

        public static bool VerifyItemQuantity(Item itemToBeCounted, int targetQuantity)
        {
            return CountItem(itemToBeCounted) >= targetQuantity;
        }

        // unused override for passing in a str.
        public static bool VerifyItemQuantity(string itemToBeCounted, int quantity)
        {
            return VerifyItemQuantity(HelperFunctions.ConvertStrToItem(itemToBeCounted), quantity);
        }
    }
}
