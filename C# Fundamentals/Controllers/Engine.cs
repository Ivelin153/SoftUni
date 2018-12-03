using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Controllers
{
    public class Engine
    {
        private readonly DungeonMaster dungeonMaster;


        public Engine(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        public void Start()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                var commandArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var cmd = commandArgs.First();
                commandArgs = commandArgs.Skip(1).ToArray();

                try
                {
                    string output;
                    switch (cmd)
                    {
                        case "JoinParty":
                            output = dungeonMaster.JoinParty(commandArgs);
                            Console.WriteLine(output);
                            break;

                        case "AddItemToPool":
                            output = dungeonMaster.AddItemToPool(commandArgs);
                            Console.WriteLine(output);
                            break;

                        case "PickUpItem":
                            output = dungeonMaster.PickUpItem(commandArgs);
                            Console.WriteLine(output);
                            break;

                        case "UseItem":
                            output = dungeonMaster.UseItem(commandArgs);
                            Console.WriteLine(output);
                            break;

                        case "UseItemOn":
                            output = dungeonMaster.UseItemOn(commandArgs);
                            Console.WriteLine(output);
                            break;

                        case "GiveCharacterItem":
                            output = dungeonMaster.GiveCharacterItem(commandArgs);
                            Console.WriteLine(output);
                            break;

                        case "GetStats":
                            output = dungeonMaster.GetStats();
                            Console.WriteLine(output);
                            break;

                        case "Attack":
                            output = dungeonMaster.Attack(commandArgs);
                            Console.WriteLine(output);
                            break;

                        case "Heal":
                            output = dungeonMaster.Heal(commandArgs);
                            Console.WriteLine(output);
                            break;

                        case "EndTurn":
                            output = dungeonMaster.EndTurn(commandArgs);
                            Console.WriteLine(output);
                            if (dungeonMaster.IsGameOver())
                            {
                                Console.WriteLine("Final stats:");
                                Console.WriteLine(dungeonMaster.GetStats());
                                Environment.Exit(0);
                            }
                            break;
                    }
                    input = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    input = Console.ReadLine();
                }

            }
        }
    }
}