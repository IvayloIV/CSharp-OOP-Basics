using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Work_Force
{
    class Program
    {
        static void Main(string[] args)
        {
            var jobs = new JobList();
            var employees = new List<IEmployee>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                var command = tokens[0];
                switch (command)
                {
                    case "Job":
                        var employee = employees.FirstOrDefault(a => a.Name == tokens[3]);
                        var newJob = new Job(tokens[1], int.Parse(tokens[2]), employee);
                        jobs.AddJob(newJob);
                        break;
                    case "StandardEmployee":
                        employees.Add(new StandardEmployee(tokens[1]));
                        break;
                    case "PartTimeEmployee":
                        employees.Add(new PartTimeEmployee(tokens[1]));
                        break;
                    case "Pass":
                        foreach (var job in jobs.ToList())
                        {
                            job.Update();
                        }
                        break;
                    case "Status":
                        jobs.ForEach(Console.WriteLine);
                        break;
                }
            }
        }
    }
}
