using System.Collections.Generic;
using TPRandomizer;

namespace LogicFunctionsNS
{
    public static class CanReplenishUtils
    {
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

        public static bool CanGetArrows()
        {
            return ERLogicFunctions.HasReachedRoom("Lost Woods")
                || (
                    CanCompleteDungeon.CanCompleteGoronMines()
                    && ERLogicFunctions.HasReachedRoom("Kakariko Malo Mart")
                )
                || ERLogicFunctions.CanShopFromRoom("Castle Town Goron House Balcony");
        }

        public static bool CanRefillOil()
        {
            return ERLogicFunctions.HasReachedRoom("North Faron Woods")
                || ERLogicFunctions.HasReachedRoom("South Faron Woods")
                || ERLogicFunctions.HasReachedRoom("Arbiters Grounds Entrance")
                || (ERLogicFunctions.HasReachedRoom("Lake Hylia Long Cave") && BombUtils.CanSmash())
                || ERLogicFunctions.HasReachedRoom("Ordon Seras Shop")
                || (
                    CanCompleteDungeon.CanCompleteGoronMines()
                    && ERLogicFunctions.HasReachedRoom("Lower Kakariko Village")
                    && CanDoStuff.CanChangeTime()
                )
                || ERLogicFunctions.CanShopFromRoom("Castle Town Goron House")
                || ERLogicFunctions.HasReachedRoom("Death Mountain Hot Spring")
                || ERLogicFunctions.HasReachedRoom("City in The Sky Entrance")
                // This is for lantern staircase room
                || (
                    ERLogicFunctions.HasReachedRoom("Hyrule Castle Main Hall")
                    && CanDefeatCommonEnemy.CanDefeatBokoblin()
                    && CanDefeatCommonEnemy.CanDefeatLizalfos()
                    && HasClawshotCount.HasDoubleClawshot()
                    && CanDefeatCommonEnemy.CanDefeatDarknut()
                )
                || (
                    ERLogicFunctions.HasReachedRoom("Eldin Lantern Cave")
                    && CanDoStuff.CanBurnWebs()
                    && CanDefeatCommonEnemy.CanDefeatChu()
                );
        }
    }
}
