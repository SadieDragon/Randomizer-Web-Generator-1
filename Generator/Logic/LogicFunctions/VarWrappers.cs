// This is trying to wrap vars that are used from the TPR namespace,
//   though it perhaps could be skipped. Mainly for readability.

using TPRandomizer;
using TPRandomizer.SSettings.Enums;

namespace LogicFunctions
{
    class VarWrappers
    {
        public static SharedSettings SharedSettings = Randomizer.SSettings;

        // SharedSettings.GetType().GetProperties() - 1

        public static bool IsGlitchedLogic = SharedSettings.logicRules == LogicRules.Glitched;

        public static bool ShopsanityEnabled = SharedSettings.shuffleShopItems;

        public static bool IsKeysy = SharedSettings.smallKeySettings == SmallKeySettings.Keysy;

        public static bool BonksDamageEnabled = SharedSettings.bonksDoDamage;
        public static bool IsOHKO = SharedSettings.damageMagnification == DamageMagnification.OHKO;

        public static bool IsOpenMap = SharedSettings.openMap;
        public static bool IsOpenFaronWoods =
            SharedSettings.faronWoodsLogic == FaronWoodsLogic.Open;
        public static bool EldingTwilightCleared = SharedSettings.eldinTwilightCleared;
    }
}
