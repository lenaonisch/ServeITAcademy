using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_8_NumberSequence
{
    class UI
    {
        const string FAILED_TO_PARSE = "Failed to parse";

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

        public static bool IsProgramContinued()
        {
            Console.WriteLine("\n Do you want to continue? Enter 'y' to get enother sequence\n");
            string answer = Console.ReadLine();
            return answer == "y";
        }

        public static void PrintMenu()
        {
            Console.WriteLine("Enter:");
            Console.WriteLine("     1 - to get number sequence less than a square of some number");
            Console.WriteLine("     2 - to get Fibonacci sequence");
        }

        public static void PrintParamHelper(SequenceOperation operation)
        {
            if (operation == Sequence.GetFibonacciSequence)
            {
                Console.WriteLine("Enter ranges (min and max) divided with blank:");
            }
            if (operation == Sequence.GetSqrtLessThanN)
            {
                Console.WriteLine("Enter N - max value for squares of printed numbers");
            }
        }

        public static SequenceOperation GetOperation()
        {
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    return Sequence.GetSqrtLessThanN;
                case "2":
                    return Sequence.GetFibonacciSequence;
                default:
                    PrintMenu();
                    return null;
            }
        }

        public static bool GetArgs(out ulong[] args)
        {
            string input = Console.ReadLine();
            string[] splitted = input.Split(' ');
            args = new ulong[splitted.Length];

            for (int i = 0; i < splitted.Length; i++)
            {
                if (!ulong.TryParse(splitted[i], out args[i]))
                {
                    Console.WriteLine(FAILED_TO_PARSE);

                    return false;
                }
            }

            return true;
        }
    }
}
