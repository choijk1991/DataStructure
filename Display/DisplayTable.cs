using System;
using DataStructure.Table;

namespace DataStructure.Display
{
    static class DisplayTable
    {
        public static void DisplayEmployeeTable()
        {
            EmployeeInformation[] employees = new EmployeeInformation[1000];

            employees[129] = new EmployeeInformation(129, 29);

            Console.WriteLine(employees[129].Number + "/"+employees[129].Age);
        }

        public static void DisplayChainingTable()
        {
            ChainingTable<Person> table = new ChainingTable<Person>(key => key % 100);

            Person person1 = new Person(900254, "Lee", "Seoul");
            Person person2 = new Person(900139, "Kim", "Jeju");
            Person person3 = new Person(900827, "Han", "Kangwon");

            table.Insert(person1.SocialNumber, person1);
            table.Insert(person2.SocialNumber, person2);
            table.Insert(person3.SocialNumber, person3);

            DisplayChainingTableSearch(table, 900254);
            DisplayChainingTableSearch(table, 900139);
            DisplayChainingTableSearch(table, 900827);

            DeleteChainingTableSearch(table, 900254);
            DeleteChainingTableSearch(table, 900139);
            DeleteChainingTableSearch(table, 900827);
        }

        private static void DeleteChainingTableSearch(ChainingTable<Person> table, int socialNo)
        {
            var person = table.Delete(socialNo);

            person?.ShowInfo();
        }

        private static void DisplayChainingTableSearch(ChainingTable<Person> table, int socialNo)
        {
            var person = table.Search(socialNo);

            person?.ShowInfo();
        }

        public static void DisplayPersonHashTable()
        {
            Table<Person> table = new Table<Person>(number => number % 100);

            Person person1 = new Person(20120003, "Lee", "Seoul");
            Person person2 = new Person(20120012, "Kim", "Jeju");
            Person person3 = new Person(20120049, "Han", "Kangwon");

            table.Insert(person1.SocialNumber, person1);
            table.Insert(person2.SocialNumber, person2);
            table.Insert(person3.SocialNumber, person3);

            DisplayPersonInfo(table, 20120003);
            DisplayPersonInfo(table, 20120012);
            DisplayPersonInfo(table, 20120049);

            table.Delete(20120003);
            table.Delete(20120012);
            table.Delete(20120049);
        }

        private static void DisplayPersonInfo(Table<Person> table, int key)
        {
            Person person = table.Search(key);

            person?.ShowInfo();
            Console.WriteLine();
        }

        public static void DisplayEmployeeHashTable()
        {
            var employees = new EmployeeInformation[100];

            var employee1 = new EmployeeInformation(20120003, 42);
            var employee2 = new EmployeeInformation(20120012, 33);
            var employee3 = new EmployeeInformation(20120049, 47);

            employees[employee1.HashNumber] = employee1;
            employees[employee2.HashNumber] = employee2;
            employees[employee3.HashNumber] = employee3;

            employee1 = employees[20120003 % 100];
            employee2 = employees[20120012 % 100];
            employee3 = employees[20120049 % 100];

            Console.WriteLine("Employee No. : " + employee1.Number + " Age : " + employee1.Age);
            Console.WriteLine("Employee No. : " + employee2.Number + " Age : " + employee2.Age);
            Console.WriteLine("Employee No. : " + employee3.Number + " Age : " + employee3.Age);
        }
    }
}