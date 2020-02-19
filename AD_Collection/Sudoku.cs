using System;

namespace AD_Collection
{
    public class Sudoku
    {
        private int[,] sudoku;

        public Sudoku(int[,] sudoku)
        {
            this.sudoku = sudoku;
        }

        public bool PossibleMove(int x, int y, int number) => CanHorizontal(y, number) && CanVertical(x, number) && CanCube(x, y, number);

        private bool CanHorizontal(int y, int number)
        {
            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                if (sudoku[y, i] == number) return false;
            }

            return true;
        }

        private bool CanVertical(int x, int number)
        {
            for (int i = 0; i < sudoku.GetLength(1); i++)
            {
                if (sudoku[i, x] == number) return false;
            }

            return true;
        }

        private bool CanCube(int x, int y, int number)
        {
            var xCube = x / 3 * 3;
            var yCube = y / 3 * 3;

            for (int yIdx = 0; yIdx < 3; yIdx++)
            {
                for (int xIdx = 0; xIdx < 3; xIdx++)
                {
                    if (sudoku[yCube + yIdx, xCube + xIdx] == number) return false;
                }
            }

            return true;
        }

        public void PrintSudoku()
        {
            for (int y = 0; y < sudoku.GetLength(0); y++)
            {
                for (int x = 0; x < sudoku.GetLength(1); x++)
                {
                    Console.Write($"[{sudoku[y, x]}],");
                }

                Console.WriteLine();
            }
        }

        public void PrintSudokuArrayFormat()
        {
            for (int y = 0; y < sudoku.GetLength(0); y++)
            {
                Console.Write("{");
                for (int x = 0; x < sudoku.GetLength(1); x++)
                {
                    Console.Write($"{sudoku[y, x]},");
                }
                Console.Write("},");
                Console.WriteLine();
            }
        }

        public void Solve()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (sudoku[y, x] == 0)
                    {
                        for (int tryNumb = 1; tryNumb < 10; tryNumb++)
                        {
                            if (PossibleMove(x, y, tryNumb))
                            {
                                sudoku[y, x] = tryNumb;
                                Solve();
                                sudoku[y, x] = 0;
                            }
                        }
                        return;
                    }
                }
            }

            Console.WriteLine($"SOLVED!");
            PrintSudoku();

        }

        private int AmountOfEmptySquares()
        {
            var amount = 0;
            for (int y = 0; y < sudoku.GetLength(0); y++)
            {
                for (int x = 0; x < sudoku.GetLength(1); x++)
                {
                    if (sudoku[y, x] == 0) ++amount;
                }
            }

            return amount;
        }
    }
}