using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
            var dungeonMaster = new DungeonMaster();
            string input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = tokens[0];
                var commandTokens = tokens.Skip(1).ToArray();
                var result = string.Empty;
                var isEnd = false;
                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            result = dungeonMaster.JoinParty(commandTokens);
                            break;
                        case "AddItemToPool":
                            result = dungeonMaster.AddItemToPool(commandTokens);
                            break;
                        case "PickUpItem":
                            result = dungeonMaster.PickUpItem(commandTokens);
                            break;
                        case "UseItem":
                            result = dungeonMaster.UseItem(commandTokens);
                            break;
                        case "UseItemOn":
                            result = dungeonMaster.UseItemOn(commandTokens);
                            break;
                        case "GiveCharacterItem":
                            result = dungeonMaster.GiveCharacterItem(commandTokens);
                            break;
                        case "GetStats":
                            result = dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            result = dungeonMaster.Attack(commandTokens);
                            break;
                        case "Heal":
                            result = dungeonMaster.Heal(commandTokens);
                            break;
                        case "EndTurn":
                            result = dungeonMaster.EndTurn(commandTokens);
                            break;
                        case "IsGameOver":
                            isEnd = dungeonMaster.IsGameOver();
                            break;
                    }
                    
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    if (isEnd || dungeonMaster.IsGameOver())
                    {
                        break;
                    }
                }
                catch (ArgumentException err)
                {
                    Console.WriteLine($"Parameter Error: " + err.Message);
                }
                catch (InvalidOperationException err)
                {
                    Console.WriteLine($"Invalid Operation: " + err.Message);
                }
            }

            Console.WriteLine($"Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
		}
	}
}