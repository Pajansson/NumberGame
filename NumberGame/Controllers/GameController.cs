using NumberGame.Models;
using System;
using System.Collections.Generic;

namespace NumberGame.Controllers
{
    public static class GameController
    {
        public static int minDiceRolls = 1;
        public static int maxDiceRolls = 4;

        public static bool Replay()
        {
            Console.WriteLine("Vill du spela igen? y/n");
            var input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Jag förstår bara y/n, testa igen!");
                return Replay();
            }
        }

        public static void Play()
        {
            Console.WriteLine($"Välj hur många tärningar du vill kasta, välj ett heltal mellan {minDiceRolls}-{maxDiceRolls} :) ");
            int diceRolls = 0;
            var input = Console.ReadLine();

            while (!int.TryParse(input, out diceRolls) || diceRolls < minDiceRolls || diceRolls > maxDiceRolls)
            {
                Console.WriteLine($"Inte ett heltal mellan {minDiceRolls}-{maxDiceRolls}, testa igen!");
                input = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine($"OK, kastar tärningen {diceRolls} gånger!");
            var diceResult = new DiceResult
            {
                RolledCount = diceRolls
            };
            for (int i = 0; i < diceRolls; i++)
            {
                var rolledDice = RollDice(diceResult);
                diceResult.RolledCount = rolledDice.RolledCount;
                diceResult.TotalSum = rolledDice.TotalSum;
                if (i + 1 < diceRolls)
                {
                    Console.WriteLine($"Summan av tärningarna är nu {diceResult.TotalSum}");
                }
            }
            Console.WriteLine($"Summan av tärningarna blev: {diceResult.TotalSum}");
            Console.WriteLine($"Tärningen kastades totalt {diceResult.RolledCount} gånger");
            Console.ReadLine();
        }

        public static DiceResult RollDice(DiceResult diceResult)
        {
            var rolledDice = new Random().Next(1, 7);

            if (rolledDice == 1)
            {
                Console.WriteLine($"Du fick {rolledDice}, kastar två nya tärningar!");
                RollDice(diceResult);
                diceResult.RolledCount++;
                RollDice(diceResult);
                diceResult.RolledCount++;
            }
            else
            {
                Console.WriteLine($"Tärningen landade på {rolledDice}");
                diceResult.TotalSum += rolledDice;
            }
            return diceResult;
        }

        public static void PresentMe()
        {
            var personalInfos = new Dictionary<string, string>
            {
                { "Namn: ", "Name" },
                { "Datum: ", "Date"}
            };
            foreach (var personalInfo in personalInfos)
            {
                Console.WriteLine(personalInfo.Key + personalInfo.Value);
            }
            Console.ReadLine();
        }
    }
}
