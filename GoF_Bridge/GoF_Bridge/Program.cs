using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF_Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            RefinedAbstraction abstraction = new RefinedAbstraction();
            ImplementorA impA = new ImplementorA();
            ImplementorB impB = new ImplementorB();

            abstraction._implementor = impA;
            abstraction.Operation();

            abstraction._implementor = impB;
            abstraction.Operation();

            Console.ReadLine();
        }
    }
}
