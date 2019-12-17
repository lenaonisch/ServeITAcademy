using System;
using System.Collections.Generic;
using Serilog;

namespace _7_NumbersLessThanSquare.SequenceHandlers
{
    class FibonacciSequenceHandler : SequenceHandler
    {
        const string MIN_LESS_THAN_MAX = "Incorrect range: lower end is greater than upper";
        const string INCORRECT_PARAM_QUANTITY = "Incorrect number of parameters was passed";

        public override List<ulong> Handle(HandlerParameters parameters)
        {
            if (parameters.Operation == HandlerKind.Fibonacci)
            {
                if (parameters.Arguments.Length < 2)
                {
                    Log.Error(new ArgumentException(), INCORRECT_PARAM_QUANTITY);
                    return null ;
                }

                ulong min = parameters.Arguments[0];
                ulong max = parameters.Arguments[1];

                if (min > max)
                {
                    Log.Error(new ArgumentException(), MIN_LESS_THAN_MAX);
                    return null;
                    //throw new ArgumentException(MIN_LESS_THAN_MAX);
                }
                return GetFibonacci(min, max);
            }
            else
            {
                if (_successor != null)
                {
                    return _successor.Handle(parameters);
                }
                else
                {
                    Log.Information(NO_NEXT_HANDLER);
                    return null;
                }
            }
        }

        public List<ulong> GetFibonacci(ulong min, ulong max)
        {
            ulong f1 = 1;
            ulong f2 = 1;
            List<ulong> result = new List<ulong>();

            while (f1 < min)
            {
                ulong temp = f1;
                f1 = f2;
                f2 = temp + f1;
            }
            result.Add(f1);
            while (f2 < max)
            {
                ulong temp = f1;
                f1 = f2;
                f2 = temp + f1;
                result.Add(f1);
            }

            return result;
        }
    }
}
