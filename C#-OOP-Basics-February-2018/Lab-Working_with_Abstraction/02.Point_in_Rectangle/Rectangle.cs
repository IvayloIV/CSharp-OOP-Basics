using System;
using System.Linq;

public class Rectangle
{
    private Point topLeft;
    private Point bottomRight;

    public Point TopLeft
    {
        get { return topLeft; }
        set { topLeft = value; }
    }

    public Point BottomRight
    {
        get { return bottomRight; }
        set { bottomRight = value; }
    }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        this.TopLeft = topLeft;
        this.BottomRight = bottomRight;
    }

    public Rectangle(Func<string> ReadLine)
    {
        var row = ReadLine().Split().Select(int.Parse).ToList();
        var topLeftPoint = new Point(row[0], row[1]);
        var bottomRightPoint = new Point(row[2], row[3]);
        this.TopLeft = topLeftPoint;
        this.BottomRight = bottomRightPoint;
    }

    public bool Contains(Point point)
    {
        return point.X >= this.topLeft.X && point.X <= this.bottomRight.X
            && point.Y >= this.topLeft.Y && point.Y <= this.bottomRight.Y;
    }
}