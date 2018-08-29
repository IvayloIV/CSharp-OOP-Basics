public class Robot : IHuman
{
    private string model;
    public string Id { get; private set; }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public Robot(string model, string id)
    {
        this.model = model;
        this.Id = id;
    }
}