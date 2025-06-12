using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtilities;
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
