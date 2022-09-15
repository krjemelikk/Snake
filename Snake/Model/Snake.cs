using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.Model
{
    public class Snake : IDrawable
    {
        public int Length { get; set; }
        public Direction? CurrentDirection { get; set; }
        public LinkedList<Position> Body { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
        public Position DeletedPos { get; set; }

        public Action Eat;

        public Snake(Position position)
        {
            Length = 1;
            CurrentDirection = Direction.Right;

            Body = new LinkedList<Position>();
            for (int i = 0; i < Length; i++)
                Body.AddFirst(new Position(position.X - i,position.Y));

            Eat = EatFood;
        }

        public void EatFood()
        {
            Body.AddFirst(Body.First.Value);
        }

        public void Move(Direction? direction)
        {
            if (direction == null || IsReverse(direction))
                direction = CurrentDirection;

            var firstPos = Body.First.Value;
            DeletedPos = Body.Last.Value;
            Body.RemoveLast();

            switch (direction)
            {
                case Direction.Up:
                    Body.AddFirst(new Position(firstPos.X, firstPos.Y - 1));
                    break;
                case Direction.Down:
                    Body.AddFirst(new Position(firstPos.X, firstPos.Y + 1));
                    break;
                case Direction.Right:
                    Body.AddFirst(new Position(firstPos.X + 1, firstPos.Y));
                    break;
                case Direction.Left:
                    Body.AddFirst(new Position(firstPos.X - 1, firstPos.Y));
                    break;
            }

            CurrentDirection = direction;
        }
        private bool IsReverse(Direction? direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return CurrentDirection == Direction.Down;
                case Direction.Down:
                    return CurrentDirection == Direction.Up;
                case Direction.Right:
                    return CurrentDirection == Direction.Left;
                case Direction.Left:
                    return CurrentDirection == Direction.Right;
            }

            return false;
        }

        public bool IsEatItself()
        {
            var snakeHead = Body.First.Value;
            return Body.Skip(1).Any(pos => pos.Equals(snakeHead));
        }

        public IEnumerable<Position> GetPositions()
        { 
            return Body;
        }
    }
}
