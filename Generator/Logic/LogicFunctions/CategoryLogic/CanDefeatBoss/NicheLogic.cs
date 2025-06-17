using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtilities;
using GLU = LogicFunctionsNS.GlitchedLogicUtils;
using NLU = LogicFunctionsNS.NicheLogicUtils;

namespace LogicFunctionsNS.NicheLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatDiababa()
        {
            return NLU.CanDoNicheStuff() && CUU.CanUse(Item.Iron_Boots);
        }

        public static bool CanDefeatMorpheel()
        {
            return NLU.CanDoNicheStuff() && GLU.CanDoAirRefill();
        }

        public static bool CanDefeatArgorok() => NLU.CanUseMagicArmorNiche();

        public static bool CanDefeatZant() => NLU.CanUseMagicArmorNiche();
    }
}
