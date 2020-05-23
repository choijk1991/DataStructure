using System;

namespace DataStructure.Table
{
    class Person
    {
        public int SocialNumber { get; }
        public string Name { get; }
        public string Address { get; }

        public Person(int number, string name, string address)
        {
            SocialNumber = number;
            Name = name;
            Address = address;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Name : " + Name);
            Console.WriteLine("Address : " + Address);
            Console.WriteLine("Social Number : " + SocialNumber);
        }
    }
}