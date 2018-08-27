using System;

public class InvalidArtistNameException : InvalidSongException
{
    const string MESSAGE = "Artist name should be between 3 and 20 symbols.";

    public InvalidArtistNameException() : base(MESSAGE)
    {
    }
}