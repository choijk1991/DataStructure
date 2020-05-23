namespace DataStructure.Heap
{
    class ArrayHeap<T>
    {
        private enum ChildType
        {
            Left, Right
        }

        private int _count;
        private readonly ArrayHeapElement<T>[] _array;

        public ArrayHeap(int maxSpace)
        {
            _count = 0;
            _array = new ArrayHeapElement<T>[maxSpace];
        }

        public void InsertValue(T value, int priority)
        {
            int index = _count + 1;

            while (index != 1) // If It isn't root node, loop these.
            {
                int parentIndex = GetParentNodeIndex(index);

                if (priority >= _array[parentIndex].Priority) break; // if An inserted priority is lower than their parent node, return.

                _array[index] = _array[parentIndex]; // A parent node gets lower to current Index.
                index = GetParentNodeIndex(index); // The Index of new node gets upper to their parent node index.
            }

            _array[index] = new ArrayHeapElement<T>(value, priority); // Save.
            _count += 1;
        }

        public T Delete()
        {
            T result = _array[1].Value; // It keeps root data to return.
            ArrayHeapElement<T> lastElement = _array[_count]; // It keeps terminal node.
            int parentIndex = 1; // It keeps index of root node.
            
            while (true)
            {
                int childIndex = GetHighPriorityChildIndex(parentIndex); // it finds index of more high priority child node.

                if (childIndex == 0) break;
                if (lastElement.Priority <= _array[childIndex].Priority) break; 
                // It compares priority between more high priority child and last child.
                // If The priority of last child is higher than more high priority, return.

                _array[parentIndex] = _array[childIndex]; // More high priority child node switches to its parent node.
                parentIndex = childIndex; // Same meaning as upper line.
            }

            _array[parentIndex] = lastElement; // It saves last node to parent node.
            _count -= 1;

            return result;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        private int GetParentNodeIndex(int index)
        {
            return index / 2;
        }

        private int GetChildNodeIndex(int index, ChildType childType)
        {
            return index * 2 + (childType == ChildType.Left ? 0 : 1);
        }

        private int GetHighPriorityChildIndex(int index)
        {
            int leftIndex = GetChildNodeIndex(index, ChildType.Left);

            if (leftIndex > _count) return 0; // No Child node exists. : Terminal node
            if (leftIndex == _count) return leftIndex; // The node has only Left side child. This child is terminal node.

            int rightIndex = GetChildNodeIndex(index, ChildType.Right); // This node has both side children.

            return _array[leftIndex].Priority > _array[rightIndex].Priority ? rightIndex : leftIndex; // It compares more high priority between left and right.
        }
    }
}