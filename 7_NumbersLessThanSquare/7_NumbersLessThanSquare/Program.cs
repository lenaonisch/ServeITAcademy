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
            if (UI.ValidateArgs(args[0], out n))
            {
                UI.PrintSequence(Sequence.GetSqrtLessThanN(n));
                UI.WaitUser();
            }
            else
            {
                UI.PrintHelp();
            }
        }
    }
}
