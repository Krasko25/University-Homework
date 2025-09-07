using System;

class Program
{
    //функция для поэлементного сложения двумерных массивов 3х3
    static int[,] AddMatrices(int[,] array1, int[,] array2, out double avgValue)
    {
        int size = 3;
        int[,] resultArray = new int[size, size];
        int totalSum = 0;

        //поэлементное сложение и подсчет суммы элементов
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                resultArray[i, j] = array1[i, j] + array2[i, j];
                totalSum += array1[i, j] + array2[i, j];
            }
        }

        //вычисление среднего значения всех элементов входных массивов
        avgValue = totalSum / (double)(size * size * 2);
        return resultArray;
    }

    //функция для поэлементного вычитания двумерных массивов 3х3
    static int[,] SubtractMatrices(int[,] array1, int[,] array2, out double avgValue)
    {
        int size = 3;
        int[,] resultArray = new int[size, size];
        int totalSum = 0;

        //поэлементное вычитание и подсчет суммы элементов
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                resultArray[i, j] = array1[i, j] - array2[i, j];
                totalSum += array1[i, j] + array2[i, j];
            }
        }

        //вычисление среднего значения всех элементов входных массивов
        avgValue = totalSum / (double)(size * size * 2);
        return resultArray;
    }

    //функция для вывода массива 3x3 на экран
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.Write("Задание 4:\n\n");
        int[,] matrix1 = { { 1, 8, 6 }, { 4, 5, 3 }, { 5, 8, 8 } };
        int[,] matrix2 = { { 11, 8, 5 }, { 7, 5, 4 }, { 3, 5, 1 } };

        //сложение массивов
        double averageAdd;
        int[,] sumMatrix = AddMatrices(matrix1, matrix2, out averageAdd);
        
        //вычитание массивов
        double averageSubtract;
        int[,] diffMatrix = SubtractMatrices(matrix1, matrix2, out averageSubtract);

        //вывод результатов
        Console.WriteLine("Сумма массивов:");
        PrintMatrix(sumMatrix);
        Console.WriteLine($"Среднее значение элементов для сложения: {averageAdd:F2}");

        Console.WriteLine("\nРазность массивов:");
        PrintMatrix(diffMatrix);
        Console.WriteLine($"Среднее значение элементов для вычитания: {averageSubtract:F2}");
    }
}
