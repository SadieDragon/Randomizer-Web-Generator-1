// This is for the new namespace to get things from the old namespace

namespace LogicFunctionsNS
{
    public interface ISSettings
    {
        static TPRandomizer.SharedSettings SSettings { get; }
    }
}
