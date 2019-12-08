using System.Collections.Generic;

namespace _5_NumberToWords.Numbers
{
    public abstract class Thousands : Hundreds
    {
        public override string GetWord(int number)
        {
            List<string> parts = new List<string>();

            if (number / 1000 > 0)
            {
                string thousands = base.GetWord(number / 1000) + " thousand";
                if (thousands != "")
                {
                    parts.Add(thousands);
                }
            }
            string mod1000 = base.GetWord(number % 1000);
            if (mod1000 != "")
            {
                parts.Add(mod1000);
            }
            return string.Join(" ", parts);
        }
    }
}
