using System.Collections.Generic;

namespace _5_NumberToWords
{
    public abstract class Hundred : Dozen
    {
        const int HUNDRED = 100;

        protected override string GetWord(int number)
        {
            List<string> parts = new List<string>();
            
            if (number / HUNDRED > 0)
            {
                string hundreds = base.GetWord(number / HUNDRED) + " hundred";
                if (hundreds != "")
                {
                    parts.Add(hundreds);
                }
            }
            string mod = base.GetWord(number % HUNDRED);
            if (mod != "")
            {
                parts.Add(mod);
            }
            return string.Join(" ", parts);
        }
    }
}
