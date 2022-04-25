using System.Collections.Generic;
using System.Text;

namespace Solutions;

public class Solution31
{
    public List<string> GetAllPermutation(int[] nums)
    {
        var allPermutations = new List<string>();
        if (nums == null || nums.Length < 1)
            return allPermutations;

        var remainder = new StringBuilder();
        foreach (var num in nums)
            remainder.Append(num);

        var prefix = new StringBuilder();

        GetAllPermutationsInternal(allPermutations, prefix, remainder);
        return allPermutations;
    }

    private void GetAllPermutationsInternal(ICollection<string> allPermutations, StringBuilder prefix, StringBuilder remainder)
    {
        if (remainder.Length == 0)
        {
            allPermutations.Add(prefix.ToString());
            return;
        }

        for (var i = 0; i < remainder.Length; i++)
        {
            var character = remainder[i];
            prefix.Append(character);
            remainder.Remove(i, 1);
            GetAllPermutationsInternal(allPermutations, prefix, remainder);
            prefix.Remove(prefix.Length - 1, 1);
            remainder.Insert(i, character);
        }
    }


    public void NextPermutation(int[] nums)
    {
        if (nums.Length < 2)
            return;


        NextPermutationInternal(nums, 0);
    }

    private static void NextPermutationInternal(int[] nums, int searchOffset)
    {
        for (var i = nums.Length - 2; i >= searchOffset; i--)
        {
            var digitSource = nums[i];
            for (var j = nums.Length - 1; j > i; j--)
            {
                var digitDestination = nums[j];
                if (digitSource < digitDestination)
                {
                    Swap(nums, i, j);
                    var deltaOffset = j - i;
                    NextPermutationInternal(nums, searchOffset + deltaOffset);
                }
            }
        }
    }

    private static void Swap(int[] nums, int destinationIndex, int sourceIndex)
    {
        (nums[destinationIndex], nums[sourceIndex]) = (nums[sourceIndex], nums[destinationIndex]);
    }
}