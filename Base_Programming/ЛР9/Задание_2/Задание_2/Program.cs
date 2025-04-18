using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Введите математическое выражение: ");
        string expression = Console.ReadLine();
      
        bool isValid = IsValidExpression(expression);

        Console.WriteLine($"Выражение: {expression} {(isValid ? "корректно" : "некорректно")}");
    }

    static bool IsValidExpression(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (var ch in expression)
        {
            if (ch == '(') 
            {
                stack.Push(ch);
            }
            else if (ch == ')')
            {
                // Если стек пуст, значит нет открывающей скобки для этой закрывающей
                if (stack.Count == 0)
                {
                    return false;
                }
                stack.Pop(); // Убираем соответствующую открывающую скобку
            }
        }

        // В конце стек должен быть пуст, если все скобки закрыты корректно
        return stack.Count == 0;
    }
}
