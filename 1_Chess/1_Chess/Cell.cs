using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chess
{
    class Cell
    {
        public CellColor Color { get; set; }

        public Cell(CellColor color)
        {
            Color = color;
        }
    }
}
