using System;
using System.Collections;
using System.Collections.Generic;

namespace Solutions
{
    public class Solution923
    {
        public int ThreeSumMulti(int[] arr, int target)
        {
            var length = arr.Length;
            var result = 0;
            var module = (int)Math.Pow(10, 9) + 7;
            var hashtable = BuildCache(arr, target);

            for (var i = 0; i < length - 2; i++)
            {
                var remainSum = target - arr[i];

                var queue = hashtable[remainSum] as Queue<int>;
                if (queue == null || queue.Count == 0)
                    continue;

                while (queue.Count > 0 && queue.Peek() <= i)
                    queue.Dequeue();

                result = (result + queue.Count) % module;
            }

            return result;
        }

        private static Hashtable BuildCache(int[] arr, int target)
        {
            var hashtable = new Hashtable(300);

            for (var j = 1; j < arr.Length - 1; j++)
            for (var k = j + 1; k < arr.Length; k++)
            {
                var sum = arr[j] + arr[k];
                if (sum > target)
                    continue;

                var queue = hashtable[sum] as Queue<int>;
                if (queue == null)
                {
                    queue = new Queue<int>(1000);
                    queue.Enqueue(j);
                    hashtable[sum] = queue;
                }
                else
                {
                    queue.Enqueue(j);
                }
            }

            return hashtable;
        }
    }
}