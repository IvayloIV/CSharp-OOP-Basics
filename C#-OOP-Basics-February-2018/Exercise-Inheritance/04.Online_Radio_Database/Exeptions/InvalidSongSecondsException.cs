using System;

public class InvalidSongSecondsException : InvalidSongLengthException
{
    const string MESSAGE = "Song seconds should be between 0 and 59.";

    public InvalidSongSecondsException() : base(MESSAGE)
    {
    }
}