namespace DataStructure.Heap
{
    class PriorityQueue<T>
    {
        private readonly AdvancedHeap<T> _heap;

        public PriorityQueue(int length, AdvancedHeap<T>.PriorityComparison comparison)
        {
            _heap = new AdvancedHeap<T>(length, comparison);
        }

        public bool IsEmpty()
        {
            return _heap.IsEmpty();
        }

        public void Enqueue(T value)
        {
            _heap.Insert(value);
        }

        public T Dequeue()
        {
            return _heap.Delete();
        }
    }
}