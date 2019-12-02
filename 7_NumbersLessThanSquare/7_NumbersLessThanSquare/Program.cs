using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumbersLessThanSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n;
            if (ulong.TryParse(args[0], out n) && n > 0)
            {
                UI.PrintSequence(Sequence.GetSqrtLessThanN(n));
            }
            else
            {
                UI.PrintHelp();
            }
        }
    }
}
