// TODO: Better name
// TODO: How to 'subclass?'

using System.Collections.Generic;
using System.Linq;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using ERLF = LogicFunctionsNS.ERLogicFunctions;
using HLF = LogicFunctionsNS.HelperFunctions;
using LF = TPRandomizer.LogicFunctionsUpdatedRefactored;

namespace LogicFunctionsNS
{
    public class CanUseUtilities
    {
        private static readonly List<Item> ItemList = Randomizer.Items.heldItems;

        public static bool CanUse(Item item)
        {
            return ItemList.Contains(item) && CanReplenishItem(item);
        }

        public static bool CanReplenishItem(Item item) => LogicFunctions.CanReplenishItem(item);

        // public static bool CanReplenishItem(Item item)
        // {
        //     Dictionary<Item, bool> itemRefills = new()
        //     {
        //         { Item.Lantern, CanRefillOil() },
        //         { Item.Progressive_Bow, CanGetArrows() },
        //     };

        //     if (itemRefills.TryGetValue(item, out var check))
        //     {
        //         return check;
        //     }
        //     return true;
        // }

        /// <summary>
        /// Count the number of a given item available, including if the item can
        /// be replenished.
        /// </summary>
        /// <param name="itemToBeCounted">(Item) Item to be counted.</param>
        /// <returns>Returns the amount available.</returns>
        public static int GetItemCount(Item itemToBeCounted)
        {
            // Only count how many of the item there are if it can be replenished
            if (CanReplenishItem(itemToBeCounted))
            {
                return ItemList.Count(item => item == itemToBeCounted);
            }
            // Fallback of "0"
            return 0;
        }

        public static bool VerifyItemQuantity(string itemToBeCounted, int quantity)
        {
            // Convert the list of held items to a list to use to count
            List<string> heldItemsStrings = ItemList.ConvertAll(static item => item.ToString());

            // Count how many of the desired item there are.
            int itemQuantity = heldItemsStrings.Count(item => item == itemToBeCounted);

            return itemQuantity >= quantity;
        }

        // I put these here because they go with CanReplenish.
        public static bool CanGetArrows()
        {
            return ERLF.HasReachedRoom("Lost Woods")
                || (LF.CanCompleteGoronMines() && ERLF.HasReachedKakMaloMart())
                || ERLF.CanShopFromRoom("Castle Town Goron House Balcony");
        }

        public static bool CanRefillOil()
        {
            return ERLF.HasReachedNFaronWoods()
                || ERLF.HasReachedSFaronWoods()
                || ERLF.HasReachedRoom("Arbiters Grounds Entrance")
                || (ERLF.HasReachedRoom("Lake Hylia Long Cave") && BU.CanSmash())
                || ERLF.HasReachedRoom("Ordon Seras Shop")
                || (
                    LF.CanCompleteGoronMines()
                    && ERLF.HasReachedLowerKakVillage()
                    && HLF.CanChangeTime()
                )
                || ERLF.CanShopFromRoom("Castle Town Goron House");
        }
    }
}
