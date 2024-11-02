using System;

class Program
{
    static void Main()
    {
        Console.Write("Индивидуальное задание 1. Вариант 8:\n\n");
        int size = 9;
        int[,] matrix = new int[size, size];

        // Заполняем матрицу случайными числами и выводим её
        FillMatrix(matrix, size);
        Console.WriteLine("Исходная матрица:");
        PrintMatrix(matrix, size);

        // Отображаем симметричные сектора
        MirrorSectors(matrix, size);

        Console.WriteLine("\nРезультат:");
        PrintMatrix(matrix, size);
    }

    // Функция для заполнения матрицы случайными числами
    static void FillMatrix(int[,] matrix, int size)
    {
        Random rand = new Random();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = rand.Next(1, 10); // Заполняем числами от 1 до 9
            }
        }
    }

    // Функция для вывода матрицы
    static void PrintMatrix(int[,] matrix, int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Функция для зеркального отображения элементов
    static void MirrorSectors(int[,] matrix, int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < i; j++)
            {
                // Отражаем относительно главной диагонали
                if (j < size - i - 1)
                {
                    matrix[i, j] = matrix[i, size - j - 1];
                }

                // Отражаем относительно побочной диагонали
                if (j > size - i - 1)
                {
                    matrix[i, j] = matrix[size - i - 1, j];
                }
            }
        }
    }
}
