#include <iostream>

// Написать программу обработки одномерного массива с n элементами, в соответствии с 
//вариантом(приложение А).Необходимые действия должны производиться в
//функции processArray(), возвращающей определенное значение и формирующей
//еще один(выходной) массив данных(см.свой вариант).Память под массивы
//выделять статически(объявлять массивы локально в функции main) и для доступа к
//элементам использовать индексы.Ввод - вывод данных организовать средствами cstdio

//Объявить массив из n = 16 целых чисел, проинициализировать единицами.
//Функция processArray() должна заполнить элементы массива с четными индексами 
//степенями двойки(1, 2, 4, 8, 16, …), с нечетными индексами – степенями тройки(3, 9, 27, …).
//Также подсчитать и вернуть count – количество двузначных чисел в массиве и сформировать выходной массив, 
//содержащий только такие числа.Вывести на экран результирующие массивы.
//Вход: [3 2 9 4 27 8 81 16 243 32 729 64 2187 128 6561 256] 
//Выход : [27 81 16 32 64] count = 5

int processArray(const int arrLength, int count, int inputArr[], int outputArr[]) {
    int powerOf2 = 1;
    int powerOf3 = 1;
    for (int i = 0; i < arrLength; i += 2) {
        powerOf2 *= 2;
        inputArr[i] = powerOf2;
    }
    for (int i = 1; i < arrLength; i += 2) {
        powerOf3 *= 3;
        inputArr[i] = powerOf3;
    }

    std::cout << "Вход: [";
    for (int i = 0; i < arrLength; i++) {
        std::cout << inputArr[i] << " ";
    }
    std::cout << "]";

    return outputArr, count;

}

using namespace std;
int main()
{
    setlocale(LC_ALL, "Russian");

    const int arrLength = 16;
    int inputArr[arrLength] = { 1 };
    int outputArr[arrLength], count = 0;
    outputArr, count = processArray(arrLength, count, inputArr, outputArr);




    //std::cout << arr[1];
}
