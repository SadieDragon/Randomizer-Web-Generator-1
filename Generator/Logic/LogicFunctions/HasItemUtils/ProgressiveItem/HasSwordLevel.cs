using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtilities;

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

        private static int CurrentSwordLevel()
        {
            return CUU.GetItemCount(Item.Progressive_Sword);
        }

        public static bool CanStrikePedestal()
        {
            return CurrentSwordLevel() >= (int)Randomizer.SSettings.totEntrance;
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
