using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtils;

namespace LogicFunctionsNS
{
    public class HasSwordLevel
    {
        private enum SwordLevel
        {
            Wooden = 1,
            Ordon = 2,
            Master = 3,
            Light = 4,
        }

        public static int CurrentSwordLevel()
        {
            return CUU.GetItemCount(Item.Progressive_Sword);
        }

        public static bool HasSword()
        {
            return HasWoodenSword();
        }

        public static bool HasWoodenSword()
        {
            return CurrentSwordLevel() >= (int)SwordLevel.Wooden;
        }

        public static bool HasOrdonSword()
        {
            return CurrentSwordLevel() >= (int)SwordLevel.Ordon;
        }

        public static bool HasMasterSword()
        {
            return CurrentSwordLevel() >= (int)SwordLevel.Master;
        }
    }
}
