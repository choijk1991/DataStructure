namespace DataStructure.Queue
{
    public class Hamburger
    {
        public string Name { get; private set; }
        public int Term { get; private set; }
        public int Count { get; set; }

        public Hamburger(string name, int term)
        {
            Name = name;
            Term = term;
        }
    }
}