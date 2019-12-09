using System;

namespace _5_NumberToWords
{
     public abstract class Dozen : FirstTwoDozens
     {
        private const string INVALID_DOZEN = "Invalid dozen. Should be less than 90";
        private const int TEN = 10;
        private const int TWO_DOZEN = 20;

        string[] words = {
            "",
            "",
            "twenty",
            "thirty",
            "fourty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
            };

        protected override string GetWord(int number)
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
