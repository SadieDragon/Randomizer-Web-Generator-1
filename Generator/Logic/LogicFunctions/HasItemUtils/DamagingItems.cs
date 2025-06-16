using System.Collections.Generic;
using System.Linq;
using TPRandomizer;
using BU = LogicFunctionsNS.BombUtils;
using CUU = LogicFunctionsNS.CanUseUtilities;

// using HF = LogicFunctionsNS.HelperFunctions;

namespace LogicFunctionsNS
{
    public class DamagingItems
    {
        private static readonly List<Item> BaseDIList =
        [
            Item.Progressive_Sword,
            Item.Ball_and_Chain,
            Item.Progressive_Bow,
            Item.Shadow_Crystal,
            Item.Spinner,
        ];

        public static bool HasAnyDamagingItem(List<Item> listOfItems)
        {
            return listOfItems.Any(CUU.CanUse);
        }

        public static bool HasBaseDamagingItem()
        {
            return HasAnyDamagingItem(BaseDIList);
        }

        // TODO: better name
        public static bool HasDamagingItem(bool includeBombs = true, params Item[] extraItems)
        {
            // Not sure this is better yet; leaving it in so I can see it - Lupa
            // return HF.AnyTrue(
            //     HasBaseDamagingItem,
            //     () => includeBombs && BU.HasBombs(),
            //     () => HasAnyDamagingItem(extraItems.ToList())
            // );

            return HasBaseDamagingItem()
                || (includeBombs && BU.HasBombs())
                // [.. extraItems] is suggested; is this valid?? Can't find info - Lupa
                // Need to convert to a proper list; won't change the other fn's param typing
                || HasAnyDamagingItem(extraItems.ToList());
        }

        public static bool HasDamagingItemOrClawshot(bool includeBombs = true)
        {
            return HasDamagingItem(includeBombs, Item.Progressive_Clawshot);
        }

        public static bool HasDamagingItemOrSlingshot(bool includeBombs = true)
        {
            return HasDamagingItem(includeBombs, Item.Slingshot);
        }
    }
}
