using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IDrawable circle = new Circle(5);
            IDrawable rectangle = new Rectangle(15,6);

            circle.Draw();
            Console.WriteLine();
            rectangle.Draw();
        }
    }
}
