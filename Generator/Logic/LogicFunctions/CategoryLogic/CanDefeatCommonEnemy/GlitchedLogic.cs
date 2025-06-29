// Leave this file, do not delete it. If logic changes come later, then you can very easily
//  just update the functions within this file, or add new ones as needed. Do not try to
//  simplify this, unless you are going to simplify the `CanX` system altogether. - Lupa

using TPRandomizer;
using TPRandomizer.SSettings.Enums;
using CUU = LogicFunctionsNS.CanUseUtilities;

namespace LogicFunctionsNS.GlitchedLogic
{
    public class CanDefeatCommonEnemy
    {
        private static readonly bool isGlitched =
            Randomizer.SSettings.logicRules == LogicRules.Glitched;

        public static bool CanDefeatBombfish()
        {
            return isGlitched && CUU.CanUse(Item.Magic_Armor);
        }
    }
}
