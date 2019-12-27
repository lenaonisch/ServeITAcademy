using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF_Bridge
{
    abstract class Implementor
    {
        public abstract void Operation();
    }

    class ImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("I'm ImplementorA");
        }
    }

    class ImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("I'm ImplementorB");
        }
    }
}
