using System.Reflection;
using TPRandomizer;
using TPRandomizer.SSettings.Enums;

namespace LogicFunctionsNS
{
    public class SettingUtils
    {
        private static readonly SharedSettings sharedSettings = Randomizer.SSettings;

        public static bool EvaluateSetting(string setting, string value)
        {
            PropertyInfo[] settingProperties = sharedSettings.GetType().GetProperties();
            setting = setting.Replace("Setting.", "");

            foreach (PropertyInfo property in settingProperties)
            {
                var settingValue = property.GetValue(sharedSettings, null);
                if ((property.Name == setting) && (value == settingValue.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsGlitchedLogic()
        {
            return sharedSettings.logicRules == LogicRules.Glitched;
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

        public static bool BonksDamageEnabled() => sharedSettings.bonksDoDamage;

        public static bool CanStrikePedestal()
        {
            return HasSwordLevel.CurrentSwordLevel() >= (int)sharedSettings.totEntrance;
        }

        public static bool HasSkippedPrologue() => sharedSettings.skipPrologue;

        public static bool HasSkippedFaronTwilight() => sharedSettings.faronTwilightCleared;

        public static bool HasSkippedEldinTwilight() => sharedSettings.eldinTwilightCleared;

        public static bool HasSkippedLanayruTwilight() => sharedSettings.lanayruTwilightCleared;

        public static bool HasSkippedMDH() => sharedSettings.skipMdh;

        public static bool HasSkippedSnowpeakEntrance() => sharedSettings.skipSnowpeakEntrance;

        public static bool IsKeysy()
        {
            return sharedSettings.smallKeySettings == SmallKeySettings.Keysy;
        }

        public static bool IsOHKO()
        {
            return sharedSettings.damageMagnification == DamageMagnification.OHKO;
        }

        public static bool IsOpenMap() => sharedSettings.openMap;

        public static bool IsShopSanity() => sharedSettings.shuffleShopItems;

        public static bool IsOpenWoods()
        {
            return sharedSettings.faronWoodsLogic == FaronWoodsLogic.Open;
        }
    }
}
