namespace _5_NumberToWords.Numbers
{
    public class NumberConverter : MoreThanHundred
    {
        public string GetStringRepresentation(int number)
        {
            return base.GetWord(number);
        }
    }
}
