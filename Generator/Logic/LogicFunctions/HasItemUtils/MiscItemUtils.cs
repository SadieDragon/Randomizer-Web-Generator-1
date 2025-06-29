// "These are item utils" but they have no home.

using System.Linq;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;
using ERLF = LogicFunctionsNS.ERLogicFunctions;
using HHSL = LogicFunctionsNS.HasHiddenSkillLevel;

namespace LogicFunctionsNS
{
    public class MiscItemUtils
    {
        public static bool HasShield()
        {
            return CUU.CanUse(Item.Hylian_Shield)
                || ERLF.CanShopFromRoom("Kakariko Malo Mart")
                || ERLF.CanShopFromRoom("Castle Town Goron House")
                || ERLF.HasReachedRoom("Death Mountain Hot Spring");
        }

        public static bool CanShieldAttack()
        {
            return HasShield() && HHSL.HasShieldAttack();
        }

        public static bool CanBurnWebs()
        {
            return CUU.CanUse(Item.Lantern) || BU.HasBombs() || CUU.CanUse(Item.Ball_and_Chain);
        }

        public static bool HasRangedItem()
        {
            return CUU.CanUse(Item.Ball_and_Chain)
                || CUU.CanUse(Item.Slingshot)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Progressive_Clawshot)
                || CUU.CanUse(Item.Boomerang);
        }

        public static bool CanCutHangingWeb()
        {
            return CUU.CanUse(Item.Progressive_Clawshot)
                || CUU.CanUse(Item.Progressive_Bow)
                || CUU.CanUse(Item.Boomerang)
                || CUU.CanUse(Item.Ball_and_Chain);
        }

        public static bool HasBug()
        {
            return Randomizer.Items.goldenBugs.Any(CUU.CanUse);
        }
    }
}
