using System.Collections.Generic;

namespace Solutions;

// C# IEnumerator interface reference:
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8

public class PeekingIterator {
    private readonly IEnumerator<int> iterator;
    private int next;
    private bool hasNext;

    // iterators refers to the first element of the array.
    public PeekingIterator(IEnumerator<int> iterator)
    {
        this.iterator = iterator;
        next = iterator.Current;
        hasNext = true;
    }
    
    // Returns the next element in the iteration without advancing the iterator.
    public int Peek()
    {
        return next;
    }
    
    // Returns the next element in the iteration and advances the iterator.
    public int Next()
    {
        var current = next;

        if (!MoveNext())
            hasNext = false;

        return current;
    }

    private bool MoveNext()
    {
        var moveNext = iterator.MoveNext();
        if (moveNext)
            next = iterator.Current;
        return moveNext;
    }

    // Returns false if the iterator is refering to the end of the array of true otherwise.
    public bool HasNext()
    {
        return hasNext;
    }
}