using DataStructure.List;

namespace DataStructure.Stack
{
    public class ListStack<T>
    {
        private Node<T> _head;
        public T CurrentData { get; private set; }

        public bool IsEmpty()
        {
            return _head == null;
        }

        public void Push(T data)
        {
            Node<T> newNode = new Node<T>
            {
                Data = data,
                NextNode = _head
            };

            _head = newNode;
        }

        public T Pop()
        {
            if (IsEmpty()) return default(T);

            CurrentData = _head.Data;
            _head = _head.NextNode;

            return CurrentData;
        }

        public T Peek()
        {
            if (IsEmpty()) return default(T);

            CurrentData = _head.Data;

            return _head.Data;
        }
    }
}
