using GLU = LogicFunctionsNS.GlitchedLogicUtils;

namespace LogicFunctionsNS.GlitchedLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatZant()
        {
            return GLU.IsGlitchedLogic() && GLU.CanDoAirRefill();
        }
    }
}
