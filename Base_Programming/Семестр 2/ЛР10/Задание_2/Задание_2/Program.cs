using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int n = 100; 
        int[] bills = new int[n];

        // Генерация массива с купюрами номиналом 1, 2, 5, 10, 20, 50, 100
        int[] options = { 1, 2, 5, 10, 20, 50, 100 };

        for (int i = 0; i < n; i++)
        {
            bills[i] = options[rand.Next(options.Length)];
        }

        // Вывод сгенерированного массива
        Console.WriteLine("Сгенерированный массив купюр:");
        foreach (var bill in bills)
        {
            Console.Write(bill + " ");
        }
        Console.WriteLine();

        // Сортировка подсчетами
        CountingSort(bills);

        Console.WriteLine("\nОтсортированный массив купюр:");
        foreach (var bill in bills)
        {
            Console.Write(bill + " ");
        }
    }

    static void CountingSort(int[] arr)
    {
        // Определяем диапазон возможных номиналов
        int[] options = { 1, 2, 5, 10, 20, 50, 100 };
        int maxValue = options[options.Length - 1];

        // Массив для подсчета количества каждого номинала
        int[] count = new int[maxValue + 1];

        // Подсчитываем количество каждой купюры
        foreach (int bill in arr)
        {
            count[bill]++;
        }

        // Заполняем массив отсортированными элементами
        int index = 0;
        for (int i = 0; i < count.Length; i++)
        {
            while (count[i] > 0)
            {
                arr[index++] = i;
                count[i]--;
            }
        }
    }
}
