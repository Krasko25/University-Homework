using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Random random = new Random();

        HashSet<int> set1 = new HashSet<int>();
        HashSet<int> set2 = new HashSet<int>();

        for (int i = 0; i < 16; i++)
        {
            set1.Add(random.Next(1, 21));
        }

        for (int i = 0; i < 9; i++)
        {
            set2.Add(random.Next(1, 21));
        }

        Console.WriteLine("Первый список:");
        PrintHashSet(set1);

        Console.WriteLine("Второй список:");
        PrintHashSet(set2);

        set1.IntersectWith(set2);

        Console.WriteLine("Общие элементы:");
        PrintHashSet(set1);
    }

    static void PrintHashSet(HashSet<int> set)
    {
        foreach (var item in set)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
