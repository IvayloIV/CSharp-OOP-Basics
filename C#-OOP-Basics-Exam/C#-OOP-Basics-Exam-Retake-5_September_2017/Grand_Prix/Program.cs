using System;
using System.Linq;

namespace Grand_Prix
{
    class Program
    {
        static void Main(string[] args)
        {
            var raceTower = new RaceTower();
            var numberOfLaps = int.Parse(Console.ReadLine());
            var lengthOfTrack = int.Parse(Console.ReadLine());
            raceTower.SetTrackInfo(numberOfLaps, lengthOfTrack);
            while (raceTower.lapsNumber != raceTower.currentLab)
            {
                var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = tokens[0];
                tokens.RemoveAt(0);
                switch (command)
                {
                    case "RegisterDriver":
                        raceTower.RegisterDriver(tokens);
                        break;
                    case "Leaderboard":
                        Console.WriteLine(raceTower.GetLeaderboard());
                        break;
                    case "CompleteLaps":
                        var result = raceTower.CompleteLaps(tokens);
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            Console.WriteLine(result);
                        }
                        break;
                    case "Box":
                        raceTower.DriverBoxes(tokens);
                        break;
                    case "ChangeWeather":
                        raceTower.ChangeWeather(tokens);
                        break;
                    default:
                        throw new ArgumentException("Invalid command!");
                }
            }

            Console.WriteLine(raceTower.GetWinner());
        }
    }
}
