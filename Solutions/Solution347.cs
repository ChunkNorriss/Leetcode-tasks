using System;
using System.Collections.Generic;

namespace Solutions;

public class Solution347
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Array.Sort(nums);
        var queue = new PriorityQueue<int, int>();
        var num = nums[0];
        var freq = 1;
        if (nums.Length == 1) return nums;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == num)
            {
                // count when they are the same
                freq++;
            }
            else
            {
                // this is a new one, it has to save and reset variables
                queue.Enqueue(num, freq);
                if (queue.Count > k) queue.Dequeue();
                num = nums[i];
                freq = 1;
            }

            if (i == nums.Length - 1)
            {
                // this is the last one
                queue.Enqueue(num, freq);
                if (queue.Count > k) queue.Dequeue();
            }
        }

        var result = new int[queue.Count];
        for (var i = 0; i < result.Length; i++) result[i] = queue.Dequeue();
        return result;
    }
}