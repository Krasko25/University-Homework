using System;

class Program
{
    static void Main()
    {
        Random random = new Random();

        MyLinkedList list1 = new MyLinkedList();
        MyLinkedList list2 = new MyLinkedList();

        // список 1
        for (int i = 0; i < 10; i++)
        {
            list1.Add(random.Next(1, 21));  // Числа от 1 до 20
        }

        // список 2
        for (int i = 0; i < 8; i++)
        {
            list2.Add(random.Next(1, 21));  
        }

        // Выводим исходные списки
        Console.WriteLine("Первый список:");
        list1.Print();

        Console.WriteLine("Второй список:");
        list2.Print();

        // Оставляем в list1 только те элементы, которые есть и во втором
        list1.FilterCommonElements(list2);

        Console.WriteLine("Общие элементы:");
        list1.Print();
    }
}

public class MyLinkedList
{
    private Node head;

    public void Add(int value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void FilterCommonElements(MyLinkedList otherList)
    {
        Node current = head;
        while (current != null)
        {
            if (!otherList.Contains(current.Value))
            {
                Remove(current.Value);
            }
            current = current.Next;
        }
    }

    private void Remove(int value)
    {
        if (head == null) return;

        if (head.Value == value)
        {
            head = head.Next;
            return;
        }

        Node current = head;
        while (current.Next != null && current.Next.Value != value)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    // Проверка, содержится ли элемент в списке
    private bool Contains(int value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Value == value)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Print()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    // Класс узла связного списка
    private class Node
    {
        public int Value;
        public Node Next;

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }
}
