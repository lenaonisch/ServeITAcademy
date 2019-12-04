using System;

namespace _2_Envelopes
{
    class Envelope : IComparable
    {
        const string SIDE_LESS_THAN_ZERO = "Side is less or equal zero";
        const string OBJECT_NOT_LETTER = "Object is not Envelope";

        public double Width { get; private set; }
        public double Height { get; private set; }

        public Envelope(double side1, double side2)
        {
            if (side1 < 0 || side2 < 0)
            {
                throw new ArgumentOutOfRangeException(SIDE_LESS_THAN_ZERO, new Exception());
            }
            if (side1 < side2)
            {
                Height = side1;
                Width = side2;
            }
            else
            {
                Height = side2;
                Width = side1;
            }
        }

        public int CompareTo(object obj)
        {
            Envelope second = obj as Envelope;
            if (second != null)
            {
                if (Width < second.Width && Height < second.Height)
                {
                    return -1;
                }
                if (Width > second.Width && Height > second.Height)
                {
                    return 1;
                }
                if (Width == second.Width && Height == second.Height)
                {
                    return 0;
                }
            }

            throw new ArgumentException(OBJECT_NOT_LETTER);
        }

        public bool IsPackable(Envelope secondEnvelope)
        {
            int lessOrBigger = this.CompareTo(secondEnvelope);
            return lessOrBigger == -1 || lessOrBigger == 1;
        }
    }
}
