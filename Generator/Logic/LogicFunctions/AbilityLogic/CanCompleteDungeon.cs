/// POTENTIAL BUG: `StackOverflow` bug- found on `CanDefeatGoronMines`.
/// SOLUTION: `HasDefeatedBoss`- which repeats `CanUse`
/// Explanation: For some reason, calling `CanUse` in this file leads to a `StackOverflow` bug,
///   which I have narrowed down to when `CanUse` calls `CanReplenish`, which in both functions
///   calls `CanDefeatGoronMines`. I have 2 solutions for that, both adding back repeated code,
///   but making the wrapper here is the easiest solution of the 2.
using TPRandomizer;

namespace LogicFunctionsNS
{
    public static class CanCompleteDungeon
    {
        private static bool HasDefeatedBoss(Item boss) => Randomizer.Items.heldItems.Contains(boss);

        public static bool CanCompleteForestTemple()
        {
            return HasDefeatedBoss(Item.Diababa_Defeated);
        }

        public static bool CanCompleteGoronMines() => HasDefeatedBoss(Item.Fyrus_Defeated);

        public static bool CanCompleteLakebedTemple()
        {
            return HasDefeatedBoss(Item.Morpheel_Defeated);
        }

        public static bool CanCompleteArbitersGrounds()
        {
            return HasDefeatedBoss(Item.Stallord_Defeated);
        }

        public static bool CanCompleteSnowpeakRuins()
        {
            return HasDefeatedBoss(Item.Blizzeta_Defeated);
        }

        public static bool CanCompleteTempleofTime()
        {
            return HasDefeatedBoss(Item.Armogohma_Defeated);
        }

        public static bool CanCompleteCityinTheSky()
        {
            return HasDefeatedBoss(Item.Argorok_Defeated);
        }

        public static bool CanCompletePalaceofTwilight()
        {
            return HasDefeatedBoss(Item.Zant_Defeated);
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
