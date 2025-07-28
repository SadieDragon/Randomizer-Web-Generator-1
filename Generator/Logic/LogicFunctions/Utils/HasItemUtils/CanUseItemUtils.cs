using System.Linq;
using TPRandomizer;

namespace LogicFunctionsNS
{
    public class CanUseItemUtils
    {
        public static bool HasShield()
        {
            return CanUseUtils.CanUse(Item.Hylian_Shield)
                || ERLogicFunctions.CanShopFromRoom("Kakariko Malo Mart")
                || ERLogicFunctions.CanShopFromRoom("Castle Town Goron House")
                || ERLogicFunctions.HasReachedRoom("Death Mountain Hot Spring");
        }

        public static bool HasRangedItem()
        {
            return CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || CanUseUtils.CanUse(Item.Boomerang);
        }

        public static bool HasBug()
        {
            return Randomizer.Items.goldenBugs.Any(CanUseUtils.CanUse);
        }
    }
}
