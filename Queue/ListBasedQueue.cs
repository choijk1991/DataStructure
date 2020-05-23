using System;
using DataStructure.List;

namespace DataStructure.Queue
{
    public class ListBasedQueue<T>
    {
        private Node<T> _frontNode;
        private Node<T> _rearNode;

        public bool IsEmpty()
        {
            return _frontNode == null;
        }

        public void Enqueue(T data)
        {
            Node<T> newNode = new Node<T> {Data = data};

            if (IsEmpty())
            {
                _frontNode = newNode;
                _rearNode = newNode;

                return;
            }

            _rearNode.NextNode = newNode;
            _rearNode = newNode;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty!");
            }

            T currentData = _frontNode.Data;
            _frontNode = _frontNode.NextNode;

            return currentData;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty!");
            }

            return _frontNode.Data;
        }
    }
}