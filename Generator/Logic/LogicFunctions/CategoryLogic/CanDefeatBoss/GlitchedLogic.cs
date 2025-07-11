namespace LogicFunctionsNS.GlitchedLogic
{
    public class CanDefeatBoss
    {
        public static bool CanDefeatZant()
        {
            return SettingUtils.IsGlitchedLogic() && GlitchedLogicUtils.CanDoAirRefill();
        }
    }
}
