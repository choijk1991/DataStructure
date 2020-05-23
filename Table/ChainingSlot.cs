namespace DataStructure.Table
{
    class ChainingSlot<T>
    {
        public int Key { get; }
        public T Value { get; }
        public ChainingSlot<T> NextSlot;

        public ChainingSlot(int key, T value)
        {
            Key = key;
            Value = value;
        }
    }
}