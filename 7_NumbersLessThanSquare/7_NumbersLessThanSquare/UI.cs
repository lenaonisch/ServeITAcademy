using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumbersLessThanSquare
{
    class UI
    {
        public static void PrintSequence(IEnumerable sequence)
        {
            foreach (var item in sequence)
            {
                Console.Write("{0}, ", item);
            }
            Console.ReadLine();
        }

        public static void PrintHelp()
        {
            Console.WriteLine("First parameter should be natural number");
        }
    }
}
