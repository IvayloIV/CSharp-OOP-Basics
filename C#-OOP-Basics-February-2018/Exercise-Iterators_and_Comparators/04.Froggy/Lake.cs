using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    public Lake(IList<int> nums)
    {
        this.numbers = new List<int>(nums);
    }    

    private IList<int> numbers;

    public IEnumerator<int> GetEnumerator()
    {
        var index = 0;
        var counter = 2;
        while (true)
        {
            if (index > this.numbers.Count - 1 && counter == 2)
            {
                counter = -2;
                index--;
            }
            if (index > this.numbers.Count - 1 && counter == -2)
            {
                index += counter;
            }
            if (index < 0) 
            {
                break;
            }
            yield return this.numbers[index];
            index += counter;
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}