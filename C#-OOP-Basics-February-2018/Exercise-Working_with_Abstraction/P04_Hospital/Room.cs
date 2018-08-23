using System;
using System.Collections.Generic;

public class Room
{
    private List<Patient> patients;
    private int roomCounter = 0;

    public int RoomCounter
    {
        get { return roomCounter; }
        set { roomCounter = value; }
    }

    public List<Patient> Patients
    {
        get { return patients; }
        set { patients = value; }
    }

    public Room()
    {
        this.Patients = new List<Patient>();
    }

    public void AddNewPatient(string patientName)
    {
        if (this.patients.Count % 3 == 0)
        {
            this.roomCounter++;
        }
        this.patients.Add(new Patient(patientName, this.roomCounter));
    }
}