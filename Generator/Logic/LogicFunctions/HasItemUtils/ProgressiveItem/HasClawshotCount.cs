using TPRandomizer;

namespace LogicFunctionsNS
{
    public static class HasClawshotCount
    {
        private static int CountClawshot() => CanUseUtils.GetItemCount(Item.Progressive_Clawshot);

        public static bool HasSingleClawshot() => CountClawshot() == 1;

        public static bool HasDoubleClawshot() => CountClawshot() == 2;
    }
}
