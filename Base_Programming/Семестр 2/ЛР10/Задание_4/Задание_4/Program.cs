using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Random rand = new Random();

        Console.WriteLine("Введите количество городов:");
        int n = int.Parse(Console.ReadLine());

        // Генерация матрицы смежности
        int[,] A = GenerateRandomMatrix(n, rand);

        Console.WriteLine("\nСгенерированная матрица смежности:");
        PrintMatrix(A);

        Console.WriteLine($"Сгенерирована матрица для {n} городов.");
        Console.WriteLine("Введите номер исходного города (от 1 до " + n + "):");
        int startCity = int.Parse(Console.ReadLine()) - 1;  // Индекс в массиве начинается с 0

        int maxDistance = 200;

        // Массив для отслеживания посещенных городов
        bool[] visited = new bool[n];

        Console.WriteLine("Города, в которые можно добраться по пути не длиннее 200 км:");

        DFS(A, startCity, 0, maxDistance, visited);
    }

    static int[,] GenerateRandomMatrix(int n, Random rand)
    {
        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                {
                    matrix[i, j] = 0;
                }
                else
                {
                    // С вероятностью 75% создаем путь, иначе -1
                    if (rand.NextDouble() <= 0.75)
                    {
                        matrix[i, j] = rand.Next(1, 210);
                    }
                    else
                    {
                        matrix[i, j] = -1; 
                    }
                }
            }
        }

        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == -1)
                    Console.Write(" -1 "); 
                else
                    Console.Write($"{matrix[i, j],3} ");
            }
            Console.WriteLine();
        }
    }

    // Функция для поиска в глубину
    static void DFS(int[,] A, int currentCity, int currentDistance, int maxDistance, bool[] visited)
    {
        if (visited[currentCity]) return;

        visited[currentCity] = true;

        if (currentDistance <= maxDistance)
        {
            Console.WriteLine($"Город {currentCity + 1} (расстояние: {currentDistance} км)");
        }

        // Рекурсивно проверяем все соседние города
        for (int i = 0; i < A.GetLength(0); i++)
        {
            if (A[currentCity, i] != -1 && !visited[i])
            {
                int newDistance = currentDistance + A[currentCity, i];

                // Если сумма расстояний не превышает максимального значения, продолжаем искать
                if (newDistance <= maxDistance)
                {
                    DFS(A, i, newDistance, maxDistance, visited);
                }
            }
        }
    }
}
