namespace Solutions.Stuctures
{
    public interface ICollection<T>
    {
        int Count { get; }
        int Capacity { get; }
        T this[int index] { get; set; }
        bool Exists(T item);
        void Clear();
        void Add(T item);
        void Remove(T item);
    }
}