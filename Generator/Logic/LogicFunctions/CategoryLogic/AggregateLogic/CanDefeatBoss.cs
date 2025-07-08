using TPRandomizer;
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
                    CanUseUtilities.CanUse(Item.Boomerang)
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
            return CanUseUtilities.CanUse(Item.Progressive_Bow)
                && CanUseUtilities.CanUse(Item.Iron_Boots)
                && (Glitchless.CanDefeatFyrus() || DifficultCombat.CanDefeatFyrus());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMorpheel()
        {
            return CanUseUtilities.CanUse(Item.Progressive_Clawshot)
                && HasSwordLevel.HasSword()
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
            // TODO; current Glitchless is more like the core, while IB is unique to Glitchless. Niche pretty correct tho
            return Glitchless.CanDefeatArgorok()
                && (CanUseUtilities.CanUse(Item.Iron_Boots) || Niche.CanDefeatArgorok());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatZant()
        {
            // TODO: Again, current Glitchless is more like the core.
            return Glitchless.CanDefeatZant()
                && (CanUseUtilities.CanUse(Item.Iron_Boots) || Niche.CanDefeatZant())
                && (CanUseUtilities.CanUse(Item.Zora_Armor) || Glitched.CanDefeatZant());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGanondorf() => Glitchless.CanDefeatGanondorf();
    }
}
