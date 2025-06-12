// TODO: Better name
// TODO: How to 'subclass?'

using System.Collections.Generic;
using System.Linq;
using TPRandomizer;
using LF = TPRandomizer.LogicFunctionsUpdatedRefactored;

namespace LogicFunctionsNS
{
    public class CanUseUtilities
    {
        public static List<Item> ItemList = Randomizer.Items.heldItems;

        public static bool CanUse(Item item)
        {
            return ItemList.Contains(item) && CanReplenishItem(item);
        }

        public static bool CanReplenishItem(Item item)
        {
            Dictionary<Item, bool> ItemRefills = new()
            {
                { Item.Lantern, LF.CanRefillOil() },
                { Item.Progressive_Bow, LF.CanGetArrows() },
            };

            if (ItemRefills.TryGetValue(item, out var check))
            {
                return check;
            }
            return true;
        }

        /// <summary>
        /// Count the number of a given item available, including if the item can
        /// be replenished.
        /// </summary>
        /// <param name="ItemToBeCounted">(Item) Item to be counted.</param>
        /// <returns>Returns the amount available.</returns>
        public static int GetItemCount(Item ItemToBeCounted)
        {
            // Only count how many of the item there are if it can be replenished
            if (CanReplenishItem(ItemToBeCounted))
            {
                return ItemList.Count(item_ => item_ == ItemToBeCounted);
            }
            // Fallback of "0"
            return 0;
        }
    }
}
