using TPRandomizer;

namespace LogicFunctionsNS
{
    public class BombUtils
    {
        public static bool CanFishForWaterBombs()
        {
            return ERLogicFunctions.HasReachedRoom("Eldin Field Water Bomb Fish Grotto")
                && CanUseUtils.CanUse(Item.Progressive_Fishing_Rod);
        }

        public static bool CanLaunchBombs()
        {
            return HasBombs()
                && (CanUseUtils.CanUse(Item.Boomerang) || CanUseUtils.CanUse(Item.Progressive_Bow));
        }

        public static bool CanSmash()
        {
            return CanUseUtils.CanUse(Item.Ball_and_Chain) || HasBombs();
        }

        public static bool CanUseWaterBombs()
        {
            return CanUseUtils.CanUse(Item.Filled_Bomb_Bag)
                && (
                    ERLogicFunctions.HasReachedRoom("Kakariko Barnes Bomb Shop Lower")
                    || CanFishForWaterBombs()
                    || (
                        ERLogicFunctions.HasReachedRoom("Kakariko Barnes Bomb Shop Lower")
                        && ERLogicFunctions.HasReachedRoom("Castle Town Malo Mart")
                    )
                );
        }

        public static bool HasBombs()
        {
            return CanUseUtils.CanUse(Item.Filled_Bomb_Bag)
                && (
                    ERLogicFunctions.HasReachedRoom("Kakariko Barnes Bomb Shop Lower")
                    || CanFishForWaterBombs()
                    || ERLogicFunctions.HasReachedRoom("City in The Sky Entrance")
                );
        }
    }
}
