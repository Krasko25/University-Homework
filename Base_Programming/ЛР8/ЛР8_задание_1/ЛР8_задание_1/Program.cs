using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "sorted.dat";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл sorted.dat не найден.");
            return;
        }

        string[] parts = File.ReadAllText(filePath)
            .Split(new char[] { ' ', ',', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int[] numbers = new int[parts.Length];
        int count = 0;

        for (int i = 0; i < parts.Length; i++)
        {
            if (int.TryParse(parts[i], out int num))
            {
                numbers[count] = num;
                count++;
            }
        }

        Array.Resize(ref numbers, count);

        if (numbers.Length == 0)
        {
            Console.WriteLine("Файл не содержит чисел.");
            return;
        }

        Console.Write("Введите число для поиска: ");
        if (!int.TryParse(Console.ReadLine(), out int target))
        {
            Console.WriteLine("Некорректный ввод.");
            return;
        }

        // Поиск
        LinearSearch(numbers, target);

        BinarySearch(numbers, target);

        InterpolationSearch(numbers, target);
    }

    static void LinearSearch(int[] arr, int x)
    {
        int comparisons = 0;
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < arr.Length; i++)
        {
            comparisons++;
            if (arr[i] == x)
            {
                sw.Stop();
                PrintResult("Линейный", i, sw.Elapsed, comparisons);
                return;
            }
        }

        sw.Stop();
        PrintResult("Линейный", -1, sw.Elapsed, comparisons);
    }

    static void BinarySearch(int[] arr, int x)
    {
        int left = 0, right = arr.Length - 1;
        int comparisons = 0;
        Stopwatch sw = Stopwatch.StartNew();

        while (left <= right)
        {
            comparisons++;
            int mid = (left + right) / 2;
            if (arr[mid] == x)
            {
                sw.Stop();
                PrintResult("Бинарный", mid, sw.Elapsed, comparisons);
                return;
            }
            else if (arr[mid] < x)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        sw.Stop();
        PrintResult("Бинарный", -1, sw.Elapsed, comparisons);
    }

    static void InterpolationSearch(int[] arr, int x)
    {
        int comparisons = 0;
        int low = 0, high = arr.Length - 1;
        Stopwatch sw = Stopwatch.StartNew();

        while (low <= high && x >= arr[low] && x <= arr[high])
        {
            comparisons++;

            if (arr[high] == arr[low])
            {
                if (arr[low] == x)
                {
                    sw.Stop();
                    PrintResult("Интерполяционный", low, sw.Elapsed, comparisons);
                    return;
                }
                else
                    break;
            }

            int pos = low + (int)(((long)(x - arr[low]) * (high - low)) / (arr[high] - arr[low]));

            // Защита от выхода за границы
            if (pos < low || pos > high)
                break;

            comparisons++;

            if (arr[pos] == x)
            {
                sw.Stop();
                PrintResult("Интерполяционный", pos, sw.Elapsed, comparisons);
                return;
            }

            if (arr[pos] < x)
                low = pos + 1;
            else
                high = pos - 1;
        }

        sw.Stop();
        PrintResult("Интерполяционный", -1, sw.Elapsed, comparisons);
    }


    static void PrintResult(string method, int index, TimeSpan time, int comparisons)
    {
        Console.WriteLine($"\n{method} поиск:");

        if (index != -1)
            Console.WriteLine("Позиция: " + index);
        else
            Console.WriteLine("Не найдено");

        Console.WriteLine("Время: " + time.TotalMilliseconds.ToString("0.####") + " мс");

        Console.WriteLine("Сравнений: " + comparisons);
    }
}
