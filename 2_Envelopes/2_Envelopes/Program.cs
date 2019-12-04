using System;

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
                if (UI.ValidateArgs(out a, out b, out c, out d))
                {
                    Console.WriteLine("Envelopes are {0}packable", new Envelope(a, b).IsPackable(new Envelope(c, d)) ? "" : "not ");
                }
            } while (UI.IsProgramContinued()); 
        }
    }
}
