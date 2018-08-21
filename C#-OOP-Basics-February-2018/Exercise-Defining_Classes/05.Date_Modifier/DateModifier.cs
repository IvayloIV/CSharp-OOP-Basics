using System;
using System.Linq;

public class DateModifier
{
    int different;
    public int Different
    {
        get { return this.different; }
        set { this.different = value; }
    }

    public void CalculateDiff(string firstDateStr, string secondDateStr)
    {
        var firstTokens = firstDateStr.Split().Select(int.Parse).ToList();
        var firstDate = new DateTime(firstTokens[0], firstTokens[1], firstTokens[2]);
        var secondTokens = secondDateStr.Split().Select(int.Parse).ToList();
        var secondDate = new DateTime(secondTokens[0], secondTokens[1], secondTokens[2]);
        Different = Math.Abs((int)(firstDate - secondDate).TotalDays);
    }
}
