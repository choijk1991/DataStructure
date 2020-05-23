namespace DataStructure.List
{
    public class DoublyLinkedList<T>
    {
        private DoublyNode<T> _headNode;
        private DoublyNode<T> _currentNode;

        public int CountData { get; private set; }
        public T CurrentData { get; private set; }
        
        public void Insert(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>
            {
                Data = data,
                NextNode = _headNode
            };

            if (_headNode != null)
            {
                _headNode.PreviousNode = newNode;
            }

            newNode.PreviousNode = null;

            _headNode = newNode;

            CountData++;
        }
        
        public bool ReadFirst()
        {
            if (_headNode == null) return false;

            _currentNode = _headNode;
            CurrentData = _currentNode.Data;

            return true;
        }

        public bool ReadNext()
        {
            if (_currentNode.NextNode == null) return false;

            _currentNode = _currentNode.NextNode;
            CurrentData = _currentNode.Data;

            return true;
        }

        public bool ReadPrevious()
        {
            if (_currentNode.PreviousNode == null) return false;

            _currentNode = _currentNode.PreviousNode;
            CurrentData = _currentNode.Data;

            return true;
        }
    }
}