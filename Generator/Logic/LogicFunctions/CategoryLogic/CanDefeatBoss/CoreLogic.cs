using TPRandomizer;

namespace LogicFunctionsNS.CoreLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatFyrus()
        {
            return CanUseUtils.CanUse(Item.Progressive_Bow) && CanUseUtils.CanUse(Item.Iron_Boots);
        }

        public static bool CanDefeatMorpheel()
        {
            return CanUseUtils.CanUse(Item.Progressive_Clawshot) && HasSwordLevel.HasSword();
        }

        public static bool CanDefeatArgorok()
        {
            return (CanUseUtils.GetItemCount(Item.Progressive_Clawshot) >= 2)
                || HasSwordLevel.HasOrdonSword();
        }

        public static bool CanDefeatZant()
        {
            return HasSwordLevel.HasMasterSword()
                && CanUseUtils.CanUse(Item.Boomerang)
                && CanUseUtils.CanUse(Item.Progressive_Clawshot)
                && CanUseUtils.CanUse(Item.Ball_and_Chain);
        }
    }
}
