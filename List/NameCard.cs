namespace DataStructure.List
{
    public class NameCard
    {
        private readonly string _name;
        private  string _phoneNumber;

        public NameCard(string name, string phoneNumber)
        {
            _name = name;
            _phoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return "[" + _name + "/" + _phoneNumber + "]";
        }

        public bool CompareName(string name)
        {
            return name == _name;
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }
    }
}
