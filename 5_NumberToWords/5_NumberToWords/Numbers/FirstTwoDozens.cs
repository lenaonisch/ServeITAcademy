using System;

namespace _5_NumberToWords
{
    public abstract class FirstTwoDozens
    {
        private const string NUMBER_GREATER_THAT_TWO_DOZENS = "Requested number is more than nineteen!";

        #region words
        string[] words = {
            "",
            "one",
            "two",
            "tree",
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

        public virtual string GetWord(int number)
        {
            if (number > 19)
            {
                throw new ArgumentException(NUMBER_GREATER_THAT_TWO_DOZENS);
            }
            return words[number];
        }
    }
}
