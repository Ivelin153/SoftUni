namespace DungeonsAndCodeWizards.Factories
{
    using DungeonsAndCodeWizards.Entities.Characters;
    using System;
    public class CharacterFactory
    {
        public Character CreateCharacter(string[] args)
        {
            var faction = (Faction)Enum.Parse(typeof(Faction), args[0]);
            if (!Enum.TryParse(typeof(Faction), args[0], out object invalidFaction))
            {
                throw new ArgumentException("Invalid faction " + invalidFaction.GetType().Name +"!");
            }
            var type = args[1];
            var name = args[2];

            switch (type)
            {
                case "Warrior":
                    return new Warrior(name, faction);

                case "Cleric":
                    return new Cleric(name, faction);

                default:
                    throw new ArgumentException($"Invalid character type " + type + "!");
            }
        }
    }
}
