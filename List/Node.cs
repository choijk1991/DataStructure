namespace DataStructure.List
{
    public class Node<T>
    {
        public T Data;
        public Node<T> NextNode;

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}