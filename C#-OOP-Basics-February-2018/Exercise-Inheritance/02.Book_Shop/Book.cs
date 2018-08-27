using System;
using System.Text;

public class Book
{
    private const int MAX_TITLE_LENGTH = 3;

    private string title;
    private decimal price;
    private string author;

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < MAX_TITLE_LENGTH)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            ValidateAuthor(value);
            author = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    private void ValidateAuthor(string value)
    {
        var tokens = value.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length > 1 && char.IsDigit(tokens[1][0]))
        {
            throw new ArgumentException("Author not valid!");
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"Type: {this.GetType().Name}");
        result.AppendLine($"Title: {this.title}");
        result.AppendLine($"Author: {this.author}");
        result.AppendLine($"Price: {this.Price:f2}");
        return result.ToString().TrimEnd();
    }
}
