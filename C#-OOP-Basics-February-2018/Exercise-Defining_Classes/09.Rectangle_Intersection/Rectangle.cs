using System;

public class Rectangle
{
    string id;
    double width;
    double height;
    double horizontal;
    double vertical;

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }
    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }
    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }
    public double Horizontal
    {
        get { return this.horizontal; }
        set { this.horizontal = value; }
    }
    public double Vertical
    {
        get { return this.vertical; }
        set { this.vertical = value; }
    }


    public Rectangle(string id, double width, double height, double horizontal, double vertical)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.Horizontal = horizontal;
        this.Vertical = vertical;
    }

    public bool IsInside(Rectangle otherRect)
    {
        var firstX1 = this.Horizontal;
        var firstX2 = this.Horizontal + this.width;
        var firstY1 = this.Vertical;
        var firstY2 = this.Vertical + this.height;

        var secondX1 = otherRect.Horizontal;
        var secondX2 = otherRect.Horizontal + otherRect.width;
        var secondY1 = otherRect.Vertical;
        var secondY2 = otherRect.Vertical + otherRect.height;

        return (firstX1 <= secondX2) 
            && (firstX2 >= secondX1) 
            && (firstY1 <= secondY2) 
            && (firstY2 >= secondY1);
    }
}