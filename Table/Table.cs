namespace DataStructure.Table
{
    class Table<T>
    {
        public delegate int HashFunction(int number);

        private readonly Slot<T>[] _slots;
        private readonly HashFunction _function;

        public Table(HashFunction function)
        {
            _slots = new Slot<T>[100];

            for (int i = 0; i < _slots.Length; i++)
            {
                _slots[i] = new Slot<T>();
            }

            _function = function;
        }

        public void Insert(int key, T value)
        {
            int hashKey = _function(key);

            _slots[hashKey] = new Slot<T>(key, value);
        }

        public T Search(int key)
        {
            int hashKey = _function(key);

            return _slots[hashKey].Status != SlotStatus.InUse ? default(T) : _slots[hashKey].Value;
        }

        public void Delete(int key)
        {
            int hashKey = _function(key);

            if (_slots[hashKey].Status != SlotStatus.InUse) return;

            _slots[hashKey] = new Slot<T> {Status = SlotStatus.Deleted};
        }
    }
}