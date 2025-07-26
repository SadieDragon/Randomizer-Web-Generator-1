using TPRandomizer;

namespace LogicFunctionsNS
{
    public class HasQuiverSize
    {
        private enum QuiverSize
        {
            Bow = 1,
            MediumQuiver = 2,
            LargeQuiver = 3,
        }

        private static int CurrentQuiverSize()
        {
            return CanUseUtils.GetItemCount(Item.Progressive_Bow);
        }

        public static bool HasBow()
        {
            return CurrentQuiverSize() >= (int)QuiverSize.Bow;
        }

        public static bool HasMediumQuiver()
        {
            return CurrentQuiverSize() >= (int)QuiverSize.MediumQuiver;
        }

        public static bool HasLargeQuiver()
        {
            return CurrentQuiverSize() >= (int)QuiverSize.LargeQuiver;
        }
    }
}
