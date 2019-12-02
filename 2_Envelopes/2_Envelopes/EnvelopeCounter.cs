using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Envelopes
{
    class EnvelopeCounter
    {
        public static bool IsPackable(Envelope first, Envelope second)
        {
            return (first.width < second.width && first.height < second.height) 
                || ((first.width > second.width && first.height > second.height));
        }
    }
}
