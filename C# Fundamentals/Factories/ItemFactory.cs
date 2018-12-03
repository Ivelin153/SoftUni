namespace DungeonsAndCodeWizards.Factories
{
    using DungeonsAndCodeWizards.Entities.Items;
    using DungeonsAndCodeWizards.Entities.Items.Potions;
    using System;
    public class ItemFactory
    {

        /*If you try to create a character with an invalid type,
         * throw an ArgumentException with a message 
         * “Invalid item type "{type}"!”.*/
        public Item CreateItem(string[] args)
        {
            var itemType = args[0];

            switch (itemType)
            {
                case "HealthPotion":
                    return new HealthPotion();

                case "PoisonPotion":
                    return new PoisonPotion();

                case "ArmorRepairKit":
                    return new ArmorRepairKit();

                default:
                    throw new ArgumentException($"Parameter Error: Invalid item " + itemType + "!");

            }
        }
    }
}
