namespace _5_NumberToWords.Numbers
{
    public class NumberConverter : Thousands
    {
        public string GetStringRepresentation(int number)
        {
            return base.GetWord(number);
        }
    }
}
