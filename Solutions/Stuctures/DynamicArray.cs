using System;

namespace Solutions.Stuctures
{
    public class DynamicArray<T> : ICollection<T>
    {
        private T[] array;

        public DynamicArray() : this(10)
        {
        }

        public DynamicArray(int capacity)
        {
            array = new T[capacity];
            Capacity = capacity;
        }

        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public bool Exists(T item)
        {
            var findIndex = FindIndex(item);
            return findIndex >= 0;
        }

        public void Clear()
        {
            for (var i = 0; i < Count; i++)
                array[i] = default;

            Count = 0;
        }

        public void Add(T item)
        {
            if (Capacity == Count)
            {
                Capacity *= 2;
                var tempArray = new T[Capacity];
                Array.Copy(array, tempArray, array.Length);
                array = tempArray;
            }

            array[Count] = item;
            ++Count;
        }

        public void Remove(T item)
        {
            var index = FindIndex(item);
            if (index < 0)
                return;

            var j = 0;
            for (var i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    array[i] = default;
                    continue;
                }

                array[j++] = array[i];
            }

            --Count;
        }

        public T this[int index]
        {
            get => Getter(index);
            set => Setter(index, value);
        }

        private int FindIndex(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                var element = array[i];
                if (element.Equals(item))
                    return i;
            }

            return -1;
        }

        private void Setter(int index, T value)
        {
            if (index >= Count || index < 0)
                throw new IndexOutOfRangeException();

            array[index] = value;
        }

        private T Getter(int index)
        {
            if (index >= Count || index < 0)
                throw new IndexOutOfRangeException();

            return array[index];
        }
    }
}