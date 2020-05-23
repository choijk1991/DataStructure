namespace DataStructure.List
{
    public class CircuitLinkedList<T>
    {
        private Node<T> _tail;
        private Node<T> _current;
        private Node<T> _before;
        public int CountData { get; private set; }
        public T CurrentData { get; private set; }

        public delegate bool RemoveRuleDelegate(T data);

        public delegate bool FindRuleDelegate(T data);
        
        public void RemoveData(RemoveRuleDelegate removeRule)
        {
            if (CountData == 0) return;
            if (!ReadFirst()) return;

            if (removeRule(CurrentData))
            {
                RemoveData();
            }

            for (int i = 1; i < CountData; i++)
            {
                if (!ReadNext()) continue;
                if (!removeRule(CurrentData)) continue;
                RemoveData();
            }
        }

        public T FindDataFromCurrentPosition(int round)
        {
            for (int i = 0; i < round; i++)
            {
                ReadNext();
            }

            return CurrentData;
        }

        public T FindFirstData(FindRuleDelegate findRule)
        {
            if (!ReadFirst()) return default(T);
            if (findRule(CurrentData)) return CurrentData;

            for (int i = 1; i < CountData; i++)
            {
                if (!ReadNext()) continue;
                if (!findRule(CurrentData)) continue;

                return CurrentData;
            }

            return default(T);
        }

        public override string ToString()
        {
            if (!ReadFirst()) return string.Empty;

            string result = CurrentData.ToString();

            for (int i = 1; i < CountData; i++)
            {
                if (!ReadNext()) continue;
                result += ", " + CurrentData;
            }

            return result;
        }

        public bool ReadFirst()
        {
            if (_tail == null) return false;

            _before = _tail;
            _current = _tail.NextNode;

            CurrentData = _current.Data;

            return true;
        }

        public bool ReadNext()
        {
            if (_tail == null) return false;

            _before = _current;
            _current = _current.NextNode;

            CurrentData = _current.Data;

            return true;
        }

        public T RemoveData()
        {
            Node<T> current = _current;
            T data = current.Data;

            if (current == _tail)
            {
                _tail = _tail == _tail.NextNode ? null : _before;
            }

            _before.NextNode = current.NextNode;
            _current = _before;

            CountData--;

            return data;
        }
        
        public void InsertFromLast(T data)
        {
            Node<T> newNode = new Node<T> { Data = data };

            if (_tail == null)
            {
                _tail = newNode;
                newNode.NextNode = newNode;
            }
            else
            {
                newNode.NextNode = _tail.NextNode;
                _tail.NextNode = newNode;
                _tail = newNode;
            }

            CountData++;
        }

        public void InsertFromFront(T data)
        {
            Node<T> newNode = new Node<T> {Data = data};

            if (_tail == null)
            {
                _tail = newNode;
                newNode.NextNode = newNode;
            }
            else
            {
                newNode.NextNode = _tail.NextNode;
                _tail.NextNode = newNode;
            }

            CountData++;
        }
    }
}