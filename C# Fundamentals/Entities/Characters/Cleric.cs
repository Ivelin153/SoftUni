namespace DungeonsAndCodeWizards.Entities.Characters
{
    using DungeonsAndCodeWizards.Entities.Bags;
    using DungeonsAndCodeWizards.Entities.Contracts;
    using System;

    public class Cleric : Character, IHealable
    {
        public const int ClericBaseHealth = 50;
        public const int ClericBaseArmor = 25;
        public const int ClericAbilityPoints = 40;
        public const double ClericRestHealMultiplier = 0.5;

        public Cleric(string name, Faction faction)
            : base(name, ClericBaseHealth, ClericBaseArmor, ClericAbilityPoints, new Backpack(), faction)
        {
            this.RestHealMultiplier = ClericRestHealMultiplier;
        }

        public void Heal(Character character)
        {
            if (this.IsAlive == false || character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException($"Cannot heal enemy character!");
            }
            character.Health += AbilityPoints;
        }
    }
}
