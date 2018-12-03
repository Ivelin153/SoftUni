namespace DungeonsAndCodeWizards.Entities.Bags
{
    using DungeonsAndCodeWizards.Entities.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Bag
    {
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.Items = new List<Item>();
        }

        public int Capacity { get; private set; }

        public double Load => Items.Sum(w => w.Weight);

        public IReadOnlyCollection<Item> Items { get; private set; }

        public void AddItem(Item item)
        {
            var currentItems = Items.ToList();
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            currentItems.Add(item);
            this.Items = currentItems;
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation: Bag is empty!");
            }
            var currentItems = Items.ToList();
            if (!currentItems.Any(i => i.Name == name))
            {
                throw new InvalidOperationException($"Parameter Error: No item with name {name} in bag!");
            }

            var item = Items.FirstOrDefault(i => i.Name == name);
            currentItems.Remove(item);
            Items = currentItems;

            return item;
        }
    }
}
