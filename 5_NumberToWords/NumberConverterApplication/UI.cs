using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConverterApplication
{
    class UI
    {
        public static bool GetNumberFromConsole(out int number)
        {
            Console.WriteLine("Please enter number from -2 147 483 646 to 2 147 483 647:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid number...");
                return false;
            }
        }

        public static bool IsContinued()
        {
            Console.WriteLine("Do you want to continue (y/yes)?");
            string userAnswer = Console.ReadLine().ToLower();
            return (userAnswer == "y" || userAnswer == "yes");
        }
    }
}
