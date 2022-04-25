namespace Solutions.DataStructures;

public class MinKthHeap
{
    private readonly int capacity;
    private readonly int[] items;
    private int index;

    public MinKthHeap(int capacity)
    {
        this.capacity = capacity;
        index = 0;
        items = new int[capacity + 1];
        InitItems();
    }

    private void InitItems()
    {
        for (var i = 0; i < items.Length; i++)
            items[i] = int.MaxValue;
    }

    public int GetMin()
    {
        return items[0];
    }

    public void AddRange(int[] keys)
    {
        foreach (var key in keys) Add(key);
    }

    public void Add(int key)
    {
        var keyIndex = index;
        items[keyIndex] = key;
        index++;

        while (keyIndex != 0 && items[keyIndex] < items[Parent(keyIndex)])
        {
            var parentIndex = Parent(keyIndex);
            Swap(keyIndex, parentIndex);
            keyIndex = parentIndex;
        }

        CheckCapacity();
    }

    private void CheckCapacity()
    {
        while (index > capacity) ExtractMin();
    }

    private void ExtractMin()
    {
        Swap(0, index - 1);
        DeleteLast();


        var keyIndex = 0;
        while (true)
        {
            var currentItem = items[keyIndex];
            var minIndex = GetMinIndex(keyIndex);

            if (minIndex == -1 || currentItem < items[minIndex])
                break;

            Swap(keyIndex, minIndex);
            keyIndex = minIndex;
        }
    }

    private void DeleteLast()
    {
        items[capacity] = int.MaxValue;
        --index;
    }

    private int GetMinIndex(int keyIndex)
    {
        var left = Left(keyIndex);
        var right = Right(keyIndex);

        if (left > capacity && right > capacity)
            return -1;
        if (left > capacity)
            return right;
        if (right > capacity)
            return left;

        return items[left] < items[right] ? left : right;
    }

    private void Swap(int i, int j)
    {
        (items[i], items[j]) = (items[j], items[i]);
    }

    private int Left(int i)
    {
        return 2 * i + 1;
    }

    private int Right(int i)
    {
        return 2 * i + 2;
    }

    private int Parent(int i)
    {
        return (i - 1) / 2;
    }
}