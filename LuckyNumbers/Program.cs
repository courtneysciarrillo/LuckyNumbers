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
            //Declaring variables
            string play;
            int min;
            int max;

            Console.WriteLine("Would you like to play Lucky Numbers?");
            play = Console.ReadLine();

            while (play == "yes")
            {
                Console.WriteLine("Please enter a starting number.");
                min = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter an ending number.");
                max = int.Parse(Console.ReadLine());



            }
        }
    }
}
