using Snake.Model;
using System;

namespace Snake
{
    public class Canvas
    {
        private const char Pixel = 'o';
        private const char EmptyPixel = ' ';
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Canvas() : this(30, 30){}
        public Canvas(int width,int height)
        {
            Console.Clear();
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            Console.CursorVisible = false;

            Width = width;
            Height = height;
        }

        public void DrawObject(IDrawable obj)
        {
            var positions = obj.GetPositions();
            foreach (var pos in positions)
                DrawPixel(pos,obj.Color);
        }

        public void DrawPixel(Position position, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(position.X,position.Y);
            Console.Write(Pixel);
            Console.ResetColor();
        }

        public void UnDrawPixel(Position position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(EmptyPixel);
        }
    }
}
