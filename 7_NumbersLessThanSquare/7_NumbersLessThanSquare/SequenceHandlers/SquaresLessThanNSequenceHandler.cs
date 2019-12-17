using System;
using System.Collections.Generic;
using Serilog;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumbersLessThanSquare.SequenceHandlers
{
    class SquaresLessThanNSequenceHandler : SequenceHandler
    {
        const string INCORRECT_PARAM_QUANTITY = "Incorrect number of parameters was passed";

        public override List<ulong> Handle(HandlerParameters parameters)
        {
            if (parameters.Operation == HandlerKind.NumbersSquaresLessThanN)
            {
                if (parameters.Arguments.Length < 1)
                {
                    throw new ArgumentException(INCORRECT_PARAM_QUANTITY);
                }

                return GetNumberSquiresLessThanN(parameters.Arguments[0]);
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

        public List<ulong> GetNumberSquiresLessThanN(ulong n)
        {
            ulong currentNumber = 1;
            List<ulong> result = new List<ulong>();

            while (currentNumber * currentNumber < n)
            {
                result.Add(currentNumber++);
            }

            return result;
        }
    }
}
