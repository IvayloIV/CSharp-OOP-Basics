public class Person
{
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    private string name;

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    private int age;

    public int Age
    {
        get { return age; }
        protected set { age = value; }
    }

    public override string ToString()
    {
        return $"{this.name} {this.age}";
    }
}