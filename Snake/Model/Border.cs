using System;
using System.Collections.Generic;

namespace Snake.Model
{
    public class Border : IDrawable
    {
        public HashSet<Position> BorderPositions { get; private set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
        public Border(int width, int height)
        {
            BorderPositions = CreateBorder(width, height);
        }

        private HashSet<Position> CreateBorder(int width, int height)
        {
            var border = new HashSet<Position>();

            for (int i = 0; i < width; i++)
            {
                border.Add(new Position(i, 0));
                border.Add(new Position(i, height - 1));
            }

            for (int i = 0; i < height; i++)
            {
                border.Add(new Position(0, i));
                border.Add(new Position(width - 1, i));
            }

            return border;
        }

        public IEnumerable<Position> GetPositions()
        {
            foreach (var pos in BorderPositions)
                yield return pos;
        }
    }
}
