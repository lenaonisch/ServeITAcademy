using System;

namespace _5_NumberToWords
{
    internal class FirstTwoDozensProcessors
    {
        private const string NUMBER_GREATER_THAT_TWO_DOZENS = "Requested number is more than nineteen!";
        protected const string ZERO = "zero";

        #region words

        string[] words = {
            "",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        #endregion

        public virtual string GetWord(int number, int divider = 100)
        {
            if (number > 19)
            {
                throw new ArgumentException(NUMBER_GREATER_THAT_TWO_DOZENS);
            }

            return words[number];
        }
    }
}
