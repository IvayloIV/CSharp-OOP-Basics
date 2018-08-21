using System;
using System.Text;

class DrawingTool
{
    int height;
    int width;

    public DrawingTool(int height, int width)
    {
        this.height = height;
        this.width = width;
    }

    public string Draw()
    {
        var figure = new StringBuilder();
        for (int i = 0; i < this.height; i++)
        {
            figure.Append("|");
            for (int j = 0; j < this.width; j++)
            {
                if (i > 0 && i < this.height - 1)
                {
                    figure.Append(" ");
                }
                else
                {
                    figure.Append("-");
                }
            }
            figure.Append("|\n");
        }
        return figure.ToString().Trim();
    }
}