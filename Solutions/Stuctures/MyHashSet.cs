namespace Solutions.Stuctures
{
    public class MyHashSet
    {
        private readonly int capacity;
        private readonly Entry[] entries;
        private int count;

        public MyHashSet()
        {
            count = 0;
            capacity = 0x1 << 5;
            entries = new Entry[capacity];
        }

        public void Add(int key)
        {
            if (Contains(key))
                return;

            var index = GetIndex(key);

            entries[index] = new Entry(key)
            {
                Next = entries[index]
            };

            count++;
        }

        public void Remove(int key)
        {
            var index = GetIndex(key);
            var entry = entries[index];
            Entry prev = null;
            while (entry != null)
            {
                if (entry.Key == key)
                    break;

                entry = entry.Next;
                prev = entry;
            }

            if (entry == null)
                return;

            if (prev == null)
                entries[index] = entry.Next;
            else
                prev.Next = entry.Next;

            count--;
        }

        public bool Contains(int key)
        {
            var index = GetIndex(key);
            var entry = entries[index];
            while (entry != null)
            {
                if (entry.Key == key)
                    return true;

                entry = entry.Next;
            }

            return false;
        }

        private int GetIndex(int key)
        {
            var hashCode = key.GetHashCode();
            return hashCode % capacity;
        }

        private class Entry
        {
            public readonly int Key;
            public Entry Next;

            public Entry(int key)
            {
                Key = key;
            }
        }
    }
}