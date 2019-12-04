using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumbersLessThanSquare
{
    class Sequence
    {
        public static IEnumerable<ulong> GetSqrtLessThanN(ulong n)
        {
            ulong currentNumber = 1;
            while (currentNumber * currentNumber < n)
            {
                yield return currentNumber++;
            }
        }
    }
}
