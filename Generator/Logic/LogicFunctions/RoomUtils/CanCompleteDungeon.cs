using TPRandomizer;

namespace LogicFunctionsNS
{
    public static class CanCompleteDungeon
    {
        public static bool CanCompleteForestTemple()
        {
            return CanUseUtilities.CanUse(Item.Diababa_Defeated);
        }

        public static bool CanCompleteGoronMines() => CanUseUtilities.CanUse(Item.Fyrus_Defeated);

        public static bool CanCompleteLakebedTemple()
        {
            return CanUseUtilities.CanUse(Item.Morpheel_Defeated);
        }

        public static bool CanCompleteArbitersGrounds()
        {
            return CanUseUtilities.CanUse(Item.Stallord_Defeated);
        }

        public static bool CanCompleteSnowpeakRuins()
        {
            return CanUseUtilities.CanUse(Item.Blizzeta_Defeated);
        }

        public static bool CanCompleteTempleofTime()
        {
            return CanUseUtilities.CanUse(Item.Armogohma_Defeated);
        }

        public static bool CanCompleteCityinTheSky()
        {
            return CanUseUtilities.CanUse(Item.Argorok_Defeated);
        }

        public static bool CanCompletePalaceofTwilight()
        {
            return CanUseUtilities.CanUse(Item.Zant_Defeated);
        }

        public static bool CanCompleteAllDungeons()
        {
            return CanCompleteForestTemple()
                && CanCompleteGoronMines()
                && CanCompleteLakebedTemple()
                && CanCompleteArbitersGrounds()
                && CanCompleteSnowpeakRuins()
                && CanCompleteTempleofTime()
                && CanCompleteCityinTheSky()
                && CanCompletePalaceofTwilight();
        }
    }
}
