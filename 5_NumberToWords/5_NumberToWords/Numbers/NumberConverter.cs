namespace _5_NumberToWords.Numbers
{
    public class NumberConverter
    {
        static SignProcessor processor = new SignProcessor();

        public static string GetStringRepresentation(int number)
        {
            return processor.GetWord(number);
        }
    }
}
