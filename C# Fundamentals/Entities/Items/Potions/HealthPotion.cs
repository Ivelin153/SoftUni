namespace DungeonsAndCodeWizards.Entities.Items
{
    using DungeonsAndCodeWizards.Entities.Characters;
    using System;
    
    public class HealthPotion : Item
    {
        private const int HealthPotionWeight = 5;
        public HealthPotion()
            : base(HealthPotionWeight)
        {
        }

        public override string Name => "HealthPotion";

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive == true)
                character.Health += 20;
            else
                throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }
}
