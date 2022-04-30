using System;

namespace Solutions
{
    public class Solution11
    {
        public int MaxArea(int[] height)
        {
            var maxArea = 0;
            var l = 0;
            var r = height.Length - 1;

            while (l < r)
            {
                var maxL = height[l];
                var maxR = height[r];
                var area = CalculateArea(height, l, r);
                if (area > maxArea)
                    maxArea = area;

                if (height[l] < height[r])
                    while (l < r && height[l] <= maxL)
                        l++;
                else
                    while (r > l && height[r] <= maxR)
                        r--;
            }

            return maxArea;
        }

        private static int CalculateArea(int[] height, int l, int r)
        {
            var minHeight = Math.Min(height[l], height[r]);
            return minHeight * (r - l);
        }
    }
}