using System;
using System.Collections.Generic;

class Program
{
    // Класс-узел в циклическом связном списке
    class Node
    {
        public string Name;
        public Node Next;    // Ссылка на следующий элемент

        public Node(string name)
        {
            Name = name;
            Next = null;
        }
    }

    // Класс-циклический связный список
    class CircularLinkedList
    {
        public Node Head;

        // Метод для добавления элемента в список
        public void Add(string name)
        {
            Node newNode = new Node(name);
            if (Head == null)
            {
                Head = newNode;
                Head.Next = Head;  // Ссылка на себя для замыкания цикла
            }
            else
            {
                Node current = Head;
                while (current.Next != Head)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                newNode.Next = Head;
            }
        }

        // Метод для получения участника по индексу
        public Node GetNodeAt(int index)
        {
            Node current = Head;
            int count = 0;
            while (count < index)
            {
                current = current.Next;
                count++;
            }
            return current;
        }
    }

    static void Main(string[] args)
    {
        // Загрузка имен участников
        List<string> participants = new List<string>
        {
            "Иван", "Мария", "Петр", "Анна", "Елена", "Дмитрий", "Оля"
        };

        // Создаем связный список
        CircularLinkedList circle = new CircularLinkedList();
        foreach (var name in participants)
        {
            circle.Add(name);
        }

        // Строки считалки
        string[] rhymeLines = new string[]
        {
            "Посчитаем дыры в сыре.",
            "Если в сыре много дыр,",
            "Значит, вкусным будет сыр.",
            "Если в нём одна дыра, ",
            "Значит, вкусным был вчера!"
        };

        //Console.WriteLine("Строки считалки:");
        //for (int i = 0; i < rhymeLines.Length; i++)
        //{
        //    Console.WriteLine($"{i + 1}. {rhymeLines[i]}");
        //}

        Console.WriteLine("Выберите строку считалки (введите номер от 1 до 5):");
        int rhymeChoice = int.Parse(Console.ReadLine()) - 1;

        if (rhymeChoice < 0 || rhymeChoice >= rhymeLines.Length)
        {
            Console.WriteLine("Неверный выбор строки считалки!");
            return;
        }

        string rhyme = rhymeLines[rhymeChoice];
        string[] words = rhyme.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        int numWords = words.Length;

        Console.WriteLine("\nСписок участников:");
        for (int i = 0; i < participants.Count; i++)
        {
            Console.WriteLine($"{i}. {participants[i]}");
        }

        Console.WriteLine("\nС какого участника начинаем? (Введите индекс от 0 до {0}):", participants.Count - 1);
        int startIndex = int.Parse(Console.ReadLine());

        if (startIndex < 0 || startIndex >= participants.Count)
        {
            Console.WriteLine("Неверный индекс участника!");
            return;
        }

        // Получаем начальную точку
        Node startNode = circle.GetNodeAt(startIndex);

        // Моделируем игру
        Node current = startNode;
        for (int i = 0; i < numWords - 1; i++)
        {
            current = current.Next;
        }

        Console.WriteLine("\nПоследнее слово выпадет на: " + current.Name);
    }
}
