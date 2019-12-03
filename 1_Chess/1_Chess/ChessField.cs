using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Chess
{
    class ChessField
    {
        public uint Width { get; set; }
        public uint Height { get; set; }
        private Cell[,] Cells { get; set; }

        public Cell this[char letter, int digit] // 'a' = 97
        {
            get
            {
                int columnIndex = letter.ToString().ToLower()[0] - 97;
                return Cells[digit, columnIndex];
            }
        }

        public Cell this[int columnIndex, int digit]
        {
            get
            {
                return Cells[digit, columnIndex];
            }
        }

        public ChessField(uint height, uint width)
        {
            Cell emptyBlack = new Cell(CellColor.Black);
            Cell emptyWhite = new Cell(CellColor.White);

            this.Width = width;
            this.Height = height;
            Cells = new Cell[height, width];
            for (int j = 0; j < height; j += 2)
            {
                for (int i = 0; i < width; i += 2)
                {
                    Cells[j, i] = emptyWhite;
                }
                for (int i = 1; i < width; i += 2)
                {
                    Cells[j, i] = emptyBlack;
                }
            }
            for (int j = 1; j < height; j += 2)
            {
                for (int i = 0; i < width; i += 2)
                {
                    Cells[j, i] = emptyBlack;
                }
                for (int i = 1; i < width; i += 2)
                {
                    Cells[j, i] = emptyWhite;
                }
            }
        }
    }
}
