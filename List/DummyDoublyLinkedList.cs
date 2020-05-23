namespace DataStructure.List
{
    public class DummyDoublyLinkedList<T>
    {
        private readonly DoublyNode<T> _headNode;
        private readonly DoublyNode<T> _tailNode;

        private DoublyNode<T> _currentNode;

        public int CountData { get; private set; }

        public delegate bool RemoveCondition(T data);

        public DummyDoublyLinkedList()
        {
            _headNode = new DoublyNode<T>();
            _tailNode = new DoublyNode<T>();

            _headNode.NextNode = _tailNode;
            _tailNode.PreviousNode = _headNode;
        }

        public void Insert(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>
            {
                Data = data,
                PreviousNode = _tailNode.PreviousNode
            };

            _tailNode.PreviousNode.NextNode = newNode;
            newNode.NextNode = _tailNode;
            _tailNode.PreviousNode = newNode;

            CountData++;
        }

        private bool ReadFirst()
        {
            if (_headNode.NextNode == _tailNode) return false;

            _currentNode = _headNode.NextNode;

            return true;
        }

        private bool ReadNext()
        {
            if (_currentNode.NextNode == _tailNode) return false;

            _currentNode = _currentNode.NextNode;

            return true;
        }

        private void RemoveCurrentNode()
        {
            DoublyNode<T> currentNode = _currentNode;

            currentNode.PreviousNode.NextNode = currentNode.NextNode;
            currentNode.NextNode.PreviousNode = currentNode.PreviousNode;

            _currentNode = currentNode.PreviousNode;

            CountData--;
        }

        public override string ToString()
        {
            if (!ReadFirst()) return string.Empty;

            string result = _currentNode.Data.ToString();

            while (ReadNext())
            {
                result += ", " + _currentNode.Data;
            }

            return result;
        }

        public void RemoveData(RemoveCondition condition)
        {
            if (!ReadFirst()) return;

            if (condition(_currentNode.Data))
            {
                RemoveCurrentNode();
            }

            while (ReadNext())
            {
                if (!condition(_currentNode.Data)) continue;
                RemoveCurrentNode();
            }
        }
    }
}