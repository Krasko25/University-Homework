using System;

class Program
{
    //функция для перемножения двух матриц 5x5
    static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
    {
        int size = 5;
        int[,] resultMatrix = new int[size, size];

        //перемножение матриц по правилу матричного умножения
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                resultMatrix[i, j] = 0; //инициализация элемента результата

                //вычисление элемента путем суммирования произведений по строке и столбцу
                for (int k = 0; k < size; k++)
                {
                    resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }
        
        return resultMatrix;
    }

    //функция для вывода матрицы на экран
    static void PrintMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.Write("Задание 5:\n\n");
        int[,] matrixA = {
            { 8, 2, 5, 8, 5 },
            { 9, 1, 5, 9, 87 },
            { 16, 45, 17, 4, 1 },
            { 96, 17, 7, 89, 20 },
            { 19, 26, 29, 29, 2 }
        };

        int[,] matrixB = {
            { 28, 2, 27, 2, 1 },
            { 6, 9, 18, 54, 17 },
            { 54, 41, 3, 92, 1 },
            { 12, 7, 9, 75, 13 },
            { 2, 4, 52, 12, 1 }
        };

        //вывод исходных матриц
        Console.WriteLine("Матрица A:");
        PrintMatrix(matrixA);
        
        Console.WriteLine("\nМатрица B:");
        PrintMatrix(matrixB);

        //умножение матриц
        int[,] productMatrix = MultiplyMatrices(matrixA, matrixB);

        //вывод результата
        Console.WriteLine("\nРезультат умножения матриц:");
        PrintMatrix(productMatrix);
    }
}
