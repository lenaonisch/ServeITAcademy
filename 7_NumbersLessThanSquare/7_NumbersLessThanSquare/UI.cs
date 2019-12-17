using System;
using System.Collections;
using System.Text;
using Serilog;
using _7_NumbersLessThanSquare.SequenceHandlers;

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
            if (outputString.Length > 0)
            {
                outputString.Replace(", ", "", outputString.Length - lastJunk, lastJunk);
            }
            Console.WriteLine(outputString);

            #region logging

            string clarification = "Sequence generated: ";
            StringBuilder logBuilder = new StringBuilder(clarification.Length + outputString.Length);
            logBuilder.Append(clarification);
            logBuilder.Append(outputString);
            Log.Information(logBuilder.ToString());

            #endregion
        }

        public static bool IsProgramContinued()
        {
            Console.WriteLine("\n Do you want to continue? Enter 'y' to get enother sequence\n");
            string answer = Console.ReadLine();
            Log.Information("User continues execution");

            return answer == "y";
        }

        public static void PrintMenu()
        {
            Console.WriteLine("Enter:");
            Console.WriteLine("     1 - to get number sequence less than a square of some number");
            Console.WriteLine("     2 - to get Fibonacci sequence");
        }

        public static void PrintParamHelper(HandlerKind operation)
        {
            if (operation == HandlerKind.Fibonacci)
            {
                Console.WriteLine("Enter ranges (min and max) divided with blank:");
            }
            if (operation == HandlerKind.NumbersSquaresLessThanN)
            {
                Console.WriteLine("Enter N - max value for squares of printed numbers");
            }
        }

        public static HandlerKind GetOperation()
        {
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    return HandlerKind.NumbersSquaresLessThanN;
                case "2":
                    return HandlerKind.Fibonacci;
                default:
                    PrintMenu();
                    return HandlerKind.Empty;
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

                    #region logging
                    Log.Debug("String parsed: {0}", splitted[i]);
                    Log.Error(FAILED_TO_PARSE);
                    #endregion

                    return false;
                }
            }

            return true;
        }
    }
}
