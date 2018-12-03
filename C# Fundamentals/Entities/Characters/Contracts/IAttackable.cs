namespace DungeonsAndCodeWizards.Entities.Contracts
{
    using DungeonsAndCodeWizards.Entities.Characters;
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
