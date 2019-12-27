using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF_Bridge
{
    class Abstraction
    {
        /// <summary>
        /// BRIDGE!
        /// </summary>
        public Implementor _implementor;

        public virtual void Operation()
        {
            _implementor.Operation();
        }
    }

    class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            // do some other stuff
            _implementor.Operation();
        }
    }
}
