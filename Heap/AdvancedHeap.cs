namespace DataStructure.Heap
{
    class AdvancedHeap<T>
    {
        private enum ChildType
        {
            Left, Right
        }

        public int Count { get; private set; }

        public delegate bool PriorityComparison(T value1, T value2);

        private readonly PriorityComparison _comparison;
        private readonly T[] _array;

        public AdvancedHeap(int length, PriorityComparison comparison)
        {
            _array = new T[length];
            _comparison = comparison;
        }

        private int GetChildNodeIndex(int index, ChildType childType)
        {
            return index * 2 + (childType == ChildType.Left ? 0 : 1);
        }

        private int GetHighPriorityChildIndex(int index)
        {
            int leftIndex = GetChildNodeIndex(index, ChildType.Left);

            if (leftIndex > Count) return 0;
            if (leftIndex == Count) return leftIndex;

            int rightIndex = GetChildNodeIndex(index, ChildType.Right);

            return _comparison(_array[leftIndex], _array[rightIndex]) ? leftIndex : rightIndex;
        }

        public void Insert(T value)
        {
            int index = Count + 1;

            while (index != 1)
            {
                int parentIndex = GetParentNodeIndex(index);

                if (!_comparison(value, _array[parentIndex])) break;

                _array[index] = _array[parentIndex];
                index = parentIndex;
            }

            _array[index] = value;
            Count++;
        }

        public T Delete()
        {
            var returnValue = _array[1];
            var lastValue = _array[Count];

            int parentIndex = 1;

            while (true)
            {
                int childIndex = GetHighPriorityChildIndex(parentIndex);

                if (childIndex == 0) break;
                if (_comparison(lastValue, _array[childIndex])) break;

                _array[parentIndex] = _array[childIndex];
                parentIndex = childIndex;
            }

            _array[parentIndex] = lastValue;
            Count--;

            return returnValue;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }
        private int GetParentNodeIndex(int index)
        {
            return index / 2;
        }
    }
}
