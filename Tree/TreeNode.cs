namespace DataStructure.Tree
{
    public class TreeNode<T>
    {
        public T Data;

        public TreeNode<T> LeftNode;
        public TreeNode<T> RightNode;

        public int CountChildren()
        {
            return (LeftNode == null ? 0 : 1) + (RightNode == null ? 0 : 1);
        }
    }
}