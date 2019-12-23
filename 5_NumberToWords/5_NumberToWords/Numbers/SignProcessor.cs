namespace _5_NumberToWords.Numbers
{
    internal class SignProcessor : MoreThanHundredProcessor
    {
        private const string NEGATIVE = "negative ";

        public override string GetWord(int number, int divider = 1000000000)
        {
            string result;

            if (number == 0)
            {
                result = ZERO;
            }
            else
            { 
                if (number < 0)
                {
                    result = NEGATIVE + base.GetWord(-number, divider);
                }
                else
                {
                    result = base.GetWord(number, divider);
                }
            }

            return result;
        }
    }
}
