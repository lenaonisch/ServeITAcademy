namespace _5_NumberToWords.Numbers
{
    public class NumberConverter : Million
    {
        public string GetStringRepresentation(int number)
        {
            return base.GetWord(number);
        }
    }
}
