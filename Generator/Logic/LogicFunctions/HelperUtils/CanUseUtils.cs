// TODO: Better name
// TODO: How to 'subclass?'

using System;
using System.Collections.Generic;
using System.Linq;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using ERLF = LogicFunctionsNS.ERLogicFunctions;
using HLF = LogicFunctionsNS.HelperFunctions;

namespace LogicFunctionsNS
{
    public class CanUseUtils
    {
        private static readonly List<Item> ItemList = Randomizer.Items.heldItems;

        public static bool CanUse(Item item)
        {
            return ItemList.Contains(item) && CanReplenishItem(item);
        }

        // unused override for passing in a str.
        public static bool CanUse(string item) => CanUse(HLF.ConvertStrToItem(item));

        public static bool CanReplenishItem(Item item)
        {
            Dictionary<Item, bool> itemRefills = new()
            {
                { Item.Lantern, CanRefillOil() },
                { Item.Progressive_Bow, CanGetArrows() },
            };

            if (itemRefills.TryGetValue(item, out var check))
            {
                return check;
            }
            return true;
        }

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
            if (CanReplenishItem(itemToBeCounted))
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
            return VerifyItemQuantity(HLF.ConvertStrToItem(itemToBeCounted), quantity);
        }

        // I put these here because they go with CanReplenish.
        public static bool CanGetArrows()
        {
            return ERLF.HasReachedRoom("Lost Woods")
                || (
                    CanCompleteDungeon.CanCompleteGoronMines()
                    && ERLF.HasReachedRoom("Kakariko Malo Mart")
                )
                || ERLF.CanShopFromRoom("Castle Town Goron House Balcony");
        }

        public static bool CanRefillOil()
        {
            return ERLF.HasReachedRoom("North Faron Woods")
                || ERLF.HasReachedRoom("South Faron Woods")
                || ERLF.HasReachedRoom("Arbiters Grounds Entrance")
                || (ERLF.HasReachedRoom("Lake Hylia Long Cave") && BU.CanSmash())
                || ERLF.HasReachedRoom("Ordon Seras Shop")
                || (
                    CanCompleteDungeon.CanCompleteGoronMines()
                    && ERLF.HasReachedRoom("Lower Kakariko Village")
                    && CanDoStuff.CanChangeTime()
                )
                || ERLF.CanShopFromRoom("Castle Town Goron House")
                || ERLF.HasReachedRoom("Death Mountain Hot Spring")
                || ERLF.HasReachedRoom("City in The Sky Entrance")
                // This is for the room that needs the rang in HC
                || (
                    ERLF.HasReachedRoom("Hyrule Castle Main Hall")
                    && CanDefeatCommonEnemy.CanDefeatBokoblin()
                    && CanDefeatCommonEnemy.CanDefeatLizalfos()
                    && HasClawshotCount.HasDoubleClawshot()
                    && CanDefeatCommonEnemy.CanDefeatDarknut()
                )
                || (
                    ERLF.HasReachedRoom("Eldin Lantern Cave")
                    && MiscItemUtils.CanBurnWebs()
                    && CanDefeatCommonEnemy.CanDefeatChu()
                );
        }
    }
}
