using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            uint height = 8;
            uint width = 8;
            if (!uint.TryParse(args[0], out height) || !uint.TryParse(args[1], out width))
            {
                PrintHelp();
            }
            else
            {
                ConsoleView consoleView = new ConsoleView();
                consoleView.PrintField(new ChessField(height, width));
                Console.ReadLine();
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine("Please enter 2 positive numbers: first is height, second is width");
        }
    }
}
