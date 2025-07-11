using TPRandomizer;
using Core = LogicFunctionsNS.CoreLogic.CanDefeatCommonEnemy;
using DifficultCombat = LogicFunctionsNS.DifficultCombatLogic.CanDefeatCommonEnemy;
using Glitched = LogicFunctionsNS.GlitchedLogic.CanDefeatCommonEnemy;
using Glitchless = LogicFunctionsNS.GlitchlessLogic.CanDefeatCommonEnemy;
using Niche = LogicFunctionsNS.NicheLogic.CanDefeatCommonEnemy;

// "extraRequirements":

namespace LogicFunctionsNS.AggregateLogic
{
    public class CanDefeatCommonEnemy
    {
        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatAeralfos()
        {
            return Core.CanDefeatAeralfos()
                && (Glitchless.CanDefeatAeralfos() || Niche.CanDefeatAeralfos());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatArmos()
        {
            return Glitchless.CanDefeatArmos() || Niche.CanDefeatArmos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabaSerpent()
        {
            return Glitchless.CanDefeatBabaSerpent() || Niche.CanDefeatBabaSerpent();
        }

        public static bool CanDefeatHangingBabaSerpent()
        {
            return Glitchless.CanDefeatHangingBabaSerpent() && CanDefeatBabaSerpent();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBabyGohma()
        {
            return Glitchless.CanDefeatBabyGohma() || Niche.CanDefeatBabyGohma();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBari()
        {
            return Glitchless.CanDefeatBari();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBeamos()
        {
            return Glitchless.CanDefeatBeamos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBigBaba()
        {
            return Glitchless.CanDefeatBigBaba() || Niche.CanDefeatBigBaba();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChu()
        {
            return Glitchless.CanDefeatChu() || Niche.CanDefeatChu();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBokoblin()
        {
            return Glitchless.CanDefeatBokoblin() || Niche.CanDefeatBokoblin();
        }

        public static bool CanDefeatBokoblinRed()
        {
            return Glitchless.CanDefeatBokoblinRed()
                || Niche.CanDefeatBokoblinRed()
                || DifficultCombat.CanDefeatBokoblinRed();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombfish()
        {
            return (Glitchless.CanDefeatBombfish() || Glitched.CanDefeatBombfish())
                && (
                    HasSwordLevel.HasSword()
                    || CanUseUtils.CanUse(Item.Progressive_Clawshot)
                    || MiscItemUtils.CanShieldAttack()
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBombling()
        {
            return Glitchless.CanDefeatBombling() || Niche.CanDefeatBombling();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBomskit()
        {
            return Glitchless.CanDefeatBomskit() || Niche.CanDefeatBomskit();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBubble()
        {
            return Glitchless.CanDefeatBubble() || Niche.CanDefeatBubble();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatBulblin()
        {
            return Glitchless.CanDefeatBulblin() || Niche.CanDefeatBulblin();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChilfos()
        {
            return Glitchless.CanDefeatChilfos() || Niche.CanDefeatChilfos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatChuWorm()
        {
            return (Glitchless.CanDefeatChuWorm() || Niche.CanDefeatChuWorm())
                && (BombUtils.HasBombs() || CanUseUtils.CanUse(Item.Progressive_Clawshot));
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDarknut()
        {
            return Glitchless.CanDefeatDarknut() || DifficultCombat.CanDefeatDarknut();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuBaba()
        {
            return Glitchless.CanDefeatDekuBaba() || Niche.CanDefeatDekuBaba();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDekuLike()
        {
            return Glitchless.CanDefeatDekuLike();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDodongo()
        {
            return Glitchless.CanDefeatDodongo() || Niche.CanDefeatDodongo();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatDinalfos()
        {
            return Glitchless.CanDefeatDinalfos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireBubble()
        {
            return Glitchless.CanDefeatFireBubble() || Niche.CanDefeatFireBubble();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireKeese()
        {
            return Glitchless.CanDefeatFireKeese() || Niche.CanDefeatFireKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFireToadpoli()
        {
            return Glitchless.CanDefeatFireToadpoli() || DifficultCombat.CanDefeatFireToadpoli();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatFreezard()
        {
            return Glitchless.CanDefeatFreezard();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGoron()
        {
            return Glitchless.CanDefeatGoron()
                || Niche.CanDefeatGoron()
                || DifficultCombat.CanDefeatGoron();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGhoulRat()
        {
            return Glitchless.CanDefeatGhoulRat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatGuay()
        {
            return Glitchless.CanDefeatGuay()
                || Niche.CanDefeatGuay()
                || DifficultCombat.CanDefeatGuay();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaur()
        {
            return Glitchless.CanDefeatHelmasaur() || Niche.CanDefeatHelmasaur();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatHelmasaurus()
        {
            return Glitchless.CanDefeatHelmasaurus() || Niche.CanDefeatHelmasaurus();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceBubble()
        {
            return Glitchless.CanDefeatIceBubble();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatIceKeese()
        {
            return Glitchless.CanDefeatIceKeese() || Niche.CanDefeatIceKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoe()
        {
            return Glitchless.CanDefeatPoe();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKargarok()
        {
            return Glitchless.CanDefeatKargarok() || Niche.CanDefeatKargarok();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatKeese()
        {
            return Glitchless.CanDefeatKeese() || Niche.CanDefeatKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLeever()
        {
            return Glitchless.CanDefeatLeever() || Niche.CanDefeatLeever();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatLizalfos()
        {
            return Glitchless.CanDefeatLizalfos() || Niche.CanDefeatLizalfos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMiniFreezard()
        {
            return Glitchless.CanDefeatMiniFreezard() || Niche.CanDefeatMiniFreezard();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatMoldorm()
        {
            return Glitchless.CanDefeatMoldorm() || Niche.CanDefeatMoldorm();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPoisonMite()
        {
            return Glitchless.CanDefeatPoisonMite();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatPuppet()
        {
            return Glitchless.CanDefeatPuppet() || Niche.CanDefeatPuppet();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRat()
        {
            return Glitchless.CanDefeatRat() || Niche.CanDefeatRat();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatRedeadKnight()
        {
            return Glitchless.CanDefeatRedeadKnight() || Niche.CanDefeatRedeadKnight();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowBeast()
        {
            // MidnaCharge needs to be made a can do stuff
            return HasSwordLevel.HasSword()
                || (
                    CanUseUtils.CanUse(Item.Shadow_Crystal)
                    && LogicFunctionsUpdatedRefactored.CanMidnaCharge()
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowBulblin()
        {
            return Glitchless.CanDefeatShadowBulblin() || Niche.CanDefeatShadowBulblin();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowDekuBaba()
        {
            return Glitchless.CanDefeatShadowDekuBaba() || Niche.CanDefeatShadowDekuBaba();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowInsect()
        {
            return Glitchless.CanDefeatShadowInsect();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKargarok()
        {
            return Glitchless.CanDefeatShadowKargarok() || Niche.CanDefeatShadowKargarok();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowKeese()
        {
            return Glitchless.CanDefeatShadowKeese() || Niche.CanDefeatShadowKeese();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShadowVermin()
        {
            return Glitchless.CanDefeatShadowVermin() || Niche.CanDefeatShadowVermin();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatShellBlade()
        {
            return BombUtils.CanUseWaterBombs()
                || (
                    HasSwordLevel.HasSword()
                    && (Glitchless.CanDefeatShellBlade() || Niche.CanDefeatShellBlade())
                );
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkullfish()
        {
            return Glitchless.CanDefeatSkullfish() || Niche.CanDefeatSkullfish();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatSkulltula()
        {
            return Glitchless.CanDefeatSkulltula() || Niche.CanDefeatSkulltula();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalfos()
        {
            return Glitchless.CanDefeatStalfos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalhound()
        {
            return Glitchless.CanDefeatStalhound() || Niche.CanDefeatStalhound();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatStalchild()
        {
            return Glitchless.CanDefeatStalchild() || Niche.CanDefeatStalchild();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTektite()
        {
            return Glitchless.CanDefeatTektite() || Niche.CanDefeatTektite();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTileWorm()
        {
            return CanUseUtils.CanUse(Item.Boomerang)
                && (Glitchless.CanDefeatTileWorm() || Niche.CanDefeatTileWorm());
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatToado()
        {
            return Glitchless.CanDefeatToado();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWaterToadpoli()
        {
            return Glitchless.CanDefeatWaterToadpoli() || DifficultCombat.CanDefeatWaterToadpoli();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatTorchSlug()
        {
            return Glitchless.CanDefeatTorchSlug();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWalltula()
        {
            return Glitchless.CanDefeatWalltula();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatWhiteWolfos()
        {
            return Glitchless.CanDefeatWhiteWolfos() || Niche.CanDefeatWhiteWolfos();
        }

        /// <summary>
        /// summary text.
        /// </summary>
        public static bool CanDefeatYoungGohma()
        {
            return Glitchless.CanDefeatYoungGohma() || Niche.CanDefeatYoungGohma();
        }
    }
}
