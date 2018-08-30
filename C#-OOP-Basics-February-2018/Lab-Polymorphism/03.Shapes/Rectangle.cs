public class Rectangle : Shape
{
    public Rectangle(double height, double width)
    {
        this.height = height;
        this.width = width;
    }

    private double height;
    private double width;

    public double Height
    {
        get { return height; }
        private set { height = value; }
    }

    public double Width
    {
        get { return width; }
        private set { width = value; }
    }

    public override double CalculatePerimeter()
    {
        return (this.width + this.height) * 2;
    }

    public override double CalculateArea()
    {
        return this.width * this.height;
    }

    public override string Draw()
    {
        return base.Draw() + nameof(Rectangle);
    }
}