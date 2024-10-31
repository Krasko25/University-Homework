using System;

class Program
{
    //функция для заполнения двумерного массива случайными числами
    static void FillArray(int[,] matrix)
    {
        Random rand = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rand.Next(1, 100); //заполняем числами от 1 до 99
            }
        }
    }

    //функция для вывода двумерного массива
    static void PrintArray(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j].ToString("D2") + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    //функция для поворота массива на 90 градусов вправо
    static void RotateArray90Degrees(int[,] matrix)
    {
        int n = matrix.GetLength(0); //размерность массива

        for (int layer = 0; layer < n / 2; layer++)
        {
            int first = layer;
            int last = n - 1 - layer;

            for (int i = first; i < last; i++)
            {
                int offset = i - first;

                //сохраняем верхний элемент
                int top = matrix[first, i];

                //левый -> верхний
                matrix[first, i] = matrix[last - offset, first];

                //нижний -> левый
                matrix[last - offset, first] = matrix[last, last - offset];

                //правый -> нижний
                matrix[last, last - offset] = matrix[i, last];

                //верхний -> правый
                matrix[i, last] = top;
            }
        }
    }

    static void Main()
    {
        int[,] matrix = new int[7, 7];

        //заполнение массива случайными числами
        FillArray(matrix);

        Console.WriteLine("Исходный массив:");
        PrintArray(matrix);

        //поворот массива на 90 градусов вправо
        RotateArray90Degrees(matrix);

        Console.WriteLine("Массив после поворота на 90 градусов:");
        PrintArray(matrix);
    }
}

