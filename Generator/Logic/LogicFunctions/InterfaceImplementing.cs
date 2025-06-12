// This is for the randomizer namespace to pass things off to the new
//   namespace

using LogicFunctionsNS;

namespace TPRandomizer
{
    // L for "Legacy"; temp name
    public class LSSettings : ISSettings
    {
        public static SharedSettings SSettings => Randomizer.SSettings;
    }
}
