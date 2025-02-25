using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] tracklist = new string[]
        {
            "Gentle Giant – Free Hand [6:15]",
            "Supertramp – Child Of Vision [07:27]",
            "Camel – Lawrence [10:46]",
            "Yes – Don’t Kill The Whale [3:55]",
            "10CC – Notell Hotel [04:58]",
            "Nektar – King Of Twilight [4:16]",
            "The Flower Kings – Monsters & Men [21:19]",
            "Focus – Le Clochard [1:59]",
            "Pendragon – Fallen Dream And Angel [5:23]",
            "Kaipa – Remains Of The Day (08:02)"
        };

        TimeSpan[] durations = tracklist
            .Select(t => ParseTime(t))
            .ToArray();

        TimeSpan totalDuration = durations.Aggregate((t1, t2) => t1 + t2);
        TimeSpan longest = durations.Max();
        TimeSpan shortest = durations.Min();

        string longestSong = tracklist[Array.IndexOf(durations, longest)];
        string shortestSong = tracklist[Array.IndexOf(durations, shortest)];

        var minDiffPair = FindMinTimeDifference(durations, tracklist);

        Console.WriteLine($"Общая продолжительность: {totalDuration}");
        Console.WriteLine($"Наиболее длинная песня: {longestSong}");
        Console.WriteLine($"Наиболее короткая песня: {shortestSong}");
        Console.WriteLine($"Песни с минимальной разницей по продолжительности: {minDiffPair.Item1
        } и {minDiffPair.Item2}");
    }

    static TimeSpan ParseTime(string track)
    {
        // Обрабатываем оба варианта разделителей
        var startIdx = track.IndexOfAny(new char[] { '[', '(' });
        var endIdx = track.IndexOfAny(new char[] { ']', ')' });

        var timeStr = track.Substring(startIdx + 1, endIdx - startIdx - 1);
        var parts = timeStr.Split(':');
        int minutes = int.Parse(parts[0]);
        int seconds = int.Parse(parts[1]);
        return new TimeSpan(0, minutes, seconds);
    }

    static Tuple<string, string> FindMinTimeDifference(TimeSpan[] durations, string[] tracklist)
    {
        TimeSpan minDiff = TimeSpan.MaxValue;
        string song1 = string.Empty;
        string song2 = string.Empty;

        for (int i = 0; i < durations.Length; i++)
        {
            for (int j = i + 1; j < durations.Length; j++)
            {
                TimeSpan diff = durations[i] - durations[j];
                if (diff < TimeSpan.Zero)
                    diff = -diff;

                if (diff < minDiff)
                {
                    minDiff = diff;
                    song1 = tracklist[i];
                    song2 = tracklist[j];
                }
            }
        }

        return new Tuple<string, string>(song1, song2);
    }
}
