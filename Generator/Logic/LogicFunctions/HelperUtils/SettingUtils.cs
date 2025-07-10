using System.Reflection;
using TPRandomizer;
using TPRandomizer.SSettings.Enums;

namespace LogicFunctionsNS
{
    public class SettingUtils
    {
        private static readonly SharedSettings SharedSettings = Randomizer.SSettings;

        public static bool EvaluateSetting(string setting, string value)
        {
            PropertyInfo[] settingProperties = SharedSettings.GetType().GetProperties();
            setting = setting.Replace("Setting.", "");

            foreach (PropertyInfo property in settingProperties)
            {
                var settingValue = property.GetValue(SharedSettings, null);
                if ((property.Name == setting) && (value == settingValue.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsGlitchedLogic()
        {
            return SharedSettings.logicRules == LogicRules.Glitched;
        }

        /// <sumamry>
        /// Checks the setting for niche stuff. Niche stuff includes things that may not be obvious to most players, such as damaging enemies with boots, lantern on Gorons, drained Magic Armor for heavy mod, etc.
        /// </summary>
        public static bool CanDoNicheStuff()
        {
            // TODO: Change to use setting once it is made
            return IsGlitchedLogic();
        }

        /// <summary>
        /// Checks the setting for difficult combat. Difficult combat includes: difficult, annoying, or time consuming combat
        /// </summary>
        public static bool CanDoDifficultCombat()
        {
            // TODO: Change to use setting once it's made
            return false;
        }

        public static bool BonksDamageEnabled() => SharedSettings.bonksDoDamage;

        public static bool CanStrikePedestal()
        {
            return HasSwordLevel.CurrentSwordLevel() >= (int)SharedSettings.totEntrance;
        }

        public static bool HasSkippedPrologue() => SharedSettings.skipPrologue;

        public static bool HasSkippedFaronTwilight() => SharedSettings.faronTwilightCleared;

        public static bool HasSkippedEldinTwilight() => SharedSettings.eldinTwilightCleared;

        public static bool HasSkippedLanayruTwilight() => SharedSettings.lanayruTwilightCleared;

        public static bool HasSkippedMDH() => SharedSettings.skipMdh;

        public static bool HasSkippedSnowpeakEntrance() => SharedSettings.skipSnowpeakEntrance;

        public static bool IsKeysy()
        {
            return SharedSettings.smallKeySettings == SmallKeySettings.Keysy;
        }

        public static bool IsOHKO()
        {
            return SharedSettings.damageMagnification == DamageMagnification.OHKO;
        }

        public static bool IsOpenMap() => SharedSettings.openMap;

        public static bool IsShopSanity() => SharedSettings.shuffleShopItems;

        public static bool IsOpenWoods()
        {
            return SharedSettings.faronWoodsLogic == FaronWoodsLogic.Open;
        }
    }
}
