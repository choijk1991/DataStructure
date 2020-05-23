using DataStructure.List;

namespace DataStructure.Stack
{
    public class CircuitListStack<T>
    {
        private readonly CircuitLinkedList<T> _list;
        public T CurrentData { get; private set; }

        public CircuitListStack()
        {
            _list = new CircuitLinkedList<T>();
        }

        public bool IsEmpty()
        {
            return _list.CountData == 0;
        }

        public void Push(T data)
        {
            _list.InsertFromFront(data);
        }

        public void Pop()
        {
            if (!_list.ReadFirst()) return;

            CurrentData = _list.CurrentData;

            _list.RemoveData();
        }

        public void Peek()
        {
            if (!_list.ReadFirst()) return;

            CurrentData = _list.CurrentData;
        }
    }
}