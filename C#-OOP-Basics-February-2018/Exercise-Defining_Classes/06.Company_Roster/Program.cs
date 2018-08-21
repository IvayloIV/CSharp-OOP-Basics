using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var salary = double.Parse(input[1]);
                var position = input[2];
                var department = input[3];
                if (input.Length == 4)
                {
                    employees.Add(new Employee(name, salary, position, department));
                }
                else if (input.Length == 5)
                {
                    if (int.TryParse(input[4], out int age))
                    {
                        employees.Add(new Employee(name, salary, position, department, age));
                    } 
                    else
                    {
                        employees.Add(new Employee(name, salary, position, department, input[4]));
                    }
                }
                else
                {
                    employees.Add(new Employee(name, salary, position, department, input[4], int.Parse(input[5])));
                }
            }
            var highestDepartment = employees.GroupBy(a => a.Department)
                .OrderByDescending(a => a.Sum(b => b.Salary) / a.Count())
                .FirstOrDefault();
            Console.WriteLine($"Highest Average Salary: {highestDepartment.Key}");
            foreach (var person in highestDepartment.OrderByDescending(a => a.Salary))
            {
                Console.WriteLine(person);
            }
        }
    }
}