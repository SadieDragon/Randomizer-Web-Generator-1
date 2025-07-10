// Leave this file, do not delete it. If logic changes come later, then you can very easily
//  just update the functions within this file, or add new ones as needed. Do not try to
//  simplify this, unless you are going to simplify the `CanX` system altogether. - Lupa

using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtils;
using DCLU = LogicFunctionsNS.DifficultCombatLogicUtils;

namespace LogicFunctionsNS.DifficultCombatLogic
{
    public class CanDefeatCommonEnemy
    {
        private static readonly bool canDoDifficultCombat = false;

        public static bool CanDefeatBokoblinRed() => DCLU.CanUseSpinnerOrIronBootsInDC();

        public static bool CanDefeatDarknut()
        {
            return canDoDifficultCombat && (BU.HasBombs() || CUU.CanUse(Item.Ball_and_Chain));
        }

        public static bool CanDefeatFireToadpoli() => DCLU.CanUseShadowCrystalInDC();

        public static bool CanDefeatGoron()
        {
            return canDoDifficultCombat && CUU.CanUse(Item.Lantern);
        }

        public static bool CanDefeatGuay() => DCLU.CanUseSpinnerInDC();

        public static bool CanDefeatWaterToadpoli() => DCLU.CanUseShadowCrystalInDC();
    }
}
