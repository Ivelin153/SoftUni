namespace DungeonsAndCodeWizards.Entities.Contracts
{
    using DungeonsAndCodeWizards.Entities.Characters;
    public interface IHealable
    {
        void Heal(Character character);
    }
}
