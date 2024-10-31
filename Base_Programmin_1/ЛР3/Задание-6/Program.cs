using System;

class Program
{
    //функция для итеративного вычисления суммы элементов массива
    static int SumIterative(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum;
    }

    //функция для рекурсивного вычисления суммы элементов массива
    static int SumRecursive(int[] array, int index)
    {
        //базовый случай: если индекс выходит за пределы массива, возвращаем 0
        if (index >= array.Length)
        {
            return 0;
        }
        //рекурсивный вызов: сумма текущего элемента и суммы оставшихся элементов
        return array[index] + SumRecursive(array, index + 1);
    }

    //функция для итеративного вычисления минимального элемента в массиве
    static int MinIterative(int[] array)
    {
        int min = array[0]; //инициализируем минимальный элемент первым элементом
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }
        return min;
    }

    //функция для рекурсивного вычисления минимального элемента в массиве
    static int MinRecursive(int[] array, int index)
    {
        //базовый случай: если индекс выходит за пределы массива, возвращаем максимальное значение
        if (index == array.Length - 1)
        {
            return array[index];
        }

        //рекурсивный вызов: находим минимальный элемент в оставшейся части массива
        int minInRest = MinRecursive(array, index + 1);

        //возвращаем минимум между текущим элементом и минимальным элементом в оставшейся части
        return Math.Min(array[index], minInRest);
    }

    static void Main()
    {
        Console.Write("Задание 6:\n\n");

        //инициализация массива
        int[] array = { 3, 5, 2, 8, 6, 1, 4, 7 };

        //вычисление суммы элементов массива
        int iterativeSum = SumIterative(array);
        int recursiveSum = SumRecursive(array, 0);

        //вычисление минимального элемента массива
        int iterativeMin = MinIterative(array);
        int recursiveMin = MinRecursive(array, 0);

        //вывод результатов
        Console.WriteLine("Массив: " + string.Join(", ", array));
        Console.WriteLine($"Итеративная сумма элементов: {iterativeSum}");
        Console.WriteLine($"Рекурсивная сумма элементов: {recursiveSum}");
        Console.WriteLine($"Итеративный минимум: {iterativeMin}");
        Console.WriteLine($"Рекурсивный минимум: {recursiveMin}");
    }
}
