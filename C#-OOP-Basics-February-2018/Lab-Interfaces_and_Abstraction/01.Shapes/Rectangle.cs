using System;

public class Rectangle : IDrawable
{
    private int width;
    private int height;
        
    public int Width
    {
        get { return width; }
        private set { width = value; }
    }

    public int Height
    {
        get { return height; }
        private set { height = value; }
    }

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw()
    {
        DrawStarLine();
        for (int i = 0; i < this.height - 2; i++)
        {
            Console.Write("*");
            for (int j = 0; j < this.width - 2; j++)
            {
                Console.Write(" ");
            }
            Console.Write("*");
            Console.WriteLine();
        }
        DrawStarLine();
    }

    private void DrawStarLine()
    {
        for (int i = 0; i < this.width; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
}