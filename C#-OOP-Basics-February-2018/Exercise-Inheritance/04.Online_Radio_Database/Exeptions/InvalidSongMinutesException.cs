using System;

public class InvalidSongMinutesException : InvalidSongLengthException
{
    const string MESSAGE = "Song minutes should be between 0 and 14.";

    public InvalidSongMinutesException() : base(MESSAGE)
    {
    }
}