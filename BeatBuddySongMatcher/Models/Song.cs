namespace BeatBuddySongMatcher.Models;

public class Song
{
    public long Id { get; set; }

    public string Artist { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Beat { get; set; } = string.Empty;

    public int Bpm { get; set; }
}