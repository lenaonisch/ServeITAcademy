using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chess
{
    class UI
    {
        public static bool ValidateArgs(string[] args, out uint height, out uint width)
        {
            width = 0;
            height = 0;
            return (uint.TryParse(args[0], out height) && uint.TryParse(args[1], out width));
        }
    }
}
