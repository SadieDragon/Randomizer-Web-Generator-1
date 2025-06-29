using DCLU = LogicFunctionsNS.DifficultCombatLogicUtils;
using HBL = LogicFunctionsNS.HasBowLevel;

namespace LogicFunctionsNS.DifficultCombatLogic
{
    public class CanDefeatMiniBoss
    {
        public static bool CanDefeatKingBulblinDesert()
        {
            return DCLU.CanUseSpinnerOrIronBootsInDC()
                || DCLU.CanUseBombsInDC()
                || (DCLU.CanDoDifficultCombat() && HBL.HasMediumQuiver());
        }

        public static bool CanDefeatKingBulblinCastle()
        {
            return DCLU.CanUseBacksliceInDC()
                || DCLU.CanUseSpinnerOrIronBootsInDC()
                || DCLU.CanUseBombsInDC();
        }

        public static bool CanDefeatDarkhammer() => DCLU.CanUseBacksliceInDC();
    }
}
