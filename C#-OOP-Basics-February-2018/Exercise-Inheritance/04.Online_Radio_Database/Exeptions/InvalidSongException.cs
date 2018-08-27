using System;

public class InvalidSongException : ArgumentException
{
    const string MESSAGE = "Invalid song.";

    public InvalidSongException() : base(MESSAGE)
    {
    }

    public InvalidSongException(string message) : base(message)
    {
    }
}