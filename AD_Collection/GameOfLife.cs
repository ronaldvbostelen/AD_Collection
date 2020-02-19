using System;

namespace AD_Collection
{
    public class GameOfLife
    {
        private int[,] cells;

        public GameOfLife(int[,] cells)
        {
            this.cells = cells;
        }

        public void Display()
        {
            Console.Clear();

            for (int y = 0; y < cells.GetLength(0); y++)
            {
                for (int x = 0; x < cells.GetLength(1); x++)
                {
                    Console.Write($" {(cells[y, x] == 1 ? "*" : " ")} ");
                }

                Console.WriteLine();
            }
        }

        public void UpdateCell(int x, int y, int insert) => cells[y, x] = insert;

        public void Update()
        {
            // on (1) && 2/3 neigburs on (1) then on
            // on (1) && < 2/3 neigburs on (1) then off
            // off (0) && 3 neigburs on (1) then on

            var copy = (int[,])cells.Clone();

            for (int y = 0; y < cells.GetLength(0); y++)
            {
                for (int x = 0; x < cells.GetLength(1); x++)
                {
                    if (cells[y, x] == 1)
                    {
                        cells[y, x] = StateForAliveCell(x, y, copy);
                    }
                    else
                    {
                        cells[y, x] = StateForDeadCell(x, y, copy);
                    }
                }
            }
        }

        private int StateForAliveCell(int x, int y, int[,] currentState)
        {
            var aliveNeighbours = NeighboursAlive(x, y, currentState);

            return aliveNeighbours == 2 || aliveNeighbours == 3 ? 1 : 0;
        }

        private int StateForDeadCell(int x, int y, int[,] currentState) => NeighboursAlive(x, y, currentState) == 3 ? 1 : 0;

        private int NeighboursAlive(int x, int y, int[,] currentState)
        {
            var sum = 0;
            var xData = TraversX(x);
            var yData = TraversY(y);

            for (var traversY = 0; traversY < yData.Item2; traversY++)
            {
                for (var traversX = 0; traversX < xData.Item2; traversX++)
                {
                    var yCell = yData.Item1 + traversY;
                    var xCell = xData.Item1 + traversX;

                    if (IsNeigbour(x, y, xCell, yCell))
                    {
                        sum += currentState[yCell, xCell];
                    }

                }
            }

            return sum;
        }

        private bool IsNeigbour(int xSelf, int ySelf, int x, int y) => xSelf != x || ySelf != y;

        private Tuple<int, int> TraversX(int x)
        {
            if (x == 0) return new Tuple<int, int>(x, 2);

            if (x == cells.GetLength(1) - 1) return new Tuple<int, int>(x - 1, 2);

            return new Tuple<int, int>(x - 1, 3);
        }

        private Tuple<int, int> TraversY(int y)
        {
            if (y == 0) return new Tuple<int, int>(y, 2);

            if (y == cells.GetLength(0) - 1) return new Tuple<int, int>(y - 1, 2);

            return new Tuple<int, int>(y - 1, 3);
        }
    }
}