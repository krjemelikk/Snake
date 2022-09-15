using System;
using System.Collections.Generic;
using System.Text;
using Snake.Model;

namespace Snake
{
    public class Canvas
    {
        private const char Pixel = 'o';
        private const char EmptyPixel = ' ';
        public int Width { get; set; }
        public int Height { get; set; }

        public Canvas() : this(30, 30){}
        public Canvas(int width,int height)
        {
            Console.Clear();
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            Console.CursorVisible = false;
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
