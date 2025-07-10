using System.Reflection;
using TPRandomizer;

namespace LogicFunctionsNS
{
    public class SettingUtils
    {
        public static bool EvaluateSetting(string setting, string value)
        {
            PropertyInfo[] settingProperties = Randomizer.SSettings.GetType().GetProperties();
            setting = setting.Replace("Setting.", "");

            foreach (PropertyInfo property in settingProperties)
            {
                var settingValue = property.GetValue(Randomizer.SSettings, null);
                if ((property.Name == setting) && (value == settingValue.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
