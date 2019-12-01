using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chess
{
    struct Cell : ICloneable
    {
        public CellType content { get; set; }
        public CellColor color { get; set; }

        public Cell(CellType content, CellColor color)
        {
            this.content = content;
            this.color = color;
        }

        public object Clone()
        {
            return new Cell(content, color);
        }
    }
}
