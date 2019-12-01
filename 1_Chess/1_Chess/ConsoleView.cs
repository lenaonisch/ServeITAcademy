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
            for (int j = 0; j < field.height; j++)
            {
                for (int i = 0; i < field.width; i++)
                {
                    switch (field.cells[j, i].color)
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
        }
    }
}
