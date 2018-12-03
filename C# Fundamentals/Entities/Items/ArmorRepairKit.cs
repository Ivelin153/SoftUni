using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class ArmorRepairKit : Item
    {
        private const int ArmorRepairKitWeight = 10;
        public ArmorRepairKit()
            : base(ArmorRepairKitWeight)
        {
        }

        public override string Name => "ArmorRepairKit";

        public override void AffectCharacter(Character character)
        {
            character.Armor = character.BaseArmor;
        }
    }
}
