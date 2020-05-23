using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.List
{
    public class Employee
    {
        public readonly int Number;
        public string Name;

        public Employee(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public static bool Compare(Employee left, Employee right)
        {
            return left.Number == right.Number;
        }
    }
}
