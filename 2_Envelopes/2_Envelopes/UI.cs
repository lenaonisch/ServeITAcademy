﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Envelopes
{
    class UI
    {
        public static bool InputDouble(out double value)
        {
            Console.WriteLine("Enter number with floating point (,):");
            string input = Console.ReadLine();
            Trace.WriteLine("Value entered: {0}", input);
            return double.TryParse(input, out value);
        }

        public static bool IsProgramContinued()
        {
            Console.WriteLine("Type y/yes if you want to continue");
            string answer = Console.ReadLine().ToUpper();
            Trace.WriteLine("Answer entered: {0}", answer);
            return answer == "YES" || answer == "Y";
        }
    }
}
