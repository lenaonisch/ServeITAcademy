using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumbersLessThanSquare
{
    class UI
    {
        public static bool ValidateArgs(string arg0, out ulong n)
        {
            
            return ulong.TryParse(arg0, out n) && n > 0;
        }

        public static void PrintSequence(IEnumerable sequence)
        {
            short lastJunk = 2;
            StringBuilder outputString = new StringBuilder();
            foreach (var item in sequence)
            {
                outputString.Append(item);
                outputString.Append(", ");
            }
            outputString.Replace(", ", "", outputString.Length - lastJunk, lastJunk);
            Console.WriteLine(outputString);
        }
        public static void WaitUser()
        {
            Console.ReadLine();
        }

        public static void PrintHelp()
        {
            Console.WriteLine("First parameter should be natural number");
        }
    }
}
