using DCLU = LogicFunctionsNS.DifficultCombatLogicUtils;
using HBL = LogicFunctionsNS.HasQuiverSize;

namespace LogicFunctionsNS.DifficultCombatLogic
{
    public class CanDefeatMiniBoss
    {
        public static bool CanDefeatKingBulblinDesert()
        {
            return DCLU.CanUseSpinnerOrIronBootsInDC()
                || DCLU.CanUseBombsInDC()
                || (SettingUtils.CanDoDifficultCombat() && HBL.HasMediumQuiver());
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
