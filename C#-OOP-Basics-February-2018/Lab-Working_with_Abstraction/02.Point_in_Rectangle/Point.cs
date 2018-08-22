using System;
using System.Linq;

public class Point
{
    private int x;
    private int y;

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public Point(Func<string> ReadLine)
    {
        var row = ReadLine().Split().Select(int.Parse).ToList();
        this.X = row[0];
        this.Y = row[1];
    }
}
