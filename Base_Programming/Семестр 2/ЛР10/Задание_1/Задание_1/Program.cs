using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int n = 100000;
        int[] arr1 = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr1[i] = rand.Next(-100000, 100000);
        }


        int[] arr2 = (int[])arr1.Clone(); // массив по возрастанию
        Array.Sort(arr2);

        int[] arr3 = (int[])arr1.Clone(); // массив по убыванию
        Array.Sort(arr3); 
        Array.Reverse(arr3); 

        // Путь к файлу для записи результатов
        string filePath = "sorted.dat";

        SortAndMeasure(arr1, "Массив случайных чисел", "Сортировка слиянием", filePath);
        SortAndMeasure(arr2, "Массив по возрастанию", "Сортировка слиянием", filePath);
        SortAndMeasure(arr3, "Массив по убыванию", "Сортировка слиянием", filePath);

        SortAndMeasure(arr1, "Массив случайных чисел", "Пирамидальная сортировка", filePath);
        SortAndMeasure(arr2, "Массив по возрастанию", "Пирамидальная сортировка", filePath);
        SortAndMeasure(arr3, "Массив по убыванию", "Пирамидальная сортировка", filePath);

        SortAndMeasure(arr1, "Массив случайных чисел", "Быстрая сортировка", filePath);
        SortAndMeasure(arr2, "Массив по возрастанию", "Быстрая сортировка", filePath);
        SortAndMeasure(arr3, "Массив по убыванию", "Быстрая сортировка", filePath);
    }
    
    // Функция для сортировки с измерением времени и выводом результатов
    static void SortAndMeasure(int[] arr, string description, string sortType, string filePath)
    {
        long comparisons = 0;
        long swaps = 0;
        var stopwatch = Stopwatch.StartNew();

        int[] arrCopy = (int[])arr.Clone();
        switch (sortType)
        {
            case "Сортировка слиянием":
                MergeSort(arrCopy, ref comparisons, ref swaps);
                break;
            case "Пирамидальная сортировка":
                HeapSort(arrCopy, ref comparisons, ref swaps);
                break;
            case "Быстрая сортировка":
                QuickSort(arrCopy, 0, arrCopy.Length - 1, ref comparisons, ref swaps);
                break;
        }

        stopwatch.Stop();
        TimeSpan elapsed = stopwatch.Elapsed;

        File.WriteAllText(filePath, string.Empty); // Очищаем файл

        // Записываем в файл только числа
        File.AppendAllText(filePath, string.Join(Environment.NewLine, arrCopy) + Environment.NewLine);

        // Вывод в консоль
        Console.WriteLine($"{description} ({sortType}): {elapsed.Seconds} секунд {elapsed.Milliseconds} миллисекунд");
        Console.WriteLine($"Количество сравнений: {comparisons}, перестановок: {swaps}");

        bool isSorted = IsSorted(filePath);
        Console.WriteLine($"Проверка сортировки для {description} ({sortType}):");
        Console.WriteLine($"Массив отсортирован в порядке возрастания: {isSorted}\n");
    }


    // Сортировка слиянием
    static void MergeSort(int[] arr, ref long comparisons, ref long swaps)
    {
        int[] tempArr = new int[arr.Length];
        MergeSortRecursive(arr, tempArr, 0, arr.Length - 1, ref comparisons, ref swaps);
    }

    static void MergeSortRecursive(int[] arr, int[] tempArr, int left, int right, ref long comparisons, ref long swaps)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSortRecursive(arr, tempArr, left, mid, ref comparisons, ref swaps);
            MergeSortRecursive(arr, tempArr, mid + 1, right, ref comparisons, ref swaps);
            Merge(arr, tempArr, left, mid, right, ref comparisons, ref swaps);
        }
    }

    static void Merge(int[] arr, int[] tempArr, int left, int mid, int right, ref long comparisons, ref long swaps)
    {
        int leftEnd = mid;
        int rightEnd = right;
        int tempPos = left;
        int length = right - left + 1;

        int leftIndex = left;
        int rightIndex = mid + 1;

        while (leftIndex <= leftEnd && rightIndex <= rightEnd)
        {
            comparisons++;
            if (arr[leftIndex] <= arr[rightIndex])
            {
                tempArr[tempPos++] = arr[leftIndex++];
            }
            else
            {
                tempArr[tempPos++] = arr[rightIndex++];
                swaps++;
            }
        }

        while (leftIndex <= leftEnd)
        {
            tempArr[tempPos++] = arr[leftIndex++];
        }

        while (rightIndex <= rightEnd)
        {
            tempArr[tempPos++] = arr[rightIndex++];
        }

        for (int i = 0; i < length; i++)
        {
            arr[left + i] = tempArr[left + i];
        }
    }


    // Пирамидальная сортировка
    static void HeapSort(int[] arr, ref long comparisons, ref long swaps)
    {
        int n = arr.Length;
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i, ref comparisons, ref swaps);
        }

        for (int i = n - 1; i > 0; i--)
        {
            Swap(arr, 0, i, ref swaps);
            Heapify(arr, i, 0, ref comparisons, ref swaps);
        }
    }

    static void Heapify(int[] arr, int n, int i, ref long comparisons, ref long swaps)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        comparisons++;

        if (left < n && arr[left] > arr[largest])
        {
            largest = left;
        }

        if (right < n && arr[right] > arr[largest])
        {
            largest = right;
        }

        if (largest != i)
        {
            Swap(arr, i, largest, ref swaps);
            Heapify(arr, n, largest, ref comparisons, ref swaps);
        }
    }

    // Функция обмена элементов
    static void Swap(int[] arr, int i, int j, ref long swaps)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
        swaps++;
    }

    // Быстрая сортировка
    static void QuickSort(int[] arr, int low, int high, ref long comparisons, ref long swaps)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(low);
        stack.Push(high);

        while (stack.Count > 0)
        {
            high = stack.Pop();
            low = stack.Pop();

            if (low < high)
            {
                int pi = Partition(arr, low, high, ref comparisons, ref swaps);

                // Пушим в стек правую и левую части массива для дальнейшей сортировки
                if (pi - 1 > low)
                {
                    stack.Push(low);
                    stack.Push(pi - 1);
                }

                if (pi + 1 < high)
                {
                    stack.Push(pi + 1);
                    stack.Push(high);
                }
            }
        }
    }

    static int Partition(int[] arr, int low, int high, ref long comparisons, ref long swaps)
    {
        // Выбор медианы из трех элементов
        int middle = low + (high - low) / 2;
        int pivotIndex = MedianOfThree(arr, low, middle, high);

        // Меняем опорный элемент с последним элементом для совместимости с Partition
        Swap(arr, pivotIndex, high, ref swaps);

        int pivot = arr[high];
        int i = (low - 1);

        for (int j = low; j <= high - 1; j++)
        {
            comparisons++;
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j, ref swaps);
            }
        }

        Swap(arr, i + 1, high, ref swaps); // Помещаем опорный элемент в нужную позицию
        return (i + 1);
    }

    // Функция для выбора медианы из трех элементов
    static int MedianOfThree(int[] arr, int low, int middle, int high)
    {
        int a = arr[low];
        int b = arr[middle];
        int c = arr[high];

        if ((a > b) == (a > c))
            return low;
        else if ((b > a) == (b > c))
            return middle;
        else
            return high;
    }

    // Функция для проверки, отсортирован ли массив
    static bool IsSorted(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            int[] arr = lines.Select(line => int.Parse(line)).ToArray();

            // Проверка, отсортирован ли массив
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при чтении из файла: " + ex.Message);
            return false;
        }
    }
}
