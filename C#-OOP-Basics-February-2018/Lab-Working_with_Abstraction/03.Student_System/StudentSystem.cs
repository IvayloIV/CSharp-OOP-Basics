namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        private Dictionary<string, Student> repo;

        public StudentSystem()
        {
            this.repo = new Dictionary<string, Student>();
        }

        public void ParseCommand(string command)
        {
            string[] tokens = command.Split();

            var name = tokens[1];
            if (tokens[0] == "Create")
            {
                CreateStudent(name, tokens[2], tokens[3]);
            }
            else if (tokens[0] == "Show")
            {
                ShowStudent(name);

            }
        }

        private void ShowStudent(string name)
        {
            if (repo.ContainsKey(name))
            {
                var student = repo[name];
                Console.WriteLine(student);
            }
        }

        private void CreateStudent(string name, string ageString, string gradeString)
        {
            var age = int.Parse(ageString);
            var grade = double.Parse(gradeString);
            if (!repo.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                repo[name] = student;
            }
        }
    }
}