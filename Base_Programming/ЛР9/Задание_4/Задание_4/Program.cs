using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        int N = 50000;

        // Словарь для хранения суммы кубов и их количества
        Dictionary<int, List<string>> sumOfCubes = new Dictionary<int, List<string>>();

        // Перебираем все возможные кубы для x, y и z
        for (int x = 1; x * x * x <= N; x++)
        {
            for (int y = x; y * y * y <= N; y++) // y >= x для избегания повторений
            {
                for (int z = y; z * z * z <= N; z++) // z >= y для избегания повторений
                {
                    int sum = x * x * x + y * y * y + z * z * z;
                    if (sum <= N)
                    {
                        string combination = $"x = {x}, y = {y}, z = {z}";
                        if (!sumOfCubes.ContainsKey(sum))
                        {
                            sumOfCubes[sum] = new List<string>();
                        }
                        sumOfCubes[sum].Add(combination);
                    }
                }
            }
        }

        bool found = false;
        foreach (var entry in sumOfCubes)
        {
            if (entry.Value.Count >= 3)
            {
                found = true;
                Console.WriteLine($"Число {entry.Key} может быть представлено следующими комбинациями:");
                foreach (var combo in entry.Value)
                {
                    Console.WriteLine(combo);
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Не было найдено подходящих чисел.");
        }
    }
}
