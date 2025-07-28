using TPRandomizer;

namespace LogicFunctionsNS
{
    public static class CanDoStoryStuff
    {
        public static bool CanCompletePrologue()
        {
            return SettingUtils.HasSkippedPrologue()
                || (
                    ERLogicFunctions.HasReachedRoom("North Faron Woods")
                    && CanDefeatCommonEnemy.CanDefeatBokoblin()
                );
        }

        public static bool CanCompleteGoats1()
        {
            return CanCompletePrologue() || ERLogicFunctions.HasReachedRoom("Ordon Ranch");
        }

        public static bool CanClearForest()
        {
            return (CanCompleteDungeon.CanCompleteForestTemple() || SettingUtils.IsOpenWoods())
                && CanCompletePrologue()
                && CanCompleteTwilight.CanCompleteFaronTwilight();
        }

        public static bool CanWarpMeteor()
        {
            return CanCompleteTwilight.CanCompleteLanayruTwilight()
                || (
                    CanCompleteTwilight.CanCompleteEldinTwilight()
                    && ERLogicFunctions.HasReachedRoom("Zoras Domain Throne Room")
                    && CanUseUtils.CanUse(Item.Shadow_Crystal)
                );
        }

        public static bool CanCompleteMDH()
        {
            return SettingUtils.HasSkippedMDH()
                || (
                    CanCompleteDungeon.CanCompleteLakebedTemple()
                    && ERLogicFunctions.HasReachedRoom("Castle Town South")
                );
        }

        #region Glitched
        public static bool CanClearForestGlitched()
        {
            return CanCompletePrologue()
                && (
                    SettingUtils.IsOpenWoods()
                    || CanCompleteDungeon.CanCompleteForestTemple()
                    || GlitchedLogicUtils.CanDoLJA()
                    || GlitchedLogicUtils.CanDoMapGlitch()
                );
        }

        public static bool CanDoHiddenVillageGlitched()
        {
            return CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Ball_and_Chain)
                || (
                    CanUseUtils.CanUse(Item.Slingshot)
                    && (
                        CanUseUtils.CanUse(Item.Shadow_Crystal)
                        || HasSwordLevel.HasSword()
                        || BombUtils.HasBombs()
                        || CanUseUtils.CanUse(Item.Iron_Boots)
                        || CanUseUtils.CanUse(Item.Spinner)
                    )
                );
        }
        #endregion
    }
}
