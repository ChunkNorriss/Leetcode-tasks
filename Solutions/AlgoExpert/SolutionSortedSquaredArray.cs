using System;

namespace Solutions.AlgoExpert;

public class SolutionSortedSquaredArray
{
    public int[] SortedSquaredArray(int[] array)
    {
        var result = new int[array.Length];
        var startIndex = GetStartIndex(array);
        var lIdx = startIndex - 1;
        var rIdx = startIndex + 1;

        result[0] = array[startIndex] * array[startIndex];
        for (var i = 1; i < result.Length; i++)
        {
            var lAbs = GetSafeAbs(array, lIdx);
            var rAbs = GetSafeAbs(array, rIdx);
            if (lAbs < rAbs)
            {
                result[i] = lAbs * lAbs;
                lIdx--;
            }
            else
            {
                result[i] = rAbs * rAbs;
                rIdx++;
            }
        }


        // Write your code here.
        return result;
    }

    private static int GetSafeAbs(int[] array, int index)
    {
        if (index < 0 || index >= array.Length)
            return int.MaxValue;
        return Math.Abs(array[index]);
    }

    private int GetStartIndex(int[] array)
    {
        var startIndex = 0;
        var minAbs = Math.Abs(array[0]);
        for (var i = 1; i < array.Length; i++)
        {
            var curAbs = Math.Abs(array[i]);
            if (curAbs < minAbs)
            {
                startIndex = i;
                minAbs = curAbs;
            }
        }

        return startIndex;
    }
}