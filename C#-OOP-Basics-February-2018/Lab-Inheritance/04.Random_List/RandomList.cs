using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    Random random;

    public RandomList()
    {
        random = new Random();
    }

    public string RandomString()
    {
        string currentElement = "";
        if (this.Count > 0)
        {
            var index = random.Next(0, this.Count - 1);
            currentElement = this[index];
            this.RemoveAt(index);
        }
        return currentElement;
    }
}