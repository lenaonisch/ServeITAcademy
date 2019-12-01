using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chess
{
    class ChessField
    {
        public uint width { get; set; }
        public uint height { get; set; }
        public Cell[,] cells { get; set; }

        public ChessField(uint height, uint width)
        {
            Cell emptyBlack = new Cell(CellType.Empty, CellColor.Black);
            Cell emptyWhite = new Cell(CellType.Empty, CellColor.White);

            this.width = width;
            this.height = height;
            cells = new Cell[height, width];
            for (int j = 0; j < height; j += 2)
            {
                for (int i = 0; i < width; i += 2)
                {
                    cells[j, i] = emptyWhite;
                }
                for (int i = 1; i < width; i += 2)
                {
                    cells[j, i] = emptyBlack;
                }
            }
            for (int j = 1; j < height; j += 2)
            {
                for (int i = 0; i < width; i += 2)
                {
                    cells[j, i] = emptyBlack;
                }
                for (int i = 1; i < width; i += 2)
                {
                    cells[j, i] = emptyWhite;
                }
            }
        }
    }
}
