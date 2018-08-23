using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            var doctors = new List<Doctor>();
            var departments = new Dictionary<string, Room>();
            string command;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] tokens = command.Split();
                var departamentName = tokens[0];
                var doctorFullName = tokens[1] + tokens[2];
                var pacientName = tokens[3];

                CreateDoctor(doctors, doctorFullName);
                CreateRoom(departments, departamentName);
                AddNewPatient(doctors, departments, departamentName, doctorFullName, pacientName);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();
                var patients = GetFilteredPatient(tokens, departments, doctors);
                Console.WriteLine(String.Join("\n", patients));
            }
        }

        private static List<string> GetFilteredPatient(string[] tokens, Dictionary<string, Room> departments, 
            List<Doctor> doctors)
        {
            if (tokens.Length == 1)
            {
                var departmentName = tokens[0];
                return departments[departmentName]
                    .Patients
                    .Select(a => a.Name)
                    .ToList();
            }
            else if (tokens.Length == 2 && int.TryParse(tokens[1], out int room))
            {
                var departmentName = tokens[0];
                return departments[departmentName]
                    .Patients.Where(a => a.Room == room)
                    .Select(a => a.Name)
                    .OrderBy(a => a)
                    .ToList();
            }
            else
            {
                var fullNameDoctor = tokens[0] + tokens[1];
                return doctors
                    .FirstOrDefault(a => a.Name == fullNameDoctor)
                    .Patients.OrderBy(a => a)
                    .ToList();
            }
        }

        private static void AddNewPatient(List<Doctor> doctors, Dictionary<string, Room> departments, 
            string departamentName, string doctorFullName, string pacientName)
        {
            bool isHavingPlace = departments[departamentName].Patients.Count() < 60;
            if (isHavingPlace)
            {
                var room = departments[departamentName];
                if (room.RoomCounter <= 20)
                {
                    room.AddNewPatient(pacientName);
                    doctors.FirstOrDefault(a => a.Name == doctorFullName).Patients.Add(pacientName);
                }
            }
        }

        private static void CreateRoom(Dictionary<string, Room> departments, string departamentName)
        {
            if (!departments.ContainsKey(departamentName))
            {
                departments[departamentName] = new Room();
            }
        }

        private static void CreateDoctor(List<Doctor> doctors, string doctorFullName)
        {
            if (doctors.All(a => a.Name != doctorFullName))
            {
                doctors.Add(new Doctor(doctorFullName));
            }
        }
    }
}