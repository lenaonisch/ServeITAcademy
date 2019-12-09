using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_NumberToWords.Numbers
{
    public abstract class Million : Thousand
    {
        const int MILLION = 1000000;

        protected override string GetWord(int number)
        {
            List<string> parts = new List<string>();

            if (number / MILLION > 0)
            {
                string thousands = base.GetWord(number / MILLION) + " million";
                if (thousands != "")
                {
                    parts.Add(thousands);
                }
            }
            string modMillion = base.GetWord(number % MILLION);
            if (modMillion != "")
            {
                parts.Add(modMillion);
            }
            return string.Join(" ", parts);
        }
    }
}
