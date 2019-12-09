using System.Collections.Generic;

namespace _5_NumberToWords.Numbers
{
    public abstract class Thousand : Hundred
    {
        const int THOUSAND = 1000;

        protected override string GetWord(int number)
        {
            List<string> parts = new List<string>();

            if (number / THOUSAND > 0)
            {
                string thousands = base.GetWord(number / THOUSAND) + " thousand";
                if (thousands != "")
                {
                    parts.Add(thousands);
                }
            }
            string mod = base.GetWord(number % THOUSAND);
            if (mod != "")
            {
                parts.Add(mod);
            }
            return string.Join(" ", parts);
        }
    }
}
