using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SudokuProjekt.ViewModel
{
    using BaseClass;
    using SudokuProjekt.Model;
    using System.Windows;
    using System.Windows.Controls;

    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int[] row1 = new int[9];
        public int[] Row1
        {
            get { return row1; }
            set
            {
                row1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(row1)));

            }
        }

        private int[] row2 = new int[9];
        public int[] Row2
        {
            get { return row2; }
            set
            {
                row2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(row2)));
            }
        }

        private int[] row3 = new int[9];
        public int[] Row3
        {
            get { return row3; }
            set
            {
                row3 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(row3)));
            }
        }

        private int[] row4 = new int[9];
        public int[] Row4
        {
            get { return row4; }
            set
            {
                row4 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(row4)));
            }
        }

        private int[] row5 = new int[9];
        public int[] Row5
        {
            get { return row5; }
            set
            {
                row5 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(row5)));
            }
        }

        private int[] row6 = new int[9];
        public int[] Row6
        {
            get { return row6; }
            set
            {
                row6 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(row6)));
            }
        }

        private int[] row7 = new int[9];
        public int[] Row7
        {
            get { return row7; }
            set
            {
                row7 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(row7)));
            }
        }

        private int[] row8 = new int[9];
        public int[] Row8
        {
            get { return row8; }
            set
            {
                row8 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(row8)));
            }
        }

        private int[] row9 = new int[9];
        public int[] Row9
        {
            get { return row9; }
            set
            {
                row9 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(row9)));
            }
        }

        private int difficulty = 0;
        public int Difficulty
        {
            get { return difficulty; }
            set
            {
                difficulty = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(difficulty)));
            }
        }

        private int[] hintCoordinates = { 0, 0 };

        public int[] HintCoordinates
        {
            get { return hintCoordinates; }
            set
            {
                HintCoordinates = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(hintCoordinates)));
            }
        }
        private ICommand updateBoard;

        public ICommand UpdateBoard
        {
            get
            {
                return updateBoard ?? (updateBoard = new RelayCommand(
                 p => startGame(Difficulty),
                 p => true
                 ));
            }
        }
        private ICommand checkBoard;

        public ICommand CheckBoard
        {
            get
            {
                return checkBoard ?? (checkBoard = new RelayCommand(
                 p => CheckGame(),
                 p => true
                 ));
            }
        }

        private ICommand hint;
        public ICommand Hint
        {
            get
            {
                return hint ?? (hint = new RelayCommand(
                 p => GetHint(),
                 p => true
                 ));
            }
        }


        public static board currentSolution = new board();
        public void startGame(int difficulty)
        {
            board[] fromDB = Database.getBoardTable(difficulty);
            board game = fromDB[0];
            board solution = fromDB[1];
            int[] row1x = new int[9];
            int[] row2x = new int[9];
            int[] row3x = new int[9];
            int[] row4x = new int[9];
            int[] row5x = new int[9];
            int[] row6x = new int[9];
            int[] row7x = new int[9];
            int[] row8x = new int[9];
            int[] row9x = new int[9];
            for (int i = 0; i < 9; i++)
            {
                row1x[i] = game.Cells[0, i];
                row2x[i] = game.Cells[1, i];
                row3x[i] = game.Cells[2, i];
                row4x[i] = game.Cells[3, i];
                row5x[i] = game.Cells[4, i];
                row6x[i] = game.Cells[5, i];
                row7x[i] = game.Cells[6, i];
                row8x[i] = game.Cells[7, i];
                row9x[i] = game.Cells[8, i];
            }
            Row1 = row1x;
            Row2 = row2x;
            Row3 = row3x;
            Row4 = row4x;
            Row5 = row5x;
            Row6 = row6x;
            Row7 = row7x;
            Row8 = row8x;
            Row9 = row9x;
            currentSolution = solution;
        }
        public void GetHint()
        {
            int row = HintCoordinates[0];
            int column = HintCoordinates[1];
            int[] oldRow;
            switch (row)
            {
                case 0:
                    oldRow = (int[])Row1.Clone();
                    oldRow[column] = currentSolution.getCell(row, column);
                    Row1 = oldRow;
                    break;
                case 1:
                    oldRow = (int[])Row2.Clone();
                    oldRow[column] = currentSolution.getCell(row, column);
                    Row2 = oldRow;
                    break;
                case 2:
                    oldRow = (int[])Row3.Clone();
                    oldRow[column] = currentSolution.getCell(row, column);
                    Row3 = oldRow;
                    break;
                case 3:
                    oldRow = (int[])Row4.Clone();
                    oldRow[column] = currentSolution.getCell(row, column);
                    Row4 = oldRow;
                    break;
                case 4:
                    oldRow = (int[])Row5.Clone();
                    oldRow[column] = currentSolution.getCell(row, column);
                    Row5 = oldRow;
                    break;
                case 5:
                    oldRow = (int[])Row6.Clone();
                    oldRow[column] = currentSolution.getCell(row, column);
                    Row6 = oldRow;
                    break;
                case 6:
                    oldRow = (int[])Row7.Clone();
                    oldRow[column] = currentSolution.getCell(row, column);
                    Row7 = oldRow;
                    break;
                case 7:
                    oldRow = (int[])Row8.Clone();
                    oldRow[column] = currentSolution.getCell(row, column);
                    Row8 = oldRow;
                    break;
                case 8:
                    oldRow = (int[])Row9.Clone();
                    oldRow[column] = currentSolution.getCell(row, column);
                    Row9 = oldRow;
                    break;
            }
        }

        public static int[,] x = new int[9, 9];
        public void CheckGame()
        {
            for (int i = 0; i < 9; i++)
            {
                x[0, i] = row1[i];
                x[1, i] = row2[i];
                x[2, i] = row3[i];
                x[3, i] = row4[i];
                x[4, i] = row5[i];
                x[5, i] = row6[i];
                x[6, i] = row7[i];
                x[7, i] = row8[i];
                x[8, i] = row9[i];
            }

            board board = new board(x);
            if (currentSolution.Cells[0, 0] == 0)
            {
                MessageBox.Show("Najpierw rozpocznij grę");
            }
            else if (board.isCorrect(currentSolution))
            {
                MessageBox.Show("Gratulacje, rozwiązałeś sudoku prawidłowo");
            }
            else
            {
                MessageBox.Show("Niestety, Twoje rozwiązanie nie jest prawidłowe");
            }
        }

    }
}
