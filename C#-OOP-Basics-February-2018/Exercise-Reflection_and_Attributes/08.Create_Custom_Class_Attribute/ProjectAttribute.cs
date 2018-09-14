using System;

[AttributeUsage(AttributeTargets.Class)]

public class ProjectAttribute : Attribute
{ 
    public ProjectAttribute(string author, int revision, string description, params string[] reviewers)
    {
        this.author = author;
        this.revision = revision;
        this.description = description;
        this.reviewers = reviewers;
    }

    private string author;

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    private int revision;
        
    public int Revision
    {
        get { return revision; }
        set { revision = value; }
    }

    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    private string[] reviewers;

    public string[] Reviewers
    {
        get { return reviewers; }
        set { reviewers = value; }
    }
}
