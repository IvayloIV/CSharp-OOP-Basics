﻿using System;
using System.Collections.Generic;

public class Doctor
{
    private string name;
    private List<string> patients;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<string> Patients
    {
        get { return patients; }
        set { patients = value; }
    }

    public Doctor(string name)
    {
        this.name = name;
        this.patients = new List<string>();
    }
}
