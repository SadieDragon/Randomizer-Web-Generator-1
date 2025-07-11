namespace LogicFunctionsNS.DifficultCombatLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatDiababa() => DifficultCombatLogicUtils.CanUseBacksliceInDC();

        public static bool CanDefeatFyrus() => DifficultCombatLogicUtils.CanUseBacksliceInDC();

        public static bool CanDefeatStallord() => DifficultCombatLogicUtils.CanUseSpinnerInDC();
    }
}
