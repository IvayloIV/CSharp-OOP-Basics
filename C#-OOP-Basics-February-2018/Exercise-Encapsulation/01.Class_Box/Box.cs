using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public double Length
    {
        get { return length; }
    }

    public double Width
    {
        get { return width; }
    }

    public double Height
    {
        get { return height; }
    }

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public double SurfaceArea()
    {
        return 2 * this.length * this.width + 2 * this.length * this.height +
            2 * this.width * this.height;
    }

    public double LateralSerfaceArea()
    {
        return 2 * this.length * this.height + 2 * this.width * this.height;
    }

    public double Volume()
    {
        return this.length * this.height * this.width;
    }
}