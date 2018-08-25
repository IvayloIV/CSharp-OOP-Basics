using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public double Length
    {
        get { return length; }
        private set
        {
            ValidateInput(value, "Length");
            this.length = value;
        }
    }

    public double Width
    {
        get { return width; }
        private set
        {
            ValidateInput(value, "Width");
            this.width = value;
        }
    }

    public double Height
    {
        get { return height; }
        private set
        {
            ValidateInput(value, "Height");
            this.height = value;
        }
    }

    private void ValidateInput(double value, string type)
    {
        if (value <= 0)
        {
            throw new ArgumentException($"{type} cannot be zero or negative. ");
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
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