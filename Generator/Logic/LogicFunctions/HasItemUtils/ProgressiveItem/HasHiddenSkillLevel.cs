using TPRandomizer;
using CUU = LogicFunctionsNS.CanUseUtils;

namespace LogicFunctionsNS
{
    public class HasHiddenSkillLevel
    {
        private enum HiddenSkillLevel
        {
            EndingBlow = 1,
            ShieldAttack = 2,
            BackSlice = 3,
            HelmSplitter = 4,
            MortalDraw = 5,
            JumpStrike = 6,
            GreatSpin = 7,
        }

        private static int CurrentHiddenSkillLevel()
        {
            return CUU.GetItemCount(Item.Progressive_Hidden_Skill);
        }

        public static bool HasEndingBlow()
        {
            return CurrentHiddenSkillLevel() >= (int)HiddenSkillLevel.EndingBlow;
        }

        public static bool HasShieldAttack()
        {
            return CurrentHiddenSkillLevel() >= (int)HiddenSkillLevel.ShieldAttack;
        }

        public static bool HasBackslice()
        {
            return CurrentHiddenSkillLevel() >= (int)HiddenSkillLevel.BackSlice;
        }

        public static bool HasHelmSplitter()
        {
            return CurrentHiddenSkillLevel() >= (int)HiddenSkillLevel.HelmSplitter;
        }

        public static bool HasJumpStrike()
        {
            return CurrentHiddenSkillLevel() >= (int)HiddenSkillLevel.JumpStrike;
        }
    }
}
