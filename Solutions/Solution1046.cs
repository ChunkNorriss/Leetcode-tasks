using System;
using System.Collections.Generic;

namespace Solutions
{
    public class Solution1046
    {
        public int LastStoneWeight(int[] stones)
        {
            Array.Sort(stones);
            var list = new LinkedList<int>(stones);

            while (list.Count > 1)
            {
                var max1 = list.Last.Value;
                list.RemoveLast();
                var max2 = list.Last.Value;
                list.RemoveLast();

                var remainValue = max1 - max2;
                if (remainValue == 0)
                    continue;

                if (list.Count == 0)
                    return remainValue;

                for (var node = list.First;;)
                {
                    if (node == null)
                    {
                        list.AddLast(remainValue);
                        break;
                    }

                    if (node.Value >= remainValue)
                    {
                        list.AddBefore(node, remainValue);
                        break;
                    }

                    node = node.Next;
                }
            }

            if (list.Count == 0)
                return 0;
            return list.First.Value;
        }
    }
}