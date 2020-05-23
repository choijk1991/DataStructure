using System;
using DataStructure.List;

namespace DataStructure.Quest
{
    public static class ListQuest
    {
        public static void DisplayQuest6()
        {
            DummyDoublyLinkedList<int> list = new DummyDoublyLinkedList<int>();

            for (int i = 1; i <= 8; i++)
            {
                list.Insert(i);
            }

            Console.WriteLine(list);

            list.RemoveData(data => data % 2 == 0);

            Console.WriteLine(list);
        }

        public static void DisplayQuest5()
        {
            CircuitLinkedList<Employee> list = new CircuitLinkedList<Employee>();

            list.InsertFromLast(new Employee(1, "A"));
            list.InsertFromLast(new Employee(2, "B"));
            list.InsertFromLast(new Employee(3, "C"));
            list.InsertFromLast(new Employee(4, "D"));

            Console.WriteLine(list.FindNextDuty("C", 7));
        }

        public static string FindNextDuty(this CircuitLinkedList<Employee> list, string name, int days)
        {
            Employee target = list.FindFirstData(data => data.Name == name);

            if (target == default(Employee)) return string.Empty;

            Employee nextTarget = list.FindDataFromCurrentPosition(7);

            return nextTarget.Name;
        }

        public static void DisplayQuest4()
        {
            SimpleLinkedList<Point> list = new SimpleLinkedList<Point>();

            list.Insert(new Point(2, 1));
            list.Insert(new Point(2, 2));
            list.Insert(new Point(3, 1));
            list.Insert(new Point(3, 2));

            list.SetSortRule(delegate(Point left, Point right)
            {
                if (left.X < right.X) return true;
                if (left.X != right.X) return false;
                return left.Y < right.Y;
            });

            Console.WriteLine(list);
        }

        public static void DisplayQuest3()
        {
            Node<int> head = null;

            while (true)
            {
                Console.Write("Input Integer : ");
                int data = int.Parse(Console.ReadLine());

                if (data < 1) break;

                Node<int> newNode = new Node<int>
                {
                    Data = data,
                    NextNode = null
                };
                
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    newNode.NextNode = head;
                    head = newNode;
                }
            }

            Console.WriteLine("Print All Data");

            if (head == null)
            {
                Console.WriteLine("There is No Data");
            }
            else
            {
                Node<int> current = head;
                Console.Write(current.Data);

                while (current.NextNode != null)
                {
                    current = current.NextNode;
                    Console.Write(", " + current.Data);
                }

                Console.WriteLine();
            }
        }

        public static void DisplayQuest2()
        {
            ArrayList<NameCard> list = new ArrayList<NameCard>();

            list.InsertData(new NameCard("ABC", "010-0000-0000"));
            list.InsertData(new NameCard("DEF", "010-1111-1111"));
            list.InsertData(new NameCard("GHI", "010-2222-2222"));

            if (list.SearchByName("DEF"))
            {
                Console.WriteLine(list.CurrentData);
            }

            list.ChangeNumberByName("ABC", "010-9999-9999");
            Console.WriteLine(list);
            list.DeleteCardByName("DEF");
            Console.WriteLine(list);
        }

        private static void DeleteCardByName(this ArrayList<NameCard> list, string name)
        {
            if (!list.SearchByName(name)) return;

            list.RemoveData();
        }

        private static bool SearchByName(this ArrayList<NameCard> list, string name)
        {
            if (!list.GetFirstData()) return false;
            if (list.CurrentData.CompareName(name)) return true;

            while (list.GetNextData())
            {
                if (!list.CurrentData.CompareName(name)) continue;

                return true;
            }

            return false;
        }

        private static void ChangeNumberByName(this ArrayList<NameCard> list, string name, string phoneNumber)
        {
            if (!list.SearchByName(name)) return;

            list.CurrentData.ChangePhoneNumber(phoneNumber);
        }

        public static void DisplayQuest1()
        {
            ArrayList<int> list = new ArrayList<int>();

            for (int i = 1; i < 9; i++)
            {
                bool result = list.InsertData(i);
                string resultString = result ? "완료" : "실패";

                Console.WriteLine(i + " 입력 : " + resultString);
            }

            Console.WriteLine("합계 : " + GetEntireSummery(list));

            DeleteValues(list);

            Console.WriteLine(list);
        }
        
        private static void DeleteValues(ArrayList<int> list)
        {
            if (!list.GetFirstData()) return;

            if (DecideMultiple(list.CurrentData))
            {
                list.RemoveData();
            }

            while (list.GetNextData() && DecideMultiple(list.CurrentData))
            {
                list.RemoveData();
            }
        }

        private static bool DecideMultiple(int value)
        {
            if (value % 2 == 0) return true;
            if (value % 3 == 0) return true;

            return false;
        }

        private static int GetEntireSummery(ArrayList<int> list)
        {
            if (!list.GetFirstData()) return -1;

            int sum = list.CurrentData;

            while (list.GetNextData())
            {
                sum += list.CurrentData;
            }

            return sum;
        }
    }
}