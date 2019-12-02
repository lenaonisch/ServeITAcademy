using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Envelopes
{
    class UI
    {
        public static bool InputDouble(out double value)
        {
            Console.WriteLine("Enter number with floating point (,):");
            string input = Console.ReadLine();
            return double.TryParse(input, out value);
        }

        public static bool IsProgramContinued()
        {
            Console.WriteLine("Type y/yes if you want to continue");
            string answer = Console.ReadLine().ToUpper();
            return answer == "YES" || answer == "Y";
        }
    }
}
