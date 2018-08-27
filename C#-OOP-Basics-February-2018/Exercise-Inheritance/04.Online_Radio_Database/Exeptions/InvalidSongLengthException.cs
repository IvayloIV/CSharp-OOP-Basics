using System;

public class InvalidSongLengthException : InvalidSongException
{
    const string MESSAGE = "Invalid song length.";

    public InvalidSongLengthException() : base(MESSAGE)
    {
    }

    public InvalidSongLengthException(string message) : base(message)
    {
    }
}