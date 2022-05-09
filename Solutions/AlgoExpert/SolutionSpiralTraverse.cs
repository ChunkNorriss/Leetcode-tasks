using System.Collections.Generic;

namespace Solutions.AlgoExpert;

public class SolutionSpiralTraverse
{
    private static readonly int[] Right = { 0, 1 };
    private static readonly int[] Bottom = { 1, 0 };
    private static readonly int[] Left = { 0, -1 };
    private static readonly int[] Top = { -1, 0 };

    public static List<int> SpiralTraverse(int[,] array)
    {
        var pos = new[] { 0, 0 };
        var result = new List<int>
        {
            GetItem(array, pos)
        };
        var bounds = new Bounds
        {
            MinRow = 0,
            MinColumn = 0,
            MaxRow = array.GetLength(0),
            MaxColumn = array.GetLength(1)
        };


        var totalElements = bounds.MaxRow * bounds.MaxColumn;
        while (result.Count < totalElements)
        {
            while (TryMoveNext(bounds, pos, Right))
                result.Add(GetItem(array, pos));
            bounds.MinRow++;

            while (TryMoveNext(bounds, pos, Bottom))
                result.Add(GetItem(array, pos));
            bounds.MaxColumn--;

            while (TryMoveNext(bounds, pos, Left))
                result.Add(GetItem(array, pos));
            bounds.MaxRow--;

            while (TryMoveNext(bounds, pos, Top))
                result.Add(GetItem(array, pos));
            bounds.MinColumn++;
        }

        // Write your code here.
        return result;
    }

    private static bool TryMoveNext(Bounds bounds, int[] pos, int[] direction)
    {
        if (!bounds.Contains(pos, direction))
            return false;

        pos[0] += direction[0];
        pos[1] += direction[1];
        return true;
    }

    private static int GetItem(int[,] array, int[] pos)
    {
        return array[pos[0], pos[1]];
    }

    private struct Bounds
    {
        public int MinRow;
        public int MaxRow;
        public int MinColumn;
        public int MaxColumn;

        public bool Contains(int[] pos, int[] dir)
        {
            var newPos = new[] { pos[0] + dir[0], pos[1] + dir[1] };
            if (newPos[0] < MinRow || newPos[0] >= MaxRow)
                return false;

            if (newPos[1] < MinColumn || newPos[1] >= MaxColumn)
                return false;

            return true;
        }
    }
}