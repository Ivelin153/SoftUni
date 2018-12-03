namespace DungeonsAndCodeWizards.Entities.Characters
{
    using DungeonsAndCodeWizards.Entities.Bags;
    using DungeonsAndCodeWizards.Entities.Contracts;
    using System;

    public class Warrior : Character, IAttackable
    {
        public const int WarriorBaseHealth = 100;
        public const int WarriorBaseArmor = 50;
        public const int WarriorAbilityPoints = 40;
        public Warrior(string name, Faction faction)
            : base(name, WarriorBaseHealth, WarriorBaseArmor, WarriorAbilityPoints, new Satchel(), faction)
        {
            this.Health = WarriorBaseHealth;
            this.Armor = WarriorBaseArmor;
            this.AbilityPoints = WarriorAbilityPoints;
            this.RestHealMultiplier = 0.2;
        }

        public void Attack(Character character)
        {
            if (this.IsAlive == false || character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            if (this == character)
            {
                throw new InvalidOperationException("Invalid Operation: Cannot attack self!");
            }
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }
            character.TakeDamage(this.AbilityPoints);
        }
    }
}
