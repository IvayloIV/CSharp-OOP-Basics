using System;
using System.Collections.Generic;

public class JobList : List<IJob>
{
    public void AddJob(IJob job)
    {
        this.Add(job);
        job.JobEvent += RemoveJob;
    }

    public void RemoveJob(IJob job)
    {
        Console.WriteLine($"Job {job.Name} done!");
        this.Remove(job);
    }
}