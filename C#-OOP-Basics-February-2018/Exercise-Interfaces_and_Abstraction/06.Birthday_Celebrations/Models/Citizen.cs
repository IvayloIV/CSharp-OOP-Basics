public class Citizen : IIdentifiable, IBirthdate, IName
{
    public string Name { get; private set; }
    private int age;
    public string Id { get; private set; }
    public string Birthdate { get; private set; }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }
}