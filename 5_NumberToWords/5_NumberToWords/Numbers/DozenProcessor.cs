using System;

namespace _5_NumberToWords
{
     internal class DozenProcessor : FirstTwoDozensProcessors
     {
        private const string INVALID_DOZEN = "Invalid dozen. Should be less than 90";
        private const int TEN = 10;
        private const int TWO_DOZEN = 20;

        string[] words = {
            "",
            "",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
            };

        public override string GetWord(int number, int divider = 100)
        {
            if (number < TWO_DOZEN)
            {
                return base.GetWord(number);
            }
            else
            {
                if (number / TEN > 9)
                {
                    throw new ArgumentException(INVALID_DOZEN);
                }
                else
                {
                    string modTen = number % TEN > 0 ? " " + base.GetWord(number % TEN) : "";
                    return words[number / TEN] + modTen;
                }
            } 
        }
    }
}
