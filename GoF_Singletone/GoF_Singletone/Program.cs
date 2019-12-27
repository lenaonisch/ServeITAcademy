using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF_Singletone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LazySingleton.SomeStaticString);

            (new Thread(() =>
            {
                LazySingleton singleton1 = LazySingleton.GetInstance();
                Console.WriteLine(singleton1.CreationDateTime);
            })).Start();

            LazySingleton singleton2 = LazySingleton.GetInstance();
            Console.WriteLine(singleton2.CreationDateTime);

            Console.ReadLine();
        }
    }
}
