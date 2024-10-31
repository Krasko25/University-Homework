using System;

class Program
{
    //рекурсивная функция для вычисления определителя матрицы NxN
    static double Determinant(double[,] matrix, int n)
    {
        //базовый случай: если матрица 1x1, возвращаем её единственный элемент
        if (n == 1)
        {
            return matrix[0, 0];
        }

        double det = 0;

        //вычисление определителя по формуле Лапласа
        for (int j = 0; j < n; j++)
        {
            //создание минора M_ij
            double[,] minor = new double[n - 1, n - 1];

            for (int row = 1; row < n; row++)
            {
                int minorCol = 0;
                for (int col = 0; col < n; col++)
                {
                    //пропускаем текущий столбец
                    if (col == j) continue;
                    minor[row - 1, minorCol] = matrix[row, col];
                    minorCol++;
                }
            }

            //добавляем произведение элемента на определитель минора
            det += matrix[0, j] * Math.Pow(-1, j) * Determinant(minor, n - 1);
        }

        return det;
    }

    //функция для вывода матрицы
    static void PrintMatrix(double[,] matrix, int n)
    {
        Console.WriteLine("Матрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.Write("Задание 8:\n\n");

        double[,] matrix = {
            { 3, 1, 2, 4, 5 },
            { 1, 0, 2, 3, 4 },
            { 4, 6, 1, 8, 2 },
            { 2, 3, 4, 5, 1 },
            { 3, 4, 6, 2, 8 }
        };

        int n = matrix.GetLength(0);

        //выводим матрицу
        PrintMatrix(matrix, n);

        //вычисляем определитель
        double determinant = Determinant(matrix, n);

        //выводим результат
        Console.WriteLine($"Определитель матрицы равен: {determinant}");
    }
}
