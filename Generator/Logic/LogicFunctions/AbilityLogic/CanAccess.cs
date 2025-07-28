using System.Linq;
using TPRandomizer;
using TPRandomizer.SSettings.Enums;

namespace LogicFunctionsNS
{
    public static class CanAccess
    {
        private static readonly SharedSettings sharedSettings = SettingUtils.sharedSettings;

        public static bool CanBreakHCBarrier()
        {
            int requirementCount = sharedSettings.castleRequirementCount;

            switch (sharedSettings.castleRequirements)
            {
                case CastleRequirements.Open:
                {
                    return true;
                }
                case CastleRequirements.Fused_Shadows:
                {
                    return CanUseUtils.VerifyItemQuantity(
                        Item.Progressive_Fused_Shadow,
                        requirementCount
                    );
                }
                case CastleRequirements.Mirror_Shards:
                {
                    return CanUseUtils.VerifyItemQuantity(
                        Item.Progressive_Mirror_Shard,
                        requirementCount
                    );
                }
                case CastleRequirements.Dungeons:
                {
                    return Randomizer.Items.BossItems.Count(CanUseUtils.CanUse) >= requirementCount;
                }
                case CastleRequirements.Vanilla:
                {
                    return CanCompleteDungeon.CanCompletePalaceofTwilight();
                }
                case CastleRequirements.Poe_Souls:
                {
                    return CanUseUtils.VerifyItemQuantity(Item.Poe_Soul, requirementCount);
                }
                case CastleRequirements.Hearts:
                {
                    return HelperFunctions.GetPlayerHealth() >= requirementCount;
                }
            }

            return false;
        }

        public static bool CanOpenHCBKGate()
        {
            int requirementCount = sharedSettings.castleBKRequirementCount;

            switch (sharedSettings.castleBKRequirements)
            {
                case CastleBKRequirements.None:
                {
                    return true;
                }
                case CastleBKRequirements.Fused_Shadows:
                {
                    return CanUseUtils.VerifyItemQuantity(
                        Item.Progressive_Fused_Shadow,
                        requirementCount
                    );
                }
                case CastleBKRequirements.Mirror_Shards:
                {
                    return CanUseUtils.VerifyItemQuantity(
                        Item.Progressive_Mirror_Shard,
                        requirementCount
                    );
                }
                case CastleBKRequirements.Dungeons:
                {
                    return Randomizer.Items.BossItems.Count(CanUseUtils.CanUse) >= requirementCount;
                }
                case CastleBKRequirements.Poe_Souls:
                {
                    return CanUseUtils.VerifyItemQuantity(Item.Poe_Soul, requirementCount);
                }
                case CastleBKRequirements.Hearts:
                {
                    return HelperFunctions.GetPlayerHealth() >= requirementCount;
                }
            }

            return false;
        }
    }
}
