using System;

class Program
{
    static void Main()
    {
        // Ввод от пользователя
        Console.WriteLine("Введите текст для шифрования (только русские заглавные буквы):");
        string plaintext = Console.ReadLine().ToUpper();

        Console.WriteLine("Введите ключ для шифра Гронсфельда (только цифры):");
        string keyGronfeld = Console.ReadLine();

        Console.WriteLine("Введите ключ для шифра Тритемиуса (только русские заглавные буквы):");
        string keyTritemiusa = Console.ReadLine().ToUpper();
        
        Console.WriteLine("Выберите шифр:");
        Console.WriteLine("1. Шифр Гронсфельда");
        Console.WriteLine("2. Книжный шифр");
        Console.WriteLine("3. Шифр Тритемиуса");
        int choice = int.Parse(Console.ReadLine());

        string encryptedText = "";
        string decryptedText = "";

        switch (choice)
        {
            case 1:
                encryptedText = EncryptGronfeld(plaintext, keyGronfeld);
                decryptedText = DecryptGronfeld(encryptedText, keyGronfeld);
                Console.WriteLine("\nШифр Гронсфельда:");
                break;

            case 2:
                encryptedText = EncryptBook(plaintext);
                decryptedText = DecryptBook(encryptedText);
                Console.WriteLine("\nКнижный шифр:");
                break;

            case 3:
                encryptedText = EncryptTritemiusa(plaintext, keyTritemiusa);
                decryptedText = DecryptTritemiusa(encryptedText, keyTritemiusa);
                Console.WriteLine("\nШифр Тритемиуса:");
                break;

            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        Console.WriteLine("Зашифрованный текст: " + encryptedText);
        Console.WriteLine("Расшифрованный текст: " + decryptedText);
    }

    // Функция для шифрования с помощью шифра Гронсфельда (для русского алфавита)
    static string EncryptGronfeld(string text, string key)
    {
        string result = "";
        for (int i = 0; i < text.Length; i++)
        {
            int shift = key[i % key.Length] - '0';  // Преобразуем цифру из ключа в сдвиг
            char encryptedChar = (char)((text[i] - 'А' + shift) % 32 + 'А');  
            // Используем диапазон 'А'-'Я'
            result += encryptedChar;
        }
        return result;
    }

    // Функция для расшифрования с помощью шифра Гронсфельда (для русского алфавита)
    static string DecryptGronfeld(string text, string key)
    {
        string result = "";
        for (int i = 0; i < text.Length; i++)
        {
            int shift = key[i % key.Length] - '0';  // Преобразуем цифру из ключа в сдвиг
            char decryptedChar = (char)((text[i] - 'А' - shift + 32) % 32 + 'А');  
            // Используем диапазон 'А'-'Я'
            result += decryptedChar;
        }
        return result;
    }

    // Функция для шифрования с помощью книжного шифра (для русского алфавита)
    static string EncryptBook(string text)
    {
        string result = "";
        foreach (var ch in text)
        {
            char encryptedChar = (char)((ch - 'А' + 3) % 32 + 'А');  // Сдвиг на 3 символа
            result += encryptedChar;
        }
        return result;
    }

    // Функция для расшифрования с помощью книжного шифра
    static string DecryptBook(string text)
    {
        string result = "";
        foreach (var ch in text)
        {
            char decryptedChar = (char)((ch - 'А' - 3 + 32) % 32 + 'А');  // Обратный сдвиг на 3
            result += decryptedChar;
        }
        return result;
    }

    // Функция для шифрования с помощью шифра Тритемиуса
    static string EncryptTritemiusa(string text, string key)
    {
        string result = "";
        for (int i = 0; i < text.Length; i++)
        {
            int shift = key[i % key.Length] - 'А';  
            // Преобразуем букву ключа в сдвиг
            char encryptedChar = (char)((text[i] - 'А' + shift) % 32 + 'А');  
            // Используем диапазон 'А'-'Я'
            result += encryptedChar;
        }
        return result;
    }

    // Функция для расшифрования с помощью шифра Тритемиуса
    static string DecryptTritemiusa(string text, string key)
    {
        string result = "";
        for (int i = 0; i < text.Length; i++)
        {
            int shift = key[i % key.Length] - 'А';  // Преобразуем букву ключа в сдвиг
            char decryptedChar = (char)((text[i] - 'А' - shift + 32) % 32 + 'А');  
            // Используем диапазон 'А'-'Я'
            result += decryptedChar;
        }
        return result;
    }
}
