using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string play = " ";
            int min;
            int max;
            int correct;
            double jackpot = 100.00;
            double winnings;

            Console.WriteLine("Welcome to Lucky Numbers!");

            do
            {
                Console.WriteLine("\nThe jackpot is $100.00.\n\nPlease enter a starting number.", jackpot);
                min = int.Parse(Console.ReadLine());

                Console.WriteLine("\nPlease enter an ending number.");
                max = int.Parse(Console.ReadLine());
               
                int[] userNum = new int[6];
                for (int i = 0; i < userNum.Length; i++)
                {
                        Console.WriteLine("\nPlease enter a number within the number range {0}-{1}.", min, max);
                        userNum[i] = int.Parse(Console.ReadLine());

                        while (userNum[i] < min || userNum[i] >= max)
                        {
                            Console.WriteLine("\nThe number you selected is outside of the specified range.\nPlease enter a number within the number range {0}-{1}.", min, max);
                            userNum[i] = int.Parse(Console.ReadLine());
                        }
                }

                Random r = new Random();

                int[] luckyNum = new int[6];
                for (int j = 0; j < luckyNum.Length; j++)
                {
                    luckyNum[j] = r.Next(min, max);
                }

                correct = 0;

                for (int i = 0; i < userNum.Length; i++)
                {
                    for (int j = 0; j < luckyNum.Length; j++)
                    {

                        if (userNum[i] == luckyNum[j])
                        {
                            correct++;
                            break;
                        }
                    }
                }

                Console.WriteLine("\nLucky Number: {0}\nLucky Number: {1}\nLucky Number: {2}\nLucky Number: {3}\nLucky Number: {4}\nLucky Number: {5}\n", luckyNum[0], luckyNum[1], luckyNum[2], luckyNum[3], luckyNum[4], luckyNum[5]);

                Console.WriteLine("You guessed {0} numbers correctly!\n", correct);

                winnings = (jackpot/6)*correct;

                Console.WriteLine("Your winnings are ${0}!\n", winnings);

                Console.WriteLine("Would you like to play again?");
                play = Console.ReadLine().ToLower();

            } while (play == "yes");

            // Exit condition
            Console.WriteLine("\nThanks for playing!");

        }
    }
}
