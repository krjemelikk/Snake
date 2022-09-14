using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Model
{
    public interface IDrawable
    {
        public ConsoleColor Color { get; set; }
        public IEnumerable<Position> GetPositions();
    }
}
