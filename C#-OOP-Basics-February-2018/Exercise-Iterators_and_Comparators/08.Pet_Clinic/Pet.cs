public class Pet
{
    public Pet(string name, int age, string kind)
    {
        this.name = name;
        this.age = age;
        this.kind = kind;
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

    private string kind;

    public string Kind
    {
        get { return kind; }
        protected set { kind = value; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Kind}";
    }
}