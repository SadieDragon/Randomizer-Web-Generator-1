using DCLU = LogicFunctionsNS.DifficultCombatLogicUtils;

namespace LogicFunctionsNS.DifficultCombatLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatDiababa() => DCLU.CanUseBacksliceInDC();

        public static bool CanDefeatFyrus() => DCLU.CanUseBacksliceInDC();

        public static bool CanDefeatStallord() => DCLU.CanUseSpinnerInDC();
    }
}
