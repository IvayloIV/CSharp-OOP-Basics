using System;

public class Point
{
    private int row;
    private int cow;

    public int Row
    {
        get { return row; }
        set { row = value; }
    }

    public int Cow
    {
        get { return cow; }
        set { cow = value; }
    }

    public Point(int row, int cow)
    {
        this.row = row;
        this.cow = cow;
    }
}
