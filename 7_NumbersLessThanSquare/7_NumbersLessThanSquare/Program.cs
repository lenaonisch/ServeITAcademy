using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_8_NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            SequenceOperation operation;
           
            do
            {
                ulong[] arguments;

                UI.PrintMenu();
                operation = UI.GetOperation();
                UI.PrintParamHelper(operation);
                UI.GetArgs(out arguments);
                UI.PrintSequence(operation(arguments));

            } while (UI.IsProgramContinued());
        }
    }
}
