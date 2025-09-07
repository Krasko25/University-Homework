using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        // Выполнение сортировки и запись данных в файл
        RunSortingAlgorithm("Сортировка выбором", SelectionSort);
        RunSortingAlgorithm("Сортировка вставками", InsertionSort);
        RunSortingAlgorithm("Сортировка пузырьком", BubbleSort);
        RunSortingAlgorithm("Сортировка шейкером", ShakerSort);
        RunSortingAlgorithm("Сортировка Шелла", ShellSort);
    }

    // Генерация случайного массива
    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next();
        }
        return array;
    }

    // Функция для выполнения сортировки и сбора информации о времени и количестве операций
    static void RunSortingAlgorithm(string algorithmName, Action<int[]> sortingAlgorithm)
    {
        int[] originalArray = GenerateRandomArray(100000);

        RunSortingAndWriteToFile(algorithmName, sortingAlgorithm, (int[])originalArray.Clone());
    }

    // Функция для выполнения сортировки, записи результатов в файл и вывод времени
    static void RunSortingAndWriteToFile(string algorithmName, Action<int[]> sortingAlgorithm, int[] array)
    {
        Console.WriteLine($"{algorithmName}. Ждем-с");

        var stopwatch = Stopwatch.StartNew();
        sortingAlgorithm(array);  // Сортируем массив
        stopwatch.Stop();

        Console.WriteLine($"{algorithmName} завершена за: {stopwatch.Elapsed.Seconds} секунд и {stopwatch.Elapsed.Milliseconds} миллисекунд.");

        // Запись отсортированного массива в файл
        string filename = $"{algorithmName}.dat";
        File.WriteAllText(filename, string.Join(",", array));

        // Проверка правильности сортировки
        CheckSortedData(filename);
    }

    // Проверка данных на правильность сортировки
    static void CheckSortedData(string filename)
    {
        string fileContent = File.ReadAllText(filename);
        string[] stringNumbers = fileContent.Split(',');

        int[] numbers = Array.ConvertAll(stringNumbers, s => int.Parse(s));

        bool isSorted = true;
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < numbers[i - 1])
            {
                isSorted = false;
                break;
            }
        }

        if (isSorted)
        {
            Console.WriteLine("Данные в файле отсортированы правильно.\n");
        }
        else
        {
            Console.WriteLine("Данные в файле НЕ отсортированы.\n");
        }
    }

    // Реализация сортировки выбором
    static void SelectionSort(int[] array)
    {
        long comparisons = 0, swaps = 0;  // Используем long т.к. иногда значения не влазиют в int
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                comparisons++;
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                swaps++;
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
        Console.WriteLine($"Сортировка выбором - Сравнений: {comparisons}, Перестановок: {swaps}");
    }

    // Реализация сортировки вставками
    static void InsertionSort(int[] array)
    {
        long comparisons = 0, swaps = 0; 
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0)
            {
                comparisons++; 
                if (array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                    swaps++; 
                }
                else
                {
                    break;
                }
            }
            array[j + 1] = key; // Перемещение ключа
        }
        Console.WriteLine($"Сортировка вставками - Сравнений: {comparisons}, Перестановок: {swaps}");
    }


    // Реализация сортировки пузырьком
    static void BubbleSort(int[] array)
    {
        long comparisons = 0, swaps = 0;  
        bool swapped;
        for (int i = 0; i < array.Length - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                comparisons++;
                if (array[j] > array[j + 1])
                {
                    swaps++;
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
        Console.WriteLine($"Сортировка пузырьком - Сравнений: {comparisons}, Перестановок: {swaps}");
    }

    // Реализация сортировки шейкером
    static void ShakerSort(int[] array)
    {
        long comparisons = 0, swaps = 0; 
        int left = 0, right = array.Length - 1;
        while (left < right)
        {
            for (int i = left; i < right; i++)
            {
                comparisons++;
                if (array[i] > array[i + 1])
                {
                    swaps++;
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
            }
            right--;

            for (int i = right; i > left; i--)
            {
                comparisons++;
                if (array[i] < array[i - 1])
                {
                    swaps++;
                    int temp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = temp;
                }
            }
            left++;
        }
        Console.WriteLine($"Сортировка шейкером - Сравнений: {comparisons}, Перестановок: {swaps}");
    }

    // Реализация сортировки Шелла
    static void ShellSort(int[] array)
    {
        long comparisons = 0, swaps = 0;
        int gap = array.Length / 2;
        while (gap > 0)
        {
            for (int i = gap; i < array.Length; i++)
            {
                int temp = array[i];
                int j = i;
                while (j >= gap && array[j - gap] > temp)
                {
                    comparisons++; // Сравнение
                    array[j] = array[j - gap];
                    j -= gap;
                    swaps++; // Перестановка
                }
                array[j] = temp;
            }
            gap /= 2; // Уменьшаем шаг
        }
        Console.WriteLine($"Сортировка Шелла - Сравнений: {comparisons}, Перестановок: {swaps}");
    }



}
