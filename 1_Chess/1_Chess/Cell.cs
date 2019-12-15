using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chess
{
    class Cell : ICloneable
    {
        public CellColor Color { get; set; }

        public Cell(CellColor color)
        {
            Color = color;
        }

        public object Clone()
        {
            return new Cell(Color);
        }
    }
}
