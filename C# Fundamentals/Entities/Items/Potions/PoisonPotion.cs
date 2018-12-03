namespace DungeonsAndCodeWizards.Entities.Items.Potions
{

    using DungeonsAndCodeWizards.Entities.Characters;
    using System;

    public class PoisonPotion : Item
    {
        private const int PoisonPotionWeight = 5;

        public PoisonPotion()
            : base(PoisonPotionWeight)
        {
        }

        public override string Name => "PoisonPotion";

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive == true)
            {
                character.Health -= 20;                
            }
            else
                throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }
}
