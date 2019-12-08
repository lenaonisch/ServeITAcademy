using System.Collections.Generic;

namespace _5_NumberToWords
{
    public abstract class Hundreds: Tens
    {
        public override string GetWord(int number)
        {
            List<string> parts = new List<string>();
            
            if (number / 100 > 0)
            {
                string hundreds = base.GetWord(number / 100) + " hundred";
                if (hundreds != "")
                {
                    parts.Add(hundreds);
                }
            }
            string mod100 = base.GetWord(number % 100);
            if (mod100 != "")
            {
                parts.Add(mod100);
            }
            return string.Join(" ", parts);
        }
    }
}
