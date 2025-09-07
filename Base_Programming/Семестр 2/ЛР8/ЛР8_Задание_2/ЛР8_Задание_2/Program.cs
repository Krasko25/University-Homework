using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string[] files = { "test1.txt", "test2.txt", "test3.txt", "test4.txt", "test5.txt" };

        Console.Write("Введите подстроку для поиска: ");
        string pattern = Console.ReadLine();

        foreach (var file in files)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine($"Файл {file} не найден.");
                continue;
            }

            string text = File.ReadAllText(file);
            Console.WriteLine($"\n===== {file} =====");

            RunSearch("Простой", SimpleSearch, text, pattern);
            RunSearch("КМП", KMPSearch, text, pattern);
            RunSearch("Бойер-Мур", BoyerMooreSearch, text, pattern);
        }
    }

    static void RunSearch(string name, Func<string, string, (int pos, int comparisons)> searchFunc, string text, string pattern)
    {
        Stopwatch sw = Stopwatch.StartNew();
        var (position, comparisons) = searchFunc(text, pattern);
        sw.Stop();

        Console.WriteLine($"\n{name} поиск:");
        Console.WriteLine(position != -1 ? $"Позиция: {position}" : "Не найдено");

        Console.WriteLine($"Время: {sw.Elapsed.TotalMilliseconds:0.0000} мс");
        Console.WriteLine($"Сравнений: {comparisons}");
    }


    static (int, int) SimpleSearch(string text, string pattern)
    {
        int comparisons = 0;
        for (int i = 0; i <= text.Length - pattern.Length; i++)
        {
            int j;
            for (j = 0; j < pattern.Length; j++)
            {
                comparisons++;
                if (text[i + j] != pattern[j])
                    break;
            }

            if (j == pattern.Length)
                return (i, comparisons);
        }
        return (-1, comparisons);
    }

    static (int, int) KMPSearch(string text, string pattern)
    {
        int[] lps = BuildLPS(pattern);
        int i = 0, j = 0, comparisons = 0;

        while (i < text.Length)
        {
            comparisons++;
            if (text[i] == pattern[j])
            {
                i++; j++;
                if (j == pattern.Length)
                    return (i - j, comparisons);
            }
            else
            {
                if (j != 0)
                    j = lps[j - 1];
                else
                    i++;
            }
        }
        return (-1, comparisons);
    }

    static int[] BuildLPS(string pattern)
    {
        int[] lps = new int[pattern.Length];
        int len = 0, i = 1;
        while (i < pattern.Length)
        {
            if (pattern[i] == pattern[len])
            {
                len++;
                lps[i] = len;
                i++;
            }
            else
            {
                if (len != 0)
                    len = lps[len - 1];
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }
        return lps;
    }

    static (int, int) BoyerMooreSearch(string text, string pattern)
    {
        int comparisons = 0;
        var badChar = BuildBadCharTable(pattern);
        int shift = 0;

        while (shift <= text.Length - pattern.Length)
        {
            int j = pattern.Length - 1;

            while (j >= 0 && text[shift + j] == pattern[j])
            {
                comparisons++;
                j--;
            }

            if (j < 0)
            {
                return (shift, comparisons);
            }

            comparisons++;

            char mismatchedChar = text[shift + j];
            int badCharIndex = badChar.ContainsKey(mismatchedChar) ? badChar[mismatchedChar] : -1;

            shift += Math.Max(1, j - badCharIndex);
        }

        return (-1, comparisons);
    }


    static Dictionary<char, int> BuildBadCharTable(string pattern)
    {
        var table = new Dictionary<char, int>();
        for (int i = 0; i < pattern.Length; i++)
        {
            table[pattern[i]] = i;
        }
        return table;
    }

}
