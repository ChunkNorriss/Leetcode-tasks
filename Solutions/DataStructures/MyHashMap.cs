using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Solutions.DataStructures;



public class MyHashMapNative
{
    private readonly Dictionary<int, int> dictionary;

    public MyHashMapNative()
    {
        dictionary = new Dictionary<int, int>();
    }

    public void Put(int key, int value)
    {
        dictionary[key] = value;
    }

    public int Get(int key)
    {
        if (dictionary.TryGetValue(key, out var value))
            return value;

        return -1;
    }

    public void Remove(int key)
    {
        dictionary.Remove(key);
    }
}


public class MyHashMap {

    private struct Entry
    {
        public int HashCode;
        public int Key;
        public int Value;
        public int Next;
    }

    private int[] buckets;
    private Entry[] entries;
    private int capacity;
    private int nextIndex;
    

    public MyHashMap() : this(10)
    {
    }
    
    public MyHashMap(int capacity)
    {
        this.capacity = capacity;
        buckets = new int[capacity];
        entries = new Entry[capacity];
    }
    
    public void Put(int key, int value)
    {
        if (nextIndex == capacity)
        {
            Resize();
        }
        
        ref var bucket = ref GetBucketIndex(key);
        var i = bucket - 1;

        if (i < 0)
        {
            ++nextIndex;
            bucket = nextIndex;
            entries[bucket -1] = new Entry
            {
                Key = key,
                Value = value,
                HashCode = key.GetHashCode(),
                Next = -1
            };
            
            return;
        }
        
        ref var entry = ref Unsafe.NullRef<Entry>();
            
        while (i >= 0)
        {
            entry = ref entries[i];
            if (entry.Key == key)
            {
                entry.Value = value;
                return;
            }
                
            i = entry.Next;
        }
        
        entry.Next = nextIndex++;
        entries[entry.Next] = new Entry
        {
            Key = key,
            Value = value,
            HashCode = key.GetHashCode(),
            Next = -1
        };
    }

    private void Resize()
    {
        var oldEntries = entries;
        capacity <<= 1;
        nextIndex = 0;
        buckets = new int[capacity];
        entries = new Entry[capacity];

        foreach (var entry in oldEntries)
        {
            if (entry.Next == -2)
                continue;
            Put(entry.Key, entry.Value);
        }
    }

    public int Get(int key)
    {
        ref var bucket = ref GetBucketIndex(key);
        var i = bucket - 1;

        if (i < 0) return -1;

        while (i >= 0)
        {
            ref var entry = ref entries[i];
            if (entry.Key == key)
                return entry.Value;

            i = entry.Next;
        }

        return -1;
    }
    
    public void Remove(int key)
    {
        ref var bucket = ref GetBucketIndex(key);
        var i = bucket - 1;

        if (i < 0) 
            return;

        ref var entry = ref entries[i];
        if (entry.Key == key)
        {
            bucket = entry.Next + 1;
            entry.Next = -2;
            return;
        }

        while (entry.Next >= 0)
        {
            ref var prevEntry = ref entry;
            entry = ref entries[entry.Next];
            
            if (entry.Key != key)
                continue;
            
            prevEntry.Next = entry.Next;
            entry.Next = -2;
            return;
        }
        
    }

    private ref int GetBucketIndex(int key)
    {
        var hashCode = key.GetHashCode();
        return ref buckets[hashCode % buckets.Length];
    }
}