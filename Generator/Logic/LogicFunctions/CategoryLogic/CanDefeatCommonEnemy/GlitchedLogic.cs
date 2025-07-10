// Leave this file, do not delete it. If logic changes come later, then you can very easily
//  just update the functions within this file, or add new ones as needed. Do not try to
//  simplify this, unless you are going to simplify the `CanX` system altogether. - Lupa

using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtils;

namespace LogicFunctionsNS.GlitchedLogic
{
    public class CanDefeatCommonEnemy
    {
        public static bool CanDefeatBombfish()
        {
            return SettingUtils.IsGlitchedLogic() && CUU.CanUse(Item.Magic_Armor);
        }
    }
}
