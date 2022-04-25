using System.Collections.Generic;

namespace Solutions;

public class Solution1260
{
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        var rows = grid.Length;
        var columns = grid[0].Length;
        var result = new int[rows][];
        for (var row = 0; row < rows; row++)
            result[row] = new int[columns];

        var totalElements = rows * columns;

        for (var row = 0; row < rows; row++)
        for (var column = 0; column < columns; column++)
        {
            var newIndex = (row * columns + column + k) % totalElements;
            var newRow = newIndex / columns;
            var newColumn = newIndex % columns;
            result[newRow][newColumn] = grid[row][column];
        }


        return result;
    }
}