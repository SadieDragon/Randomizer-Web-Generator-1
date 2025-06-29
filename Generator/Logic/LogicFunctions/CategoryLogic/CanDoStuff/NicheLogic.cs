using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;
using HHSL = LogicFunctionsNS.HasHiddenSkillLevel;
using HSL = LogicFunctionsNS.HasSwordLevel;
using MIU = LogicFunctionsNS.MiscItemUtils;
using NLU = LogicFunctionsNS.NicheLogicUtils;

namespace LogicFunctionsNS.NicheLogic
{
    public class CanDoStuff
    {
        public static bool CanKnockDownHCPainting()
        {
            return NLU.CanDoNicheStuff()
                && (BU.HasBombs() || (HSL.HasSword() && HHSL.HasJumpStrike()));
        }

        public static bool CanBreakMonkeyCage()
        {
            return NLU.CanDoNicheStuff() && MIU.CanShieldAttack();
        }

        public static bool CanPressMinesSwitch()
        {
            return NLU.CanDoNicheStuff() && CUU.CanUse(TPRandomizer.Item.Ball_and_Chain);
        }

        public static bool CanBreakWoodenDoor() => NLU.CanDoNicheCombat(includeBoots: false);
    }
}
