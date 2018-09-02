public abstract class Identificator
{
    protected Identificator(string id)
    {
        this.id = id;
    }    

    private string id;

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }
}