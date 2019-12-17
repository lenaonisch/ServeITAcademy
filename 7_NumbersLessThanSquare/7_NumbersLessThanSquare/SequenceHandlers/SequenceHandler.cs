using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumbersLessThanSquare.SequenceHandlers
{
    public abstract class SequenceHandler  
    {
        protected const string NO_NEXT_HANDLER = "No next handler assigned";

        protected SequenceHandler _successor;

        public void SetNextHandler(SequenceHandler successor)
        {
            _successor = successor;
        }

        public abstract List<ulong> Handle(HandlerParameters parameters);
    }
}
