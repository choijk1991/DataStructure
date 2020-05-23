using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Table
{
    class EmployeeInformation
    {
        public int Number { get; }
        public int Age { get; }

        public int HashNumber => GetHashNumber();

        public EmployeeInformation(int number, int age)
        {
            Number = number;
            Age = age;
        }

        private int GetHashNumber()
        {
            return Number % 100;
        }
    }
}