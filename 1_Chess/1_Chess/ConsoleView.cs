using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chess
{
    class ConsoleView : IView
    {
        public void PrintField(ChessField field)
        {
            for (int j = 0; j < field.Height; j++)
            {
                for (int i = 0; i < field.Width; i++)
                {
                    switch (field[i, j].Color)
                    {
                        case CellColor.White:
                            Console.Write('*');
                            break;
                        case CellColor.Black:
                            Console.Write(' ');
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public void PrintHelp()
        {
            Console.WriteLine("Please enter 2 positive numbers: first is height, second is width");
        }
    }
}
