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
            uint height;
            uint width;
            IView consoleView = new ConsoleView();

            if (UI.ValidateArgs(args, out height, out width))
            {
                consoleView.PrintField(new ChessField(height, width));
            }
            else
            {
                consoleView.PrintHelp();
            }
            Console.Read();
        }

        
    }
}
