using TPRandomizer;
using Core = LogicFunctionsNS.CoreLogic.CanDefeatBoss;
using DifficultCombat = LogicFunctionsNS.DifficultCombatLogic.CanDefeatBoss;
using Glitched = LogicFunctionsNS.GlitchedLogic.CanDefeatBoss;
using Glitchless = LogicFunctionsNS.GlitchlessLogic.CanDefeatBoss;
using Niche = LogicFunctionsNS.NicheLogic.CanDefeatBoss;

namespace LogicFunctionsNS.AggregateLogic
{
    public class CanDefeatBoss
    {
        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDiababa()
        {
            return BombUtils.CanLaunchBombs()
                || (
                    CanUseUtils.CanUse(Item.Boomerang)
                    && (
                        Glitchless.CanDefeatDiababa()
                        || Niche.CanDefeatDiababa()
                        || DifficultCombat.CanDefeatDiababa()
                    )
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFyrus()
        {
            return Core.CanDefeatFyrus()
                && (Glitchless.CanDefeatFyrus() || DifficultCombat.CanDefeatFyrus());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMorpheel()
        {
            return Core.CanDefeatMorpheel()
                && (Glitchless.CanDefeatMorpheel() || Niche.CanDefeatMorpheel());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStallord()
        {
            return Glitchless.CanDefeatStallord() || DifficultCombat.CanDefeatStallord();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBlizzeta() => Glitchless.CanDefeatBlizzeta();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArmogohma() => Glitchless.CanDefeatArmogohma();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArgorok()
        {
            return Core.CanDefeatArgorok()
                && (Glitchless.CanDefeatArgorok() || Niche.CanDefeatArgorok());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatZant()
        {
            // Core && (Glitchless || Niche) && (Glitchless || Glitched)
            return Core.CanDefeatZant()
                && (CanUseUtils.CanUse(Item.Iron_Boots) || Niche.CanDefeatZant())
                && (CanUseUtils.CanUse(Item.Zora_Armor) || Glitched.CanDefeatZant());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGanondorf() => Glitchless.CanDefeatGanondorf();
    }
}
