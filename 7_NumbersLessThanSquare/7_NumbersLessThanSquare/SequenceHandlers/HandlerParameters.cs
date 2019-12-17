using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumbersLessThanSquare.SequenceHandlers
{
    public class HandlerParameters   
    {
        public HandlerKind Operation;
        public ulong[] Arguments;

        public HandlerParameters(HandlerKind handlerKind, ulong[] args)
        {
            Operation = handlerKind;
            Arguments = new ulong[args.Length];
            Array.Copy(args, Arguments, args.Length);
        }
    }
}
