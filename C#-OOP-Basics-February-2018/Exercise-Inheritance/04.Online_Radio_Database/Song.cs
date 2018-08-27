public class Song
{
    private const int MIN_LENGTH_ARTIST = 3;
    private const int MAX_LENGTH_ARTIST = 20;
    private const int MIN_LENGTH_SONG = 3;
    private const int MAX_LENGTH_SONG = 30;
    private const int MAX_MINUTES = 14;
    private const int MAX_SECONDS = 59;

    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0 || value > MAX_SECONDS)
            {
                throw new InvalidSongSecondsException();
            }
            seconds = value;
        }
    }


    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < 0 || value > MAX_MINUTES)
            {
                throw new InvalidSongMinutesException();
            }
            minutes = value;
        }
    }

    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < MIN_LENGTH_SONG || value.Length > MAX_LENGTH_SONG)
            {
                throw new InvalidSongNameException();
            }
            songName = value;
        }
    }

    public string ArtistName
    {
        get { return artistName; }
        set
        {
            if (value.Length < MIN_LENGTH_ARTIST || value.Length > MAX_LENGTH_ARTIST)
            {
                throw new InvalidArtistNameException();
            }
            artistName = value;
        }
    }

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public int GetTotalSeconds()
    {
        return this.minutes * 60 + this.seconds;
    }
}