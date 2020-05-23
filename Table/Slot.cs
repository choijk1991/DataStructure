namespace DataStructure.Table
{
    enum SlotStatus
    {
        Empty, // 비었음
        Deleted, // 없어졌음
        InUse // 사용하고 있음
    }

    class Slot<T>
    {
        public int Key { get; }
        public T Value { get; }
        public SlotStatus Status;

        public Slot()
        {
            Status = SlotStatus.Empty;
        }

        public Slot(int key, T value)
        {
            Key = key;
            Value = value;
            Status = SlotStatus.InUse;
        }
    }
}