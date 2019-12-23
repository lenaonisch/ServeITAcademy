using System;
using _5_NumberToWords.Numbers;

namespace NumberConverterApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberConverter converter = new NumberConverter();
            int numberToConvert;
            
            do
            {
                if (UI.GetNumberFromConsole(out numberToConvert))
                {
                    Console.WriteLine(NumberConverter.GetStringRepresentation(numberToConvert));
                }
            }
            while (UI.IsContinued());
        }
    }
}
