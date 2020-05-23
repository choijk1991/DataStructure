using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Stack
{
    public class ArrayStack<T>
    {
        private readonly T[] _array;
        private int _index;
        public T CurrentData { get; private set; }

        public ArrayStack()
        {
            _array = new T[100];
            _index = -1;
        }

        public bool IsEmpty()
        {
            return _index == -1;
        }

        public void Push(T data)
        {
            _index++;
            _array[_index] = data;
        }

        public bool Pop()
        {
            if (IsEmpty()) return false;

            CurrentData = _array[_index];
            _index--;

            return true;
        }

        public bool Peek()
        {
            if (IsEmpty()) return false;

            CurrentData = _array[_index];

            return true;
        }
    }
}