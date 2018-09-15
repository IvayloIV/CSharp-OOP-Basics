public delegate void JobDone(IJob job);

public interface IJob : INameable
{
    event JobDone JobEvent;

    int HoursOfWorkRequired { get; }

    void Update();

    IEmployee Employee { get; }
}