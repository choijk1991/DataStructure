namespace DataStructure.List
{
    public class SimpleLinkedList<T>
    {
        private readonly Node<T> _headNode;
        private Node<T> _beforeNode;

        public Node<T> CurrentNode { get; private set; }

        public delegate bool CompareDelegate(T left, T right);

        private CompareDelegate _compareStandard;

        public int CountData { get; private set; }

        public SimpleLinkedList()
        {
            _headNode = new Node<T> {NextNode = null};
            CountData = 0;
            _compareStandard = null;
        }

        public void Insert(T data)
        {
            if (_compareStandard == null)
            {
                InsertToHead(data);
                return;
            }

            InsertBySort(data);
        }

        public void SetSortRule(CompareDelegate compareStandard)
        {
            _compareStandard = compareStandard;
        }

        private void InsertBySort(T data)
        {
            Node<T> newNode = new Node<T> {Data = data};
            Node<T> preDummy = _headNode;

            while (preDummy.NextNode != null && _compareStandard(data, preDummy.NextNode.Data))
            {
                preDummy = preDummy.NextNode;
            }

            newNode.NextNode = preDummy.NextNode;
            preDummy.NextNode = newNode;

            CountData++;
        }

        public override string ToString()
        {
            if (!ReadFirst()) return string.Empty;

            string result = CurrentNode.Data.ToString();

            while (ReadNext())
            {
                result += ", " + CurrentNode.Data;
            }

            return result;
        }

        public void RemoveData(T data)
        {
            if (!ReadFirst()) return;

            if (CurrentNode.Data.Equals(data))
            {
                Remove();
            }

            while (ReadNext())
            {
                if (CurrentNode.Data.Equals(data))
                {
                    Remove();
                }
            }
        }

        private T Remove()
        {
            Node<T> node = CurrentNode;
            T data = node.Data;

            _beforeNode.NextNode = CurrentNode.NextNode;
            CurrentNode = _beforeNode;

            CountData--;

            return data;
        }

        public bool ReadFirst()
        {
            if (_headNode.NextNode == null) return false;

            _beforeNode = _headNode;
            CurrentNode = _headNode.NextNode;

            return true;
        }

        public bool ReadNext()
        {
            if (CurrentNode.NextNode == null) return false;

            _beforeNode = CurrentNode;
            CurrentNode = CurrentNode.NextNode;

            return true;
        }

        private void InsertToHead(T data)
        {
            Node<T> newNode = new Node<T>
            {
                Data = data,
                NextNode = _headNode.NextNode
            };

            _headNode.NextNode = newNode;

            CountData++;
        }
    }
}
