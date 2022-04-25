namespace Solutions;

public class Solution59
{
    private static readonly int[] Right = { 0, 1 };
    private static readonly int[] Down = { 1, 0 };
    private static readonly int[] Left = { 0, -1 };
    private static readonly int[] Up = { -1, 0 };

    public int[][] GenerateMatrix(int n)
    {
        var totalElements = n * n;
        var matrix = CreateMatrix(n);
        var pos = new[] { 0, 0 };
        var dir = new[] { 0, 0 };

        for (var i = 1; i <= totalElements;)
        {
            while (IsAcceptableIndex(matrix, pos, dir))
            {
                pos[0] += dir[0];
                pos[1] += dir[1];
                matrix[pos[0]][pos[1]] = i++;
            }

            dir = GetNextDirection(matrix, pos);
        }

        return matrix;
    }

    private int[] GetNextDirection(int[][] matrix, int[] pos)
    {
        if (IsAcceptableIndex(matrix, pos, Right))
            return Right;

        if (IsAcceptableIndex(matrix, pos, Down))
            return Down;

        if (IsAcceptableIndex(matrix, pos, Left))
            return Left;

        return Up;
    }

    private int[][] CreateMatrix(int n)
    {
        var result = new int[n][];
        for (var i = 0; i < n; i++) result[i] = new int[n];

        return result;
    }

    private bool IsAcceptableIndex(int[][] matrix, int[] pos, int[] dir)
    {
        var r = pos[0] + dir[0];
        var c = pos[1] + dir[1];

        if (r < 0 || c < 0)
            return false;
        var rows = matrix.Length;
        var columns = matrix[0].Length;

        return r < rows && c < columns && matrix[r][c] == 0;
    }
}