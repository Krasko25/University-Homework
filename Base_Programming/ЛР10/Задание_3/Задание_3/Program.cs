using System;
using System.Collections.Generic;

class Graph
{
    private int[,] connectionsMatrix;  
    private int numberOfVertices;
    private List<int>[] connectionsList; 

    public Graph(int[,] matrix)
    {
        numberOfVertices = matrix.GetLength(0);
        connectionsMatrix = matrix;
        connectionsList = new List<int>[numberOfVertices];

        for (int i = 0; i < numberOfVertices; i++)
        {
            connectionsList[i] = new List<int>();
            for (int j = 0; j < numberOfVertices; j++)
            {
                if (connectionsMatrix[i, j] == 1)
                {
                    connectionsList[i].Add(j);
                }
            }
        }
    }

    public void DFS(int start, int end)
    {
        bool[] visited = new bool[numberOfVertices];
        List<int> path = new List<int>();
        DFSRecursive(start, end, visited, path);
    }

    private void DFSRecursive(int current, int end, bool[] visited, List<int> path)
    {
        visited[current] = true;
        path.Add(current + 1);

        if (current == end)
        {
            Console.WriteLine("Алгоритм DFS:");
            Console.WriteLine(string.Join(" -> ", path));
        }
        else
        {
            foreach (int neighbor in connectionsList[current])
            {
                if (!visited[neighbor])
                {
                    DFSRecursive(neighbor, end, visited, path);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }

    public void BFS(int start, int end)
    {
        bool[] visited = new bool[numberOfVertices];
        Queue<List<int>> queue = new Queue<List<int>>();
        visited[start] = true;
        queue.Enqueue(new List<int> { start });

        List<List<int>> allPaths = new List<List<int>>();

        while (queue.Count > 0)
        {
            List<int> path = queue.Dequeue();
            int node = path[path.Count - 1];

            if (node == end)
            {
                allPaths.Add(new List<int>(path));
            }

            foreach (int neighbor in connectionsList[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    List<int> newPath = new List<int>(path) { neighbor };
                    queue.Enqueue(newPath);
                }
            }
        }

        Console.WriteLine("Алгоритм BFS:");
        foreach (var p in allPaths)
        {
            Console.WriteLine(string.Join(" -> ", p.ConvertAll(n => n + 1)));
        }
    }

    public void PrintConnectionsMatrix()
    {
        int edgesCount = 0;

        for (int i = 0; i < numberOfVertices; i++)
        {
            for (int j = i + 1; j < numberOfVertices; j++)
            {
                if (connectionsMatrix[i, j] == 1)
                {
                    edgesCount++;
                }
            }
        }

        int[,] connectionsMatrixOutput = new int[numberOfVertices, edgesCount];
        int edgeIndex = 0;

        for (int i = 0; i < numberOfVertices; i++)
        {
            for (int j = i + 1; j < numberOfVertices; j++)
            {
                if (connectionsMatrix[i, j] == 1)
                {
                    connectionsMatrixOutput[i, edgeIndex] = 1;
                    connectionsMatrixOutput[j, edgeIndex] = 1;
                    edgeIndex++;
                }
            }
        }

        Console.WriteLine("Матрица связей:");
        for (int i = 0; i < numberOfVertices; i++)
        {
            for (int j = 0; j < edgesCount; j++)
            {
                Console.Write(connectionsMatrixOutput[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void PrintConnectionsList()
    {
        Console.WriteLine("Связанные вершины:");
        for (int i = 0; i < numberOfVertices; i++)
        {
            Console.Write((i + 1) + ": ");
            foreach (int neighbor in connectionsList[i])
            {
                Console.Write((neighbor + 1) + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        int[,] connectionsMatrix = {
            { 0, 1, 1, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 1, 1, 0 },
            { 1, 0, 0, 1, 0, 1, 0, 1 },
            { 0, 0, 1, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 1, 0, 0 },
            { 0, 1, 1, 0, 1, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 1, 0, 0, 0, 1, 0 }
        };

        Graph graph = new Graph(connectionsMatrix);

        graph.PrintConnectionsMatrix();
        graph.PrintConnectionsList();

        int start = GetVertexInput("Введите вершину X (от 1 до 8):");

        int end = GetVertexInput("Введите вершину Y (от 1 до 8):");

        graph.DFS(start, end);
        graph.BFS(start, end);
    }

    static int GetVertexInput(string prompt)
    {
        int vertex;
        bool validInput = false;

        while (!validInput)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out vertex) && vertex >= 1 && vertex <= 8)
            {
                validInput = true;
                return vertex - 1;  // Возвращаем индекс вершины от 0 до 7
            }
            else
            {
                Console.WriteLine("Ошибка: введите число от 1 до 8.");
            }
        }

        return -1;
    }
}
