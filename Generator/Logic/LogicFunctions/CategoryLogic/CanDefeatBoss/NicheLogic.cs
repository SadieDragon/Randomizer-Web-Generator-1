using TPRandomizer;

namespace LogicFunctionsNS.NicheLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatDiababa()
        {
            return SettingUtils.CanDoNicheStuff() && CanUseUtils.CanUse(Item.Iron_Boots);
        }

        public static bool CanDefeatMorpheel()
        {
            return SettingUtils.CanDoNicheStuff() && GlitchedLogicUtils.CanDoAirRefill();
        }

        public static bool CanDefeatArgorok() => NicheLogicUtils.CanUseMagicArmorNiche();

        public static bool CanDefeatZant() => NicheLogicUtils.CanUseMagicArmorNiche();
    }
}
