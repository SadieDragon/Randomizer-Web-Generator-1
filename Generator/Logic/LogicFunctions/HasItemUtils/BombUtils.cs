using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtils;
using ERLF = LogicFunctionsNS.ERLogicFunctions;

namespace LogicFunctionsNS
{
    public class BombUtils
    {
        public static bool CanFishForWaterBombs()
        {
            return ERLF.HasReachedRoom("Eldin Field Water Bomb Fish Grotto")
                && CUU.CanUse(Item.Progressive_Fishing_Rod);
        }

        public static bool CanLaunchBombs()
        {
            return (CUU.CanUse(Item.Boomerang) || CUU.CanUse(Item.Progressive_Bow)) && HasBombs();
        }

        public static bool CanSmash()
        {
            return CUU.CanUse(Item.Ball_and_Chain) || HasBombs();
        }

        public static bool CanUseWaterBombs()
        {
            return CUU.CanUse(Item.Filled_Bomb_Bag)
                && (
                    ERLF.HasReachedBarnesBombs()
                    || CanFishForWaterBombs()
                    || (
                        ERLF.HasReachedBarnesBombs() && ERLF.HasReachedRoom("Castle Town Malo Mart")
                    )
                );
        }

        public static bool HasBombs()
        {
            return CUU.CanUse(Item.Filled_Bomb_Bag)
                && (
                    ERLF.HasReachedBarnesBombs()
                    || CanFishForWaterBombs()
                    || ERLF.HasReachedRoom("City in The Sky Entrance")
                );
        }
    }
}
