using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Model
{
    public class Food : IDrawable
    {
        public Position Position { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.Red;
        public Food(Position position)
        {
            Position = position;
        }

        public void ReLocate(Position position)
        {
            Position = position;
        }

        public IEnumerable<Position> GetPositions()
        {
            return new[] { Position };
        }
    }
}
