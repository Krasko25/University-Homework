// ЛР1_Задание_3_ОП_Красько_2курс_ИВТ-4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

// Написать свой аналог стандартной функции обработки строк из файла cstring, 
// в соответствии с вариантом. 
// В функции main на тестовых данных продемонстрировать результат работы 
// как стандартной функции, 
// так и собственной версии. Ввод-вывод данных организовать средствами cstdio.

//Функция strcpy.Формат char* strcpy(char* dest, const char* src).
//Функция копирует строку src в строку dest.

#define _CRT_SECURE_NO_WARNINGS // чтобы компилятор не жаловался на strcpy

#include <iostream>
#include <Windows.h> // нужно для ввода пользователем русских символов

using namespace std;

void printString(char* string) {
    for (int i = 0; i <= strlen(string); i++) {
        cout << string[i];
    }
    cout << "\n";
}

void copyString(char* whereToCopy, char* whatToCopy) {
    for (int i = 0; i <= strlen(whatToCopy); i++) {
        whereToCopy[i] = whatToCopy[i];
    }
}




int main()
{
    setlocale(LC_ALL, "Russian");
    SetConsoleOutputCP(1251); // нужно для ввода пользователем русских символов
    SetConsoleCP(1251); // нужно для ввода пользователем русских символов

    const int MAX_LENGTH = 100;
    
    // начальная строка от пользователя
    cout << "Введите строку: ";
    char* src = new char[MAX_LENGTH];
    std::cin.getline(src, MAX_LENGTH);

    // заводская функция
    char* dest = new char[strlen(src) + 1]; // добавляем 1 байт, чтобы было место для символа завершения строки \0
    strcpy(dest, src);
    cout << "Результат от strcpy:\n";
    printString(dest);

    // самодельная функция
    char* dest2 = new char[strlen(src) + 1];
    copyString(dest, src);
    cout << "Результат от собственноручной функции:\n";
    printString(dest);

    delete[] src;
    delete[] dest;
    delete[] dest2;

    
}


