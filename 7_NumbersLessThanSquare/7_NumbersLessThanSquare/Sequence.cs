using System;
using System.Collections.Generic;
using Serilog;
using System.Text;
using System.Threading.Tasks;

namespace _7_8_NumberSequence
{
    delegate IEnumerable<ulong> SequenceOperation(params ulong[] args);

    class Sequence
    {
        const string MIN_LESS_THAN_MAX = "Incorrect range: lower end is greater than upper";
        const string INCORRECT_PARAM_QUANTITY = "Incorrect number of parameters was passed";

        public static IEnumerable<ulong> GetSqrtLessThanN(params ulong[] args)
        {
            ulong currentNumber = 1;
            if (args.Length < 1)
            {
                throw new ArgumentException(INCORRECT_PARAM_QUANTITY);
            }
            while (currentNumber * currentNumber < args[0])
            {
                yield return currentNumber++;
            }
        }

        //1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144...
        public static IEnumerable<ulong> GetFibonacciSequence(params ulong[] args)
        {
            if (args.Length < 2)
            {
                Log.Error(new ArgumentException(), INCORRECT_PARAM_QUANTITY);
                yield break;
                //throw new ArgumentException(INCORRECT_PARAM_QUANTITY);
            }

            ulong min = args[0];
            ulong max = args[1];

            if (min > max)
            {
                Log.Error(new ArgumentException(), MIN_LESS_THAN_MAX);
                yield break;
                //throw new ArgumentException(MIN_LESS_THAN_MAX);
            }
            ulong f1 = 1;
            ulong f2 = 1;

            while (f1 < min)
            {
                ulong temp = f1;
                f1 = f2;
                f2 = temp + f1;
            }
            yield return f1;
            while (f2 < max)
            {
                ulong temp = f1;
                f1 = f2;
                f2 = temp + f1;
                yield return f1;
            }
        }
    }
}
