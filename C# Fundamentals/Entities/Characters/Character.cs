namespace DungeonsAndCodeWizards.Entities.Characters
{
    using DungeonsAndCodeWizards.Entities.Bags;
    using DungeonsAndCodeWizards.Entities.Items;
    using System;

    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                {
                    this.health = 0;
                }
                else if (value <= BaseHealth)
                {
                    this.health = value;
                }
                else
                {
                    this.health = BaseHealth;
                }
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get { return armor; }
            set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                else if (value <= BaseArmor)
                {
                    this.armor = value;
                }
                else
                {
                    this.armor = BaseArmor;
                }
            }
        }

        public double AbilityPoints { get; set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; private set; }

        public bool IsAlive { get; private set; }

        public double RestHealMultiplier { get; protected set; }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            var lastArmorValue = Armor;
            this.Armor -= hitPoints;
            hitPoints = hitPoints - lastArmorValue;

            if (hitPoints > 0)
            {
                this.Health -= hitPoints;
            }
            if (Health <= 0)
            {
                IsAlive = false;
            }
        }

        public void Rest()
        {
            if (IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            this.Health += (BaseHealth * RestHealMultiplier);
        }

        public void UseItem(Item item)
        {
            if (IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(this);
            if (Health <= 0)
            {
                IsAlive = false;
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive == false || character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive == false || character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            if (IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            this.Bag.AddItem(item);
        }

        public override string ToString()
        {

            var result = ($"{this.name} - HP: {this.health}/{BaseHealth}, AP: {this.armor}/{BaseArmor}, Status: {GetStatus()}");

            return result.ToString().Trim();
        }

        private string GetStatus()
        {
            if (IsAlive)
            {
                return "Alive";
            }
            else
            {
                return "Dead";
            }
        }
    }
}
