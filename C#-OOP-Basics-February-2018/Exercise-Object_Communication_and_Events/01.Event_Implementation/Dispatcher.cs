using System;
using System.Collections.Generic;
using System.Text;

public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

public class Dispatcher
{
    public event NameChangeEventHandler NameChange;

    private string name;

    public string  Name
    {
        get { return name; }
        set 
        {
            this.OnNameChange(new NameChangeEventArgs(value));
            name = value; 
        }
    }

    public void OnNameChange(NameChangeEventArgs args)
    {
        this.NameChange(this, args);
    }
}