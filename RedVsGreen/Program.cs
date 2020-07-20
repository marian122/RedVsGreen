using System;
using System.Linq;

namespace RedVsGreen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // First example.
            // 3, 3
            // 000
            // 111
            // 000
            // 1, 0, 10
            // Expected result = 5, but i got 6. The solutions seems true for me.

            // Second example.
            // 4, 4
            // 1001
            // 1111
            // 0100
            // 1010
            // 2, 2, 15
            // Expected result = 14, my result = 14.


            var size = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int countOfRows = size[0];
            int countOfCols = size[1];
            int[][] matrix = new int[countOfRows][];

            for (int row = 0; row < countOfRows; row++)
            {
                matrix[row] = new int[countOfCols];
                matrix[row] = Console.ReadLine().Select(x => (int)char.GetNumericValue(x)).ToArray();
            }

            var lastArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var targetX = lastArgs[0];
            var targetY = lastArgs[1];
            var totalGenerations = lastArgs[2];

            var generation = new Generation(countOfRows, countOfCols, matrix, targetX, targetY, totalGenerations);

            generation.Calculate();
        }
    }
}
