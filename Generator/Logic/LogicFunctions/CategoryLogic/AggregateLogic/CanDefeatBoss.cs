using TPRandomizer;
using DCL = LogicFunctionsNS.DifficultCombatLogic.CanDefeatBoss;
using GL = LogicFunctionsNS.GlitchedLogic.CanDefeatBoss;
using GLL = LogicFunctionsNS.GlitchlessLogic.CanDefeatBoss;
using NL = LogicFunctionsNS.NicheLogic.CanDefeatBoss;

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
                    && (GLL.CanDefeatDiababa() || NL.CanDefeatDiababa() || DCL.CanDefeatDiababa())
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFyrus()
        {
            return CanUseUtilities.CanUse(Item.Progressive_Bow)
                && CanUseUtilities.CanUse(Item.Iron_Boots)
                && (GLL.CanDefeatFyrus() || DCL.CanDefeatFyrus());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMorpheel()
        {
            return CanUseUtilities.CanUse(Item.Progressive_Clawshot)
                && HasSwordLevel.HasSword()
                && (GLL.CanDefeatMorpheel() || NL.CanDefeatMorpheel());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStallord()
        {
            return GLL.CanDefeatStallord() || DCL.CanDefeatStallord();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBlizzeta() => GLL.CanDefeatBlizzeta();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArmogohma() => GLL.CanDefeatArmogohma();

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArgorok()
        {
            // TODO; current GLL is more like the core, while IB is unique to GLL. NL pretty correct tho
            return GLL.CanDefeatArgorok()
                && (CanUseUtilities.CanUse(Item.Iron_Boots) || NL.CanDefeatArgorok());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatZant()
        {
            // TODO: Again, current GLL is more like the core.
            return GLL.CanDefeatZant()
                && (CanUseUtilities.CanUse(Item.Iron_Boots) || NL.CanDefeatZant())
                && (CanUseUtilities.CanUse(Item.Zora_Armor) || GL.CanDefeatZant());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGanondorf() => GLL.CanDefeatGanondorf();
    }
}
