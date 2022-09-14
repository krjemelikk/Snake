using System;
using System.Collections.Generic;
using System.Text;
using Snake.Model;

namespace Snake
{
    public class InputControl
    {
        public Direction? GetCurrentDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return Direction.Up;

                case ConsoleKey.DownArrow:
                    return Direction.Down;

                case ConsoleKey.RightArrow:
                    return Direction.Right;

                case ConsoleKey.LeftArrow:
                    return Direction.Left;

                default:
                    return null;
            }
        }
    }
}
