using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Envelopes
{
    struct Envelope
    {
        const string SIDE_LESS_THAN_ZERO = "Side is less or equal zero";

        public double width { get; private set; }
        public double height { get; private set; }

        public Envelope(double side1, double side2)
        {
            if (side1 < 0 || side2 < 0)
            {
                throw new ArgumentOutOfRangeException(SIDE_LESS_THAN_ZERO, new Exception());
            }
            if (side1 < side2)
            {
                height = side1;
                width = side2;
            }
            else
            {
                height = side2;
                width = side1;
            }
        }
    }
}
