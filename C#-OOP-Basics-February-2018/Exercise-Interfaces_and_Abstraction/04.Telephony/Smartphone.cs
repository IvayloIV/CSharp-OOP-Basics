using System;

public class Smartphone : IBrowsing, IPhone
{
    public string Model { get; private set; }

    public Smartphone(string model)
    {
        this.Model = model;
    }

    public string Browsing(string url)
    {
        if (!ValidateUrl(url))
        {
            return "Invalid URL!";
        }
        return $"Browsing: {url}!";
    }

    public string Call(string phone)
    {
        if(!ValidatePhone(phone))
        {
            return "Invalid number!";
        }
        return $"Calling... {phone}";
    }

    private bool ValidatePhone(string phone)
    {
        for (int i = 0; i < phone.Length; i++)
        {
            if (!char.IsDigit(phone[i]))
            {
                return false;
            }
        }
        return true;
    }

    private bool ValidateUrl(string url)
    {
        for (int i = 0; i < url.Length; i++)
        {
            if (char.IsDigit(url[i]))
            {
                return false;
            }
        }
        return true;
    }
}
