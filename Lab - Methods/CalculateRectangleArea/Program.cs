using System;

namespace CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            double area = RectangleArea(width, height);

            Console.WriteLine(area);
        }

        static double RectangleArea(int width, int height)
        {
            return width * height;
        }
    }
}
