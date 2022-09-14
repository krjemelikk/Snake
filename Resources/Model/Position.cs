using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Model
{
    public struct Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X - {X} | Y - {Y}";
        }
    }
}
