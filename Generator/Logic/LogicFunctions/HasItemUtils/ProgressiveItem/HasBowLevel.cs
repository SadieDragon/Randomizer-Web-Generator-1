using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtilities;

namespace LogicFunctionsNS
{
    public class HasBowLevel
    {
        private enum BowLevel
        {
            Bow = 1,
            MediumQuiver = 2,
            LargeQuiver = 3,
        }

        private static int CurrentBowCount()
        {
            return CUU.GetItemCount(Item.Progressive_Bow);
        }

        // I don't expect this to get much use but eh I'll put it in here.
        public static bool HasBow()
        {
            return CurrentBowCount() >= (int)BowLevel.Bow;
        }

        public static bool HasMediumQuiver()
        {
            return CurrentBowCount() >= (int)BowLevel.MediumQuiver;
        }

        public static bool HasLargeQuiver()
        {
            return CurrentBowCount() >= (int)BowLevel.LargeQuiver;
        }
    }
}
