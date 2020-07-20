using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedVsGreen
{
    public class Generation
    {
        public Generation(int x, int y, int[][] matrix, int targetX, int targetY, int totalGenerations)
        {
            this.X = x;
            this.Y = y;
            this.Matrix = matrix;
            this.TargetX = targetX;
            this.TargetY = targetY;
            this.TotalGenerations = totalGenerations;
        }

        public int X { get; }
        public int Y { get; }
        public int[][] Matrix { get; }
        public int TargetX { get; }
        public int TargetY { get; }
        public int TotalGenerations { get; }

        public void Calculate()
        {
            var matrixForNextGeneration = new List<string>();
            var counter = 0;

            for (int i = 0; i <= this.TotalGenerations; i++)
            {
                foreach (var data in matrixForNextGeneration)
                {
                    var splittedData = data.Split(" ").Select(int.Parse).ToArray();
                    var row = splittedData[0];
                    var col = splittedData[1];
                    var value = splittedData[2];
                    this.Matrix[row][col] = value;
                }
                matrixForNextGeneration.Clear();

                if (this.Matrix[TargetX][TargetY] == 1)
                {
                    counter++;
                }

                for (int row = 0; row < this.X; row++)
                {
                    for (int col = 0; col < this.Y; col++)
                    {
                        int greenNeighbours = CheckForGreen(this.Matrix, row, col);
                        if (this.Matrix[row][col] == 1)
                        {
                            if (greenNeighbours != 2 && greenNeighbours != 3 && greenNeighbours != 6)
                            {
                                matrixForNextGeneration.Add($"{row} {col} 0");
                            }
                        }
                        else
                        {
                            if (greenNeighbours == 3 || greenNeighbours == 6)
                            {
                                matrixForNextGeneration.Add($"{row} {col} 1");
                            }
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }

        private int CheckForGreen(int[][] matrix, int row, int col)
        {
            int countOfRows = matrix.Length;
            int countOfCols = matrix[0].Length;
            int greenNeighboors = 0;
            if (col + 1 < countOfCols && matrix[row][col + 1] == 1)
            {
                greenNeighboors++;
            }
            if (col - 1 >= 0 && matrix[row][col - 1] == 1)
            {
                greenNeighboors++;
            }
            if (row - 1 >= 0 && matrix[row - 1][col] == 1)
            {
                greenNeighboors++;
            }
            if (row + 1 < countOfRows && matrix[row + 1][col] == 1)
            {
                greenNeighboors++;
            }
            if ((row - 1 >= 0 && col - 1 >= 0) && matrix[row - 1][col - 1] == 1)
            {
                greenNeighboors++;
            }
            if ((row + 1 < countOfRows && col + 1 < countOfCols) && matrix[row + 1][col + 1] == 1)
            {
                greenNeighboors++;
            }
            if ((row - 1 >= 0 && col + 1 < countOfCols) && matrix[row - 1][col + 1] == 1)
            {
                greenNeighboors++;
            }
            if ((row + 1 < countOfRows && col - 1 >= 0) && matrix[row + 1][col - 1] == 1)
            {
                greenNeighboors++;
            }
            return greenNeighboors;
        }

    }
}
