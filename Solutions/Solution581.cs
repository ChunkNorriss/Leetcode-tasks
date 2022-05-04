using System;

namespace Solutions;

public class Solution581
{
    public int FindUnsortedSubarray(int[] nums)
    {
        var n = nums.Length;
        var beg = -1;
        var end = -2;
        var min = nums[n - 1];
        var max = nums[0];
        for (var i = 1; i < n; i++)
        {
            max = Math.Max(max, nums[i]);
            min = Math.Min(min, nums[n - 1 - i]);
            if (nums[i] < max) end = i;
            if (nums[n - 1 - i] > min) beg = n - 1 - i;
        }

        return end - beg + 1;
    }
}