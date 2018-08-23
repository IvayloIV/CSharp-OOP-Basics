using System;

public class Patient
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int room;

    public int Room
    {
        get { return room; }
        set { room = value; }
    }

    public Patient(string name, int room)
    {
        this.name = name;
        this.room = room;
    }
}