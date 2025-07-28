// "These are item utils" but they have no home.

using System.Linq;
using TPRandomizer;
using TPRandomizer.SSettings.Enums;

namespace LogicFunctionsNS
{
    public class CanUseItemUtils
    {
        public static bool HasShield()
        {
            return CanUseUtils.CanUse(Item.Hylian_Shield)
                || ERLogicFunctions.CanShopFromRoom("Kakariko Malo Mart")
                || ERLogicFunctions.CanShopFromRoom("Castle Town Goron House")
                || ERLogicFunctions.HasReachedRoom("Death Mountain Hot Spring");
        }

        public static bool CanShieldAttack()
        {
            return HasShield() && HasHiddenSkillLevel.HasShieldAttack();
        }

        public static bool CanBurnWebs()
        {
            return CanUseUtils.CanUse(Item.Lantern)
                || BombUtils.HasBombs()
                || CanUseUtils.CanUse(Item.Ball_and_Chain);
        }

        public static bool HasRangedItem()
        {
            return CanUseUtils.CanUse(Item.Ball_and_Chain)
                || CanUseUtils.CanUse(Item.Slingshot)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || CanUseUtils.CanUse(Item.Boomerang);
        }

        public static bool CanCutHangingWeb()
        {
            return CanUseUtils.CanUse(Item.Progressive_Clawshot)
                || CanUseUtils.CanUse(Item.Progressive_Bow)
                || CanUseUtils.CanUse(Item.Boomerang)
                || CanUseUtils.CanUse(Item.Ball_and_Chain);
        }

        public static bool HasBug()
        {
            return Randomizer.Items.goldenBugs.Any(CanUseUtils.CanUse);
        }

        public static bool CanBuyMagicArmor()
        {
            switch (Randomizer.SSettings.walletSize)
            {
                case WalletSize.Reduced:
                {
                    return CanUseUtils.GetItemCount(Item.Progressive_Wallet) >= 2;
                }
                case WalletSize.Vanilla:
                {
                    return CanUseUtils.CanUse(Item.Progressive_Wallet);
                }
                default:
                {
                    return true;
                }
            }
        }
    }
}
