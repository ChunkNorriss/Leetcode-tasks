using System;

namespace Solutions;

public class Solution1679 {
    public int MaxOperations(int[] nums, int k) {
        var count = 0;
        var i = 0;
        var j = nums.Length - 1;
        
        Array.Sort(nums);
        while (i < j && nums[i] < k) {
            var sum = nums[i] + nums[j];
            
            if (sum > k) {
                j--;
            } else if (sum < k) {
                i++;
            } else {
                count++;
                i++;
                j--;
            }
        }
        
        return count;
    }
}