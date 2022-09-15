using Snake.Model;
using System;
using System.Threading;
namespace Snake
{
    public class Game
    {
        public InputControl InputControl { get; set; }
        public Canvas Canvas { get; set; }
        public Field Field { get; set; }

        private int _frameTime;
        private bool _isFinished;

        public Game()
        {
            Init();
        }

        public void Init()
        {
            InputControl = new InputControl();
            Canvas = new Canvas();
            Field = new Field();
            _isFinished = false;
            _frameTime = 100;

            Field.OnSnakeDeath += () => _isFinished = true;
            Field.OnSnakeEat += () => Canvas.DrawObject(Field.Food);
        }

        public void Run()
        {
            Canvas.DrawObject(Field.Border);
            Canvas.DrawObject(Field.Snake);
            Canvas.DrawObject(Field.Food);

            while (!_isFinished)
            {
                Direction? dir = null;
                if (Console.KeyAvailable)
                    dir = InputControl.GetCurrentDirection(Console.ReadKey(true).Key);

                Field.UpdateSnake(dir);

                Canvas.DrawObject(Field.Snake);
                Canvas.UnDrawPixel(Field.Snake.DeletedPos);

                Thread.Sleep(_frameTime);
            }

            Console.ReadKey();
            Restart();
        }

        public void Restart()
        {
            Init();
            Run();
        }
    }
}
