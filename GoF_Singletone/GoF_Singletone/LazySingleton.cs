using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF_Singletone
{
    class LazySingleton
    {
        public static string SomeStaticString = "I'm a static string";
        public string CreationDateTime = System.DateTime.Now.TimeOfDay.ToString();

        public LazySingleton()
        {
            Console.WriteLine("ctor: " + CreationDateTime);
        }

        public static LazySingleton GetInstance()
        {
            return Nested._instance;
        }

        private class Nested
        {
            // static ctor is used to make sure instance is created just before 
            static Nested() { }
            internal static readonly LazySingleton _instance = new LazySingleton();
        }
    }
}
