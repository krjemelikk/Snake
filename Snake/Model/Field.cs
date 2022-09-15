using System;
using System.Linq;

namespace Snake.Model
{
    public class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int EmptyPositionsCount { get; set; }
        public Snake Snake { get; set; }
        public Food Food { get; set; }
        public Border Border { get; set; }

        public event Action OnSnakeEat;
        public event Action OnSnakeDeath;

        private readonly Random _random;

        public Field() : this(30,30){}

        public Field(int width, int height)
        {
            Width = width;
            Height = height;

            _random = new Random();
            Border = new Border(width, height);
            Snake = new Snake(new Position(width / 2, height / 2));
            Food = new Food(GetFreeRandomPosition());

            EmptyPositionsCount = height * width - Border.BorderPositions.Count;

            OnSnakeEat += Snake.Eat;
            OnSnakeEat += ReSpawnFood;

        }

        public void UpdateSnake(Direction? snakeDirection)
        {
            Snake.Move(snakeDirection);

            var snakeHead = Snake.Body.First.Value;
            if(Border.BorderPositions.Any(pos => pos.Equals(snakeHead)) || Snake.IsEatItself())
               OnSnakeDeath?.Invoke();

            if (snakeHead.Equals(Food.Position))
                OnSnakeEat?.Invoke();
        }

        public Position GetFreeRandomPosition()
        {
            var IsEmptyPosAvailable = Snake.Length != EmptyPositionsCount;
            Position freePos;
            do
            {
                freePos = new Position(
                    _random.Next(1, Width - 1),
                    _random.Next(1, Height - 1));

            } while (Snake.Body.Any(pos => pos.Equals(freePos)) || !IsEmptyPosAvailable);

            return freePos;
        }

        public void ReSpawnFood()
        {
            Food.ReLocate(GetFreeRandomPosition());
        }
    }
}
