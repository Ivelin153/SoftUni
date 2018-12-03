namespace DungeonsAndCodeWizards.Entities.Bags
{
    public class Backpack : Bag
    {
        public const int DefaultCapacity = 100;

        public Backpack()
            : base(DefaultCapacity)
        {
        }
    }
}
