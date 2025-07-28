using System;
using TPRandomizer;

namespace LogicFunctionsNS
{
    public class HelperFunctions
    {
        public static Item ConvertStrToItem(string item) => Enum.Parse<Item>(item);

        public static int GetPlayerHealth()
        {
            double playerHealth = 3.0; // start at 3 since we have 3 hearts.

            //Pieces of heart are 1/5 of a heart.
            playerHealth += CanUseUtils.GetItemCount(Item.Piece_of_Heart) * 0.2;
            playerHealth += CanUseUtils.GetItemCount(Item.Heart_Container);

            return (int)playerHealth;
        }
    }
}
