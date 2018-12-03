namespace DungeonsAndCodeWizards.Controllers
{
    using DungeonsAndCodeWizards.Entities.Characters;
    using DungeonsAndCodeWizards.Entities.Items;
    using DungeonsAndCodeWizards.Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DungeonMaster
    {
        CharacterFactory characterFactory;
        ItemFactory itemFactory;
        List<Character> characters;
        Stack<Item> itemPool;
        int lastSurvivorRounds;

        public DungeonMaster()
        {
            characterFactory = new CharacterFactory();
            itemFactory = new ItemFactory();
            characters = new List<Character>();
            itemPool = new Stack<Item>();
            lastSurvivorRounds = 0;
        }
        public string JoinParty(string[] args)
        {
            var character = characterFactory.CreateCharacter(args);
            characters.Add(character);
            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var item = itemFactory.CreateItem(args);
            itemPool.Push(item);

            return $"{item.Name} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var character = characters
                .FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Parameter Error: Character {characterName} not found!");
            }
            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation: No items left in pool!");
            }

            var itemToPick = itemPool.Pop();
            character.Bag
                .AddItem(itemToPick);

            return $"{character.Name} picked up {itemToPick.Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = characters
                .FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            var itemToUse = character.Bag.GetItem(itemName);
            character.UseItem(itemToUse);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var reciverName = args[1];
            var itemName = args[2];

            var giver = characters
                .FirstOrDefault(c => c.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException($"Character {giver.Name} not found!");
            }

            var reciver = characters
                .FirstOrDefault(c => c.Name == reciverName);
            if (reciver == null)
            {
                throw new ArgumentException($"Character {reciver.Name} not found!");
            }

            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, reciver);
            return $"{giver.Name} used {item.Name} on {reciver.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var reciverName = args[1];
            var itemName = args[2];

            var giver = characters
                .FirstOrDefault(c => c.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException($"Character {giver.Name} not found!");
            }

            var reciver = characters
                .FirstOrDefault(c => c.Name == reciverName);
            if (reciver == null)
            {
                throw new ArgumentException($"Character {reciver.Name} not found!");
            }


            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, reciver);

            return $"“{giver.Name} gave {reciver.Name} {item.Name}.";
        }

        public string GetStats()
        {
            var result = new StringBuilder();
            var orderedCharacters = characters
                .OrderByDescending(s => s.IsAlive == true)
                .ThenBy(h => h.Health)
                .ToList();

            foreach (var character in orderedCharacters)
            {
                result
                    .Append(character.ToString())
                    .Append(Environment.NewLine);
            }

            var output = result.ToString().Trim();
            return output;
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var targetName = args[1];

            var attacker = characters
                .FirstOrDefault(c => c.Name == attackerName);
            if (attacker == null)
            {
                throw new ArgumentException($"Parameter Error: Character {targetName} not found!");
            }

            var target = characters
                .FirstOrDefault(c => c.Name == targetName);
            if (target == null)
            {
                throw new ArgumentException($"Parameter Error: Character {targetName} not found!");
            }

            if (attacker is Cleric)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            var warrior = (Warrior)attacker;
            warrior.Attack(target);

            var output = new StringBuilder();
            output.AppendLine($"{warrior.Name} attacks {target.Name} for {attacker.AbilityPoints} hit points! {target.Name} has {target.Health}/{target.BaseHealth} HP and {target.Armor}/{target.BaseArmor} AP left!");

            if (target.IsAlive == false)
            {
                output.AppendLine($"{target.Name} is dead!");
            }
            var result = output.ToString().Trim();

            return result;
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var targetName = args[1];

            var healer = characters
                .FirstOrDefault(c => c.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException($"Parameter Error: Character {healerName} not found!");
            }

            var target = characters
                .FirstOrDefault(c => c.Name == targetName);
            if (target == null)
            {
                throw new ArgumentException($"Parameter Error: Character {targetName} not found!");
            }

            if (healer is Warrior)
            {
                throw new ArgumentException($"{healer.Name} cannot attack!");
            }

            var cleric = (Cleric)healer;
            cleric.Heal(target);

            var output = new StringBuilder();
            output.AppendLine($"{cleric.Name} heals {target.Name} for {cleric.AbilityPoints}! {target.Name} has {target.Health} health now!");

            var result = output.ToString().Trim();

            return result;
        }

        public string EndTurn(string[] args)
        {
            var aliveCharacters = characters
                .Where(s => s.IsAlive == true)
                .ToList();
            var output = new StringBuilder();

            if (aliveCharacters.Count <= 1)
            {
                lastSurvivorRounds++;
            }
            foreach (var character in aliveCharacters)
            {
                var healthBeforeRest = character.Health;
                character.Rest();
                output.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            return output.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if (lastSurvivorRounds > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
