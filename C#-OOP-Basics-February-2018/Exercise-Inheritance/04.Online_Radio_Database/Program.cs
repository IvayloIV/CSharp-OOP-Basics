using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Online_Radio_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var playlist = new List<Song>();
            ReadSongs(n, playlist);
            PrintPlaylist(playlist);
        }

        private static void PrintPlaylist(List<Song> playlist)
        {
            Console.WriteLine($"Songs added: {playlist.Count}");
            Console.WriteLine($"Playlist length: {GetTime(playlist.Sum(a => a.GetTotalSeconds()))}");
        }

        private static void ReadSongs(int n, List<Song> playlist)
        {
            for (int i = 0; i < n; i++)
            {
                try
                {
                    ValidateAndAddSong(playlist);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        private static void ValidateAndAddSong(List<Song> playlist)
        {
            var songTokens = Console.ReadLine().Split(';');
            if (songTokens.Count() < 3)
            {
                throw new InvalidSongException();
            }
            var artist = songTokens[0];
            var songName = songTokens[1];
            var minutesAndSeconds = songTokens[2].Split(':')
                .ToList();
            if (!int.TryParse(minutesAndSeconds[0], out int minutes) ||
                !int.TryParse(minutesAndSeconds[1], out int seconds))
            {
                throw new InvalidSongLengthException();
            }
            playlist.Add(new Song(artist, songName, minutes, seconds));
            Console.WriteLine("Song added.");
        }

        private static string GetTime(int seconds)
        {
            int hours = (seconds / 3600) % 24;
            int minutes = (seconds % 3600) / 60;
            seconds = seconds % 60;
            return $"{hours}h {minutes}m {seconds}s";
        }
    }
}