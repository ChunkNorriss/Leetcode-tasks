using System;

namespace Solutions.AlgoExpert;

public class SolutionSmallestDifference
{
    public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
    {
        Array.Sort(arrayOne);
        Array.Sort(arrayTwo);
        var oneIdx = 0;
        var twoIdx = 0;
        var result = new[] { arrayOne[0], arrayTwo[0] };
        var minDiff = CalcDiff(result[0], result[1]);


        while (oneIdx < arrayOne.Length || twoIdx < arrayTwo.Length)
        {
            var nextOneIdx = oneIdx + 1;
            var nextTwoIdx = twoIdx + 1;
            var diffOne = GetDiff(arrayOne, arrayTwo, nextOneIdx, twoIdx);
            var diffTwo = GetDiff(arrayOne, arrayTwo, oneIdx, nextTwoIdx);

            if (diffOne == diffTwo && diffOne == int.MaxValue)
                break;

            if (diffOne < diffTwo)
            {
                oneIdx++;

                if (diffOne < minDiff)
                {
                    minDiff = diffOne;
                    result[0] = arrayOne[oneIdx];
                    result[1] = arrayTwo[twoIdx];
                }
            }
            else
            {
                twoIdx++;

                if (diffTwo < minDiff)
                {
                    minDiff = diffTwo;
                    result[0] = arrayOne[oneIdx];
                    result[1] = arrayTwo[twoIdx];
                }
            }
        }

        return result;
    }

    private static int GetDiff(int[] arrayOne, int[] arrayTwo, int oneIdx, int twoIdx)
    {
        if (oneIdx > arrayOne.Length - 1)
            return int.MaxValue;
        if (twoIdx > arrayTwo.Length - 1)
            return int.MaxValue;
        return CalcDiff(arrayOne[oneIdx], arrayTwo[twoIdx]);
    }

    private static int CalcDiff(int one, int two)
    {
        return Math.Abs(one - two);
    }
}