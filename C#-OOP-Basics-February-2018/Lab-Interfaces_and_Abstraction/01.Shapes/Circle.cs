using System;

public class Circle : IDrawable
{
    private int radius;

    public int Radius
    {
        get { return radius; }
        private set { radius = value; }
    }

    public Circle(int radius)
    {
        this.radius = radius;
    }

    public void Draw()
    {
        double radiusIn = this.radius - 0.4;
        double radiusOut = this.radius + 0.4;
        for (double y = this.radius; y >= -this.radius; --y)
        {
            for (double x = -this.radius; x < radiusOut; x += 0.5)
            {
                double value = x * x + y * y;

                if (value >= radiusIn * radiusIn && value <= radiusOut * radiusOut)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
