using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtils;
using GLU = LogicFunctionsNS.GlitchedLogicUtils;
using NLU = LogicFunctionsNS.NicheLogicUtils;

namespace LogicFunctionsNS.NicheLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatDiababa()
        {
            return SettingUtils.CanDoNicheStuff() && CUU.CanUse(Item.Iron_Boots);
        }

        public static bool CanDefeatMorpheel()
        {
            return SettingUtils.CanDoNicheStuff() && GLU.CanDoAirRefill();
        }

        public static bool CanDefeatArgorok() => NLU.CanUseMagicArmorNiche();

        public static bool CanDefeatZant() => NLU.CanUseMagicArmorNiche();
    }
}
