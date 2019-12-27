using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF_Singletone
{
    class Singletone
    {
        private static Singletone _instance;

        private Singletone()
        {
           ///
        }

        public static Singletone GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singletone();
            }
            return _instance;
        }
    }
}
