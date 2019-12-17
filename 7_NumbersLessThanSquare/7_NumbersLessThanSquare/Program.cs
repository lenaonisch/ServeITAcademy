using System;
using System.Collections.Generic;
using System.Linq;
using _7_NumbersLessThanSquare.SequenceHandlers;
using System.Reflection;
using Serilog;
using System.IO;

namespace _7_8_NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            HandlerKind operation;
            SequenceHandler fibHandler = new FibonacciSequenceHandler();
            SequenceHandler squaresHandler = new SquaresLessThanNSequenceHandler();
            fibHandler.SetNextHandler(squaresHandler);

            StartLogging();

            do
            {
                ulong[] arguments;

                UI.PrintMenu();
                operation = UI.GetOperation();
                if (operation != HandlerKind.Empty)
                {
                    UI.PrintParamHelper(operation);
                    UI.GetArgs(out arguments);
                    HandlerParameters parameters = new HandlerParameters(operation, arguments);
                    UI.PrintSequence(fibHandler.Handle(parameters));
                }

            } while (UI.IsProgramContinued());

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
