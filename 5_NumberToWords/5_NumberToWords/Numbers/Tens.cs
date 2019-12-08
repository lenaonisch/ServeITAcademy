using System;

namespace _5_NumberToWords
{
     public abstract class Tens : FirstTwoDozens
     {
        private const string INVALID_DOZEN = "Invalid dozen. Should be less than 90";

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

        public override string GetWord(int number)
        {
            if (number < 20)
            {
                return base.GetWord(number);
            }
            else
            {
                if (number / 10 > 9)
                {
                    throw new ArgumentException(INVALID_DOZEN);
                }
                else
                {
                    string modTen = number % 10 > 0 ? " " + base.GetWord(number % 10) : "";
                    return words[number / 10] + modTen;
                }
            } 
        }
    }
}
