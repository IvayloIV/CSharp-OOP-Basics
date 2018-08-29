public class Citizen : IHuman
{
    private string name;
    private int age;
    public string Id { get; private set; }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

    public Citizen(string name, int age, string id)
    {
        this.name = name;
        this.age = age;
        this.Id = id;
    }
}