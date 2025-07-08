using TPRandomizer;

namespace LogicFunctionsNS.CoreLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatFyrus()
        {
            return CanUseUtilities.CanUse(Item.Progressive_Bow)
                && CanUseUtilities.CanUse(Item.Iron_Boots);
        }

        public static bool CanDefeatMorpheel()
        {
            return CanUseUtilities.CanUse(Item.Progressive_Clawshot) && HasSwordLevel.HasSword();
        }

        public static bool CanDefeatArgorok()
        {
            return (CanUseUtilities.GetItemCount(Item.Progressive_Clawshot) >= 2)
                || HasSwordLevel.HasOrdonSword();
        }

        public static bool CanDefeatZant()
        {
            return HasSwordLevel.HasMasterSword()
                && CanUseUtilities.CanUse(Item.Boomerang)
                && CanUseUtilities.CanUse(Item.Progressive_Clawshot)
                && CanUseUtilities.CanUse(Item.Ball_and_Chain);
        }
    }
}
