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
                int columnIndex = ConvertSymbolToIndex(letter);
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

        public int ConvertSymbolToIndex(char letter)
        {
            return letter.ToString().ToLower()[0] - 'a';
        }

        public ChessField(uint height, uint width)
        {
            this.Width = width;
            this.Height = height;
            Cells = new Cell[height, width];
            FillEmpty();
        }

        public void FillEmpty()
        {
            Cell emptyBlack = new Cell(CellColor.Black);
            Cell emptyWhite = new Cell(CellColor.White);

            for (int j = 0; j < Height; j += 2)
            {
                for (int i = 0; i < Width; i += 2)
                {
                    Cells[j, i] = (Cell)emptyWhite.Clone();
                }
                for (int i = 1; i < Width; i += 2)
                {
                    Cells[j, i] = (Cell)emptyBlack.Clone();
                }
            }
            for (int j = 1; j < Height; j += 2)
            {
                for (int i = 0; i < Width; i += 2)
                {
                    Cells[j, i] = (Cell)emptyBlack.Clone();
                }
                for (int i = 1; i < Width; i += 2)
                {
                    Cells[j, i] = (Cell)emptyWhite.Clone();
                }
            }
        }
    }
}
