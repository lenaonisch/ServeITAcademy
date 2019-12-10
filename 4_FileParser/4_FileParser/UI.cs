using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_FileParser
{
    class UI
    {
        public void PrintHelp()
        {
            Console.WriteLine("App counts or replaces text in file. Available parameters:");
            Console.WriteLine("     <filepath> <string to count>");
            Console.WriteLine("     <filepath> <string to find> <string to replace>");
        }

        public static void CallApp(string[] args)
        {
            int paramCount = args.Length;
            FileParser parser;
            switch (paramCount)
            {
                case 2:
                    parser = new FileParser(args[0]);
                    Console.WriteLine("Number of found patterns: {0}", parser.CountPattern(args[1]));
                    break;
                case 3:
                    parser = new FileParser(args[0]);
                    parser.ReplacePattern(args[1], args[2]);
                    Console.WriteLine("Replacement finished");
                    break;
                default:
                    Console.WriteLine("Incorrect number of parameters!");
                    break;
            }

            Console.ReadLine();
        }
    }
}
