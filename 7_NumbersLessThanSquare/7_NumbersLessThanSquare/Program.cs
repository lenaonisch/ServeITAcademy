using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Serilog;
using System.IO;

namespace _7_8_NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            SequenceOperation operation;
            StartLogging();

            do
            {
                ulong[] arguments;

                UI.PrintMenu();
                operation = UI.GetOperation();
                if (operation != null)
                {
                    UI.PrintParamHelper(operation);
                    UI.GetArgs(out arguments);
                    UI.PrintSequence(operation(arguments));
                }

            } while (UI.IsProgramContinued());

            FinishLogging();
        }

        static void StartLogging()
        {
            string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string logDirectory = "LOGS";
            string logFileName = string.Format("Run_{0}_{1}",
                DateTime.Now.ToShortDateString(),
                DateTime.Now.ToShortTimeString());

            Directory.CreateDirectory(logDirectory);
            
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File($@"\\{appDirectory}\\{logDirectory}\\{logFileName}").CreateLogger();
        }

        static void FinishLogging()
        {
            Log.CloseAndFlush();
        }
    }
}
