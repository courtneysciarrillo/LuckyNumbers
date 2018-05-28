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
            int correct = 0;
            double jackpot = 600.00;
            double winnings;

            Console.WriteLine("Welcome to Lucky Numbers! The jackpot is $600.00."); //Presenting a hard-coded value for the jackpot amount to the user

            do //Allowing the program to one at least one initial time
            {
                Console.WriteLine("\nPlease enter a starting number."); //Assigning the user inputted starting value to a variable
                min = int.Parse(Console.ReadLine());

                Console.WriteLine("\nPlease enter an ending number."); //Assigning the user inputted ending value to a variable
                max = int.Parse(Console.ReadLine());
               
                int[] userNum = new int[6]; //Initializing an array for storing 6 user inputted numbers

                for (int i = 0; i < userNum.Length; i++) //Using a for loop to populate the array
                {
                    Console.WriteLine("\nPlease enter a number within the number range {0}-{1}.", min, max);
                    userNum[i] = int.Parse(Console.ReadLine()); //Storing user inputted numbers at an index of the array

                    for (int k = 0; k < i; k++) //Using a nested for loop to validate that user inputted numbers are not duplicated
                    {
                        if (userNum[i] == userNum[k] || userNum[i] < min || userNum[i] >= max)
                        {
                            while (userNum[i] == userNum[k]) //Validating that user inputted numbers are not duplicated
                            {
                                Console.WriteLine("\nThe number you entered has already been selected. Please try again.");
                                userNum[i] = int.Parse(Console.ReadLine());
                            }

                            while (userNum[i] < min || userNum[i] >= max) //Validating that user inputted numbers are within the set range
                            {
                                Console.WriteLine("\nThe number you entered is outside of the specified range. Please try again.");
                                userNum[i] = int.Parse(Console.ReadLine());

                                while (userNum[i] == userNum[k])
                                {
                                    Console.WriteLine("\nThe number you entered has already been selected. Please try again.");
                                    userNum[i] = int.Parse(Console.ReadLine());
                                }
                            }
                        }
                    }

                    // Pete, I tried using the .Contains method below to avoid duplicate entries, but I couldn't get it to work without .Take() so I used the nested for loop above instead.

                    //while (userNum.Take(i).Contains(userNum[i]) || userNum[i] < min || userNum[i] >= max)
                    //{
                    //    if (userNum.Take(i).Contains(userNum[i]))
                    //    {
                    //        Console.WriteLine("\nThe number you entered has already been selected. Please try again.");
                    //        userNum[i] = int.Parse(Console.ReadLine());
                    //    }

                    //    if (userNum[i] < min || userNum[i] >= max)
                    //    {
                    //        Console.WriteLine("\nThe number you entered is outside of the specified range. Please try again.");
                    //        userNum[i] = int.Parse(Console.ReadLine());
                    //    }
                    //}

                    while (userNum[i] < min || userNum[i] >= max) //Validating that user inputted numbers are within the set range
                    {
                        Console.WriteLine("\nThe number you entered is outside of the specified range. Please try again.");
                        userNum[i] = int.Parse(Console.ReadLine());
                    }
                }

                Random r = new Random();

                int[] luckyNum = new int[6]; //Initializing an array for storing 6 randomly generated numbers

                for (int j = 0; j < luckyNum.Length; j++) //Using a for loop to populate the array
                {
                    luckyNum[j] = r.Next(min, max); //Setting the user inputted min and max as the lowest and highest numbers in the number range
                }

                for (int i = 0; i < userNum.Length; i++) //Using nested for loops to count the number of correctly guessed numbers
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

                winnings = (jackpot/6)*correct; //Calculating the user's winnings based on the number of correctly gussed numbers

                Console.WriteLine("Your winnings are ${0}!\n", winnings);

                Console.WriteLine("Would you like to play again?");
                play = Console.ReadLine().ToLower();

            } while (play == "yes"); //Executing the program from the beginning if the user says yes

            //Exit condition
            Console.WriteLine("\nThanks for playing!");
        }
    }
}
