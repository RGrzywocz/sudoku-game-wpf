using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjekt.Model
{
    class board
    {
        private int[,] cells = new int[9, 9];

        public int[,] Cells { 
            get 
            {
                return cells;
            }
            set 
            {
                cells = value;
            }
        }

        public int getCell(int row, int column)
        {
            return Cells[row, column];
        }
        public board()
        {
            cells = new int[9, 9];
        }
        public board(int[,] boardInput) {
            cells = boardInput.Clone() as int[,];
        }
        public void updateCell(int number, int row, int column)
        {
            if(number > 0 && number < 10){
                cells[row, column] = number;
            }
            else
            {
                cells[row, column] = 0;
            }
        }
        public bool isCorrect(board solution) {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (cells[i, j] != solution.cells[i, j]) return false;
                }
            }
            return true;
        }
    }
}
