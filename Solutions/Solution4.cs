using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Solution4
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var allElements = new int[nums1.Length + nums2.Length];
            var nums1Index = 0;
            var nums2Index = 0;

            var index = 0;
            while (nums1Index < nums1.Length && nums2Index < nums2.Length)
            {
                var nums1Element = nums1[nums1Index];
                var nums2Element = nums2[nums2Index];
                if (nums1Element < nums2Element)
                {
                    allElements[index++] = nums1Element;
                    nums1Index++;
                }
                else
                {
                    allElements[index++] = nums2Element;
                    nums2Index++;
                }
            }

            for (var i = nums1Index; i < nums1.Length; i++)
                allElements[index++] = nums1[i];

            for (var i = nums2Index; i < nums2.Length; i++)
                allElements[index++] = nums2[i];


            var medians = GetMiddleElements(allElements);

            return medians.Sum() * 1.0 / medians.Length;
        }

        private int[] GetMiddleElements(IReadOnlyList<int> array)
        {
            if (array.Count == 0)
                return new int[0];

            var length = array.Count;
            var middle = array[length / 2];

            if ((length & 1) == 1) return new[] { middle };

            var middleL = array[(length - 1) / 2];
            return new[] { middle, middleL };
        }
    }
}