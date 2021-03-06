﻿using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = new List<string>(authors);
    }
    
    public string Title { get; private set; }

    public int Year { get; private set; }

    public List<string> Authors { get; private set; }

    public int CompareTo(Book other)
    {
        var diff = this.Year.CompareTo(other.Year);
        if (diff == 0) 
        {
            diff = this.Title.CompareTo(other.Title);
        }
        return diff;
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}