namespace DataStructure.List
{
    public class ArrayList<T>
    {
        private readonly T[] _array;
        private int _currentPosition;

        public int DataCount { get; private set; }
        public T CurrentData { get; private set; }

        public ArrayList()
        {
            _array = new T[100];
            DataCount = 0;
            _currentPosition = -1;
        }

        public bool InsertData(T data)
        {
            if (DataCount > _array.Length) return false;

            _array[DataCount] = data;
            DataCount++;

            return true;
        }

        public bool GetFirstData()
        {
            if (DataCount == 0) return false;

            _currentPosition = 0;
            CurrentData = _array[_currentPosition];

            return true;
        }

        public bool GetNextData()
        {
            if (_currentPosition >= DataCount - 1) return false;

            _currentPosition++;
            CurrentData = _array[_currentPosition];

            return true;
        }

        public T RemoveData()
        {
            T currentData = _array[_currentPosition];

            for (int i = _currentPosition; i < DataCount - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            DataCount--;
            _currentPosition--;

            return currentData;
        }

        public override string ToString()
        {
            string result = string.Empty;

            if (!GetFirstData()) return result;

            result = CurrentData.ToString();

            while (GetNextData())
            {
                result += ", " + CurrentData;
            }

            return result;
        }
    }
}