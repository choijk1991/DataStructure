using System;

namespace DataStructure.Queue
{
    public class CircularBasedQueue<T>
    {
        private int _frontIndex;
        private int _rearIndex;
        private readonly T[] _dataArray;

        public CircularBasedQueue()
        {
            _dataArray = new T[100];
        }

        public bool IsEmpty()
        {
            return _frontIndex == _rearIndex;
        }

        private int GetNextPosition(int position)
        {
            if (position == _dataArray.Length - 1) return 0;

            return position + 1;
        }

        public void Enqueue(T data)
        {
            if (GetNextPosition(_rearIndex) == _frontIndex)
            {
                throw new Exception("Queue is full. What should i do?");
            }

            _rearIndex = GetNextPosition(_rearIndex);
            _dataArray[_rearIndex] = data;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is Empty. What should i do?");
            }

            _frontIndex = GetNextPosition(_frontIndex);

            return _dataArray[_frontIndex];
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is Empty. What should i do?");
            }

            return _dataArray[GetNextPosition(_frontIndex)];
        }
    }
}