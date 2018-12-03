namespace DungeonsAndCodeWizards.Entities.Items
{
    using DungeonsAndCodeWizards.Entities.Characters;
    using System;
    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public abstract string Name { get; }

        public int Weight { get; private set; }

        public virtual void AffectCharacter(Character character)
        {
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
