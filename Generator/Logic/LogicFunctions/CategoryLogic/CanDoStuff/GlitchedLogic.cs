using GLU = LogicFunctionsNS.GlitchedLogicUtils;
using HSL = LogicFunctionsNS.HasSwordLevel;

namespace LogicFunctionsNS.GlitchedLogic
{
    public class CanDoStuff
    {
        public static bool CanKnockDownHCPainting()
        {
            return GLU.IsGlitchedLogic()
                && ((HSL.HasSword() && GLU.CanDoMoonBoots()) || GLU.CanDoBSMoonBoots());
        }
    }
}
