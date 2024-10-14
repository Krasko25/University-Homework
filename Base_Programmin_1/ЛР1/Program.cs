using System;

class Program
{
    static void Main()
    {
        //задание 1
        Console.Write("Задание 1\n---------------\n ");
        Console.Write("Введите число: ");
        string input = Console.ReadLine();

        // Заменяем точку на запятую, если введено с точкой
        input = input.Replace('.', ',');

        double x = Convert.ToDouble(input);
        int d = (int)((x - Math.Floor(x)) * 10);
        Console.WriteLine($"Первая цифра дробной части: {d}");

        //задание 2
        Console.Write("\n\nЗадание 2\n---------------\n ");
        Console.Write("Сколько секунд прошло с начала суток: ");

        int seconds = Convert.ToInt32(Console.ReadLine());

        //подсчеты
        Console.WriteLine($"Часы: {seconds / 3600}, " +
            $"\nМинуты: {(seconds % 3600) / 60}," +
            $"\nСекунды: {(seconds % 3600) % 60}");

        //задание 3
        Console.Write("\n\nЗадание 3\n---------------\n ");

        Console.Write("Введите координаты стрелки:\n" +
            "Количество часов (от 0 до 11 вклчительно): ");
        int h = Convert.ToInt32(Console.ReadLine());

        Console.Write("Минуты: ");
        int m = Convert.ToInt32(Console.ReadLine());

        Console.Write("Секунды: ");
        int s = Convert.ToInt32(Console.ReadLine());

        // Вычисление угла
        // 360 градусов / 12 часов = 30 градусов за час
        //тут используется деление на вещественные числа, чтобы
        //промежуточный ответ тоже получился вещественным
        int angle = (int)(h * 30 + (m / 60.0) * 30 + 
            (s / 3600.0) * 30); 
        

        Console.WriteLine($"Угол стрелки: {angle} градусов");

        //задание 4
        Console.Write("\n\nЗадание 4\n---------------\n ");

        Console.Write("Введите число a: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите число b: ");
        int b = Convert.ToInt32(Console.ReadLine());


        a = a + b; 
        b = a - b; 
        a = a - b; 

        Console.WriteLine($"Результат:\na = {a}\nb = {b}");

        //задание 5
        //Написать программу, которая предлагает
        //пользователю ввести длины 2
        //катетов прямоугольного треугольника и
        //затем по этим данным вычисляет и
        //выводит на экран площадь и периметр треугольника.
        Console.Write("\n\nЗадание 5\n---------------\n ");

        Console.Write("Длина первого катета: ");
        int sideA = Convert.ToInt32(Console.ReadLine());

        Console.Write("Длина второго катета: ");
        int sideB = Convert.ToInt32(Console.ReadLine());

        //площадь
        float area = (sideA * sideB) / (float)2;

        //гипотенуза
         float hypotenuse = (float) Math.Sqrt(sideA * sideA + sideB * sideB);

        //периметр треугольника
        float perimeter = sideA + sideB + hypotenuse;

        Console.WriteLine($"Площадь треугольника: {area}");
        Console.WriteLine($"Периметр треугольника: {perimeter}");

        //Задание 6
        //Написать программу, которая
        //находит произведение цифр заданного 
        //четырехзначного числа. Например, для числа «1234»
        //ответ будет 1 * 2 * 3 * 4 = 24.
        Console.Write("\n\nЗадание 6\n---------------\n ");

        Console.Write("Введите четырёхзначное число: ");
        int fourDigitNumber = Convert.ToInt32(Console.ReadLine());

        //Проверка
        if ((fourDigitNumber < 1000) || (fourDigitNumber > 9999))
        {
            Console.WriteLine("Число должно быть четырехзначным");
            return;
        }

        int digit1 = fourDigitNumber / 1000;      
        int digit2 = (fourDigitNumber / 100) % 10; 
        int digit3 = (fourDigitNumber / 10) % 10; 
        int digit4 = fourDigitNumber % 10;        

        int result = digit1 * digit2 * digit3 * digit4;

        Console.WriteLine($"{digit1} * {digit2} * {digit3} * " +
            $"{digit4} = {result}");

        //Задание 7
        //Написать программу, которая записывает
        //введенное трехзначное число в 
        //обратном порядке в переменную reversed и
        //выводит ее на экран. Например, 
        //при вводе числа «362» будет выведено строкой ниже число «263»
        Console.Write("\n\nЗадание 7\n---------------\n ");

        Console.Write("Введите трёхзначное число: ");
        int threeDigitNumber = Convert.ToInt32(Console.ReadLine());

        //Проверка
        if (threeDigitNumber < 100 || threeDigitNumber > 999)
        {
            Console.WriteLine("Число должно быть трехзначным");
            return;
        }

        digit1 = threeDigitNumber / 100;      
        digit2 = (threeDigitNumber / 10) % 10; 
        digit3 = threeDigitNumber % 10;       

        //обратный порядок
        int reversedThreeDigitNumber = digit3 * 100 + digit2 * 10 + digit1;

        Console.WriteLine($"Число в обратном порядке: {reversedThreeDigitNumber}");

        //Задание 8
        //Ввести с клавиатуры действительное число х. Пользуясь только операциями 
        //умножения, сложения и вычитания, вычислить:
        //3x^4 - 5x^3 + 2x^2 - x + 7
        //при этом использовать не более четырех умножений и четырех сложений
        //вычитаний
        Console.Write("\n\nЗадание 8\n---------------\n ");

        Console.Write("Введите действительное число x: ");
        float p8_x = float.Parse(Console.ReadLine());

        // Вычисление выражения: 3x^4 - 5x^3 + 2x^2 - x + 7
        float p8_x2 = p8_x * p8_x;          // x^2
        float p8_x3 = p8_x2 * p8_x;         // x^3
        float p8_x4 = p8_x3 * p8_x;         // x^4

        float p8_result = 3 * p8_x4 - 5 * p8_x3 + 2 * p8_x2 - p8_x + 7;

        // Вывод результата
        Console.WriteLine($"Результат: {p8_result}");

        //Задание 9
        //Написать программу для решения системы уравнений (коэффициенты a, b, c
        //ввести с клавиатуры, определитель системы не должен быть равен 0): 
        Console.Write("\n\nЗадание 9\n---------------\n ");

        Console.Write("Введите a1: ");
        int a1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите b1: ");
        int b1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите c1: ");
        int c1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите d1: ");
        int d1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите a2: ");
        int a2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите b2: ");
        int b2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите c2: ");
        int c2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите d2: ");
        int d2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите a3: ");
        int a3 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите b3: ");
        int b3 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите c3: ");
        int c3 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите d3: ");
        int d3 = Convert.ToInt32(Console.ReadLine());

        //определители
        int D = a1 * (b2 * c3 - b3 * c2) - b1 * (a2 * c3 - a3 * c2) + c1 * (a2 * b3 - a3 * b2);
        int D_X = d1 * (b2 * c3 - b3 * c2) - b1 * (d2 * c3 - d3 * c2) + c1 * (d2 * b3 - d3 * b2);
        int D_Y = a1 * (d2 * c3 - d3 * c2) - d1 * (a2 * c3 - a3 * c2) + c1 * (a2 * d3 - a3 * d2);
        int D_Z = a1 * (b2 * d3 - b3 * d2) - b1 * (a2 * d3 - a3 * d2) + d1 * (a2 * b3 - a3 * b2);

        //провека на наличие решения
        if (D == 0)
        {
            Console.WriteLine("Система не имеет решения.");
        }
        else
        {
            double p9_x = (double)D_X / D;
            double p9_y = (double)D_Y / D;
            double p9_z = (double)D_Z / D;

            Console.WriteLine($"Решение системы:\nx = {p9_x},\ny = {p9_y},\nz = {p9_z}");
        }

        //Индивидуальное задание 1 
        //Разработать программу, которая позволяет ввести по отдельности данные из 
        //таблицы, представленной в приложении А, и выводит форматированную
        //таблицу на экран(включая заголовок и примечания).Целочисленные и
        //вещественные значения хранить в переменных соответствующих типов
        Console.Write("\n\nИндивидуальное задание 1\n---------------\n ");

        Console.WriteLine("Введите данные для общественного транспорта:");

        Console.Write("Вид транспорта (Тр - трамвай, Т-с - троллейбус, А - автобус): ");
        string transport1 = Console.ReadLine();
        Console.Write("Номер маршрута: ");
        string route1 = Console.ReadLine();
        Console.Write("Протяженность маршрута (км): ");
        double length1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Время в дороге (мин): ");
        int time1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Вид транспорта (Тр - трамвай, Т-с - троллейбус, А - автобус): ");
        string transport2 = Console.ReadLine();
        Console.Write("Номер маршрута: ");
        string route2 = Console.ReadLine();
        Console.Write("Протяженность маршрута (км): ");
        double length2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Время в дороге (мин): ");
        int time2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Вид транспорта (Тр - трамвай, Т-с - троллейбус, А - автобус): ");
        string transport3 = Console.ReadLine();
        Console.Write("Номер маршрута: ");
        string route3 = Console.ReadLine();
        Console.Write("Протяженность маршрута (км): ");
        double length3 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Время в дороге (мин): ");
        int time3 = Convert.ToInt32(Console.ReadLine());

        // Проверка видов транспорта
        if ((transport1 != "Тр" && transport1 != "Т-с" && transport1 != "А") ||
            (transport2 != "Тр" && transport2 != "Т-с" && transport2 != "А") ||
            (transport3 != "Тр" && transport3 != "Т-с" && transport3 != "А"))
        {
            Console.WriteLine("Ошибка: один или несколько видов транспорта указаны неверно. Используйте только Тр, Тс или А.");
            return;
        }

        // Вывод таблицы
        Console.WriteLine("\nОбщественный транспорт");
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("Вид транспорта\t№ маршрута\tПротяженность маршрута (км)\tВремя в дороге (мин)");
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine($"{transport1}\t\t{route1}\t\t{length1}\t\t\t{time1}");
        Console.WriteLine($"{transport2}\t\t{route2}\t\t{length2}\t\t\t{time2}");
        Console.WriteLine($"{transport3}\t\t{route3}\t\t{length3}\t\t\t{time3}");
        Console.WriteLine("------------------------------------------------------------------------------------");

        // Примечание
        Console.WriteLine("Примечание:");
        Console.WriteLine("Тр - трамвай, Т-с - троллейбус, А - автобус");

        //Индивидульное задание 2
        //Разработать программу, которая вычисляет и выводит на экран значения, в 
        //соответствии с формулами, приведенными в приложении А. Определить
        //области допустимых значений параметров формул(действительные числа). 
        //При демонстрации программы задать произвольные значения из этих областей.
        Console.Write("\n\nИндивидуальное задание 2\n---------------\n ");

        Console.WriteLine("Введите число а:");
        float p11_a = float.Parse(Console.ReadLine());
        Console.WriteLine("Введите число b:");
        float p11_b = float.Parse(Console.ReadLine());
        Console.WriteLine("Введите число x:");
        float p11_x = float.Parse(Console.ReadLine()); 

        // Проверка области допустимых значений для формулы y
        if (p11_b == 0 || p11_x / p11_b < 0)
        {
            Console.WriteLine("b не должно быть равно нулю, и x/b должно быть больше или равно нулю");
            return;
        }

        // Вычисление y
        double p11_y = Math.Pow(Math.Sin(Math.Pow(p11_x * p11_x + p11_a, 2)), 3) - Math.Sqrt(p11_x / p11_b);

        // Проверка области допустимых значений для формулы z
        if (p11_a == 0)
        {
            Console.WriteLine("a не должно быть равно нулю");
            return;
        }

        // Вычисление z
        double p11_z = (p11_x * p11_x) / p11_a + Math.Cos(Math.Pow(p11_x + p11_b, 3));

        // Вывод значений y и z
        Console.WriteLine($"Значение y: {p11_y}");
        Console.WriteLine($"Значение z: {p11_z}");


    }
}

