using DataStructure.List;

namespace DataStructure.Table
{
    class ChainingTable<T>
    {
        public delegate int HashFunction(int key);

        private readonly SimpleLinkedList<ChainingSlot<T>>[] _listArray;

        private readonly HashFunction _function;

        public ChainingTable(HashFunction function)
        {
            _function = function;
            _listArray = new SimpleLinkedList<ChainingSlot<T>>[100];

            for (int i = 0; i < _listArray.Length; i++)
            {
                _listArray[i] = new SimpleLinkedList<ChainingSlot<T>>();
            }
        }

        public void Insert(int key, T value)
        {
            ChainingSlot<T> slot = new ChainingSlot<T>(key, value);
            var searchResult = Search(key);

            if (searchResult != null) return;

            int hashKey = _function(key);

            _listArray[hashKey].Insert(slot);
        }

        public T Delete(int key)
        {
            int hashKey = _function(key);
            var list = _listArray[hashKey];

            if (!list.ReadFirst()) return default(T);

            var slot = list.CurrentNode.Data;
            T value;

            if (slot.Key == key)
            {
                value = slot.Value;

                list.RemoveData(slot);

                return value;
            }

            while (list.ReadNext())
            {
                slot = list.CurrentNode.Data;

                if (slot.Key != key) continue;

                value = slot.Value;

                list.RemoveData(slot);

                return value;
            }

            return default(T);
        }

        public T Search(int key)
        {
            int hashKey = _function(key);
            var list = _listArray[hashKey];

            if (!list.ReadFirst()) return default(T);

            var slot = list.CurrentNode;

            if (slot.Data.Key == key) return slot.Data.Value;

            while (list.ReadNext())
            {
                slot = list.CurrentNode;

                if (slot.Data.Key != key) continue;

                return slot.Data.Value;
            }

            return default(T);
        }
    }
}