using System;
using _5_NumberToWords.Numbers;
using System.Reflection;
using Serilog;
using System.IO;

namespace NumberConverterApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberConverter converter = new NumberConverter();
            int numberToConvert;

            StartLogging();

            do
            {
                if (UI.GetNumberFromConsole(out numberToConvert))
                {
                    Console.WriteLine(NumberConverter.GetStringRepresentation(numberToConvert));
                }
            }
            while (UI.IsContinued());

            FinishLogging();
        }

        static void StartLogging()
        {
            string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string logDirectory = "LOGS";
            string logFileName = string.Format("Run_{0}",
                DateTime.Now.ToString("yyyyMMdd_HHmm"));

            Directory.CreateDirectory(logDirectory);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File($@"{appDirectory}\{logDirectory}\{logFileName}").CreateLogger();
        }

        static void FinishLogging()
        {
            Log.CloseAndFlush();
        }
    }
}
