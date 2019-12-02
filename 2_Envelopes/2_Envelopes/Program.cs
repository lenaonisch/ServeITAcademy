using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Envelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, d;
            do
            {
                Console.WriteLine("Input (a, b) - sides of the 1st envelope; (c, d) - sides of the 2nd envelope");
                if (UI.InputDouble(out a) && UI.InputDouble(out b) && UI.InputDouble(out c) && UI.InputDouble(out d))
                {
                    Console.WriteLine("Envelopes are {0}pacakble", EnvelopeCounter.IsPackable(new Envelope(a, b), new Envelope(c, d)) ? "" : "not ");
                }
            } while (UI.IsProgramContinued()); 
        }
    }
}
