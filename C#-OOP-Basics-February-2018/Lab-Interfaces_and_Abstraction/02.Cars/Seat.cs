using System.Text;

public class Seat : ICar
{
    public string Model { get; private set; }
    public string Color { get; private set; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public Seat(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{this.Color} Seat {this.Model}")
            .AppendLine(this.Start())
            .AppendLine(this.Stop());

        return builder.ToString().TrimEnd();
    }
}