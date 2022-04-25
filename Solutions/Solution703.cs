using Solutions.DataStructures;

namespace Solutions;

public class KthLargest
{
    private readonly MinKthHeap minKthHeap;

    public KthLargest(int k, int[] nums)
    {
        minKthHeap = new MinKthHeap(k);
        minKthHeap.AddRange(nums);
    }

    public int Add(int val)
    {
        minKthHeap.Add(val);
        return minKthHeap.GetMin();
    }
}