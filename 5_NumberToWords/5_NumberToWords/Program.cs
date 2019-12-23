using System;

namespace _5_NumberToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Numbers.NumberConverter converter = new Numbers.NumberConverter();
            //2147483647
            Console.WriteLine(Numbers.NumberConverter.GetStringRepresentation(int.MaxValue));
            //Console.WriteLine(converter.GetWord(19));
            //Console.WriteLine(converter.GetWord(20));
            //Console.WriteLine(converter.GetWord(64));
            //Console.WriteLine(converter.GetWord(99));
            //Console.WriteLine(converter.GetWord(154));
            //Console.WriteLine(converter.GetWord(199));
            //Console.WriteLine(converter.GetWord(999));
            Console.ReadLine();
        }
    }
}
