using System;

namespace DataStructure.List
{
    public class Point
    {
        private readonly int _x;
        private readonly int _y;

        public int X => _x;
        public int Y => _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return "[" + _x + ", " + _y + "]";
        }

        public static int ComparePoint(Point left, Point right)
        {
            if (left._x == right._x && left._y == right._y) return 0;
            if (left._x == right._x) return 1;
            if (left._y == right._y) return 2;

            return -1;
        }
    }
}