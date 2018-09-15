using System;

public class NameChangeEventArgs : EventArgs
{
    public NameChangeEventArgs(string name)
    {
        this.name = name;
    }

    private string name;

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }
}