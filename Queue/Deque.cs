using System;
using DataStructure.List;

namespace DataStructure.Queue
{
    public class Deque<T>
    {
        private DoublyNode<T> _headNode;
        private DoublyNode<T> _tailNode;

        public bool IsEmpty()
        {
            return _headNode == null;
        }

        public void AddToFirst(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>
            {
                Data = data,
                NextNode = _headNode
            };

            if (IsEmpty())
            {
                _tailNode = newNode;
            }
            else
            {
                _headNode.PreviousNode = newNode;
            }

            _headNode = newNode;
        }

        public void AddToLast(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>
            {
                Data = data,
                PreviousNode = _tailNode
            };

            if (IsEmpty())
            {
                _headNode = newNode;
            }
            else
            {
                _tailNode.NextNode = newNode;
            }

            _tailNode = newNode;
        }

        public T RemoveFromFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("Dequeue is empty!");
            }

            T currentData = _headNode.Data;
            _headNode = _headNode.NextNode;

            if (_headNode == null)
            {
                _tailNode = null;
            }
            else
            {
                _headNode.PreviousNode = null;
            }

            return currentData;
        }

        public T RemoveFromLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Dequeue is empty!");
            }

            T currentData = _tailNode.Data;

            _tailNode = _tailNode.PreviousNode;

            if (_tailNode == null)
            {
                _headNode = null;
            }
            else
            {
                _tailNode.NextNode = null;
            }

            return currentData;
        }

        public T GetFromFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("Dequeue is empty!");
            }

            return _headNode.Data;
        }

        public T GetFromLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Dequeue is empty!");
            }

            return _tailNode.Data;
        }
    }
}