namespace DataStructure.Heap
{
    class ArrayHeapElement<T>
    {
        public int Priority { get; }
        public T Value { get; }

        public ArrayHeapElement(T value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }
}