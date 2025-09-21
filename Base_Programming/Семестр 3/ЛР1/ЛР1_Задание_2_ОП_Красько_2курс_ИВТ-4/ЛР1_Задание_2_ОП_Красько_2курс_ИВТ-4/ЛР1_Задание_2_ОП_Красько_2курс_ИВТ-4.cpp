// ЛР1_Задание_2_ОП_Красько_2курс_ИВТ-4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <iomanip>

int* generateArr(int length) {
    int* x = new int[length];
    for (int i = 0; i < length; i++) {
        x[i] = i * i + 1;
        if (i % 2 == 1) { // В задании написано, что на -1 нужно домножать эл. с чётным индексом
            // но в примере умножали вторые элементы по порядку, т.е. с началом отчёта от 1, 
            // тут я сделал как в примере
            x[i] *= -1;
        }
    }
    return x;

}

void print5SymbolArr(int length, int* arr) {
    for (int i = 0; i < length; i++) {
        std::cout << std::setw(5) << arr[i] << "\n";
    }
}

void bubbleSort(int length, int* arr) {
    int temp;

    for (int i = 0; i < length; i++) {
        for (int j = 0; j < (length - 1 - i); j++) {
            if (arr[j] < arr[j + 1]) {
                temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}

int* splitArrIntoSmallerOnes(int originalLength, int* originalArr, int rowsAmount) {
    int columnsAmount = (originalLength + rowsAmount - 1) / rowsAmount; // округление в большую сторону
    int** outputArr = new int*[columnsAmount];
    for (int i = 0; i < columnsAmount; i++) {
        outputArr[i] = new int[rowsAmount];
    }

    /*for (int i = 0; i < columnsAmount; i++) {
        for (int j = 0; j < subArrSize; j++) {

        }
    }*/
}


using namespace std;
int main()
{
    int* arr1D{ nullptr };
    const int arrLength = 18;

    arr1D = generateArr(arrLength);

    bubbleSort(arrLength, arr1D);

    print5SymbolArr(arrLength, arr1D);




}

//Написать программу, которая преобразует одномерный массив(1D) в двумерный(2D)
//(или наоборот), в соответствии с вариантом.Необходимо оформить в отдельных
//функциях код следующих действий : 1) инициализация массива; 2) вывод массива; 3)
//преобразование массива(создание нового массива с другой структурой).Память под
//массивы выделять динамически и для доступа к элементам использовать указатели.
//Ввод - вывод данных организовать средствами iostream и iomanip.
//
//Преобразование: 1D → 2D.Одномерный массив из 20 целых чисел необходимо
//разложить по двумерной сетке 5х4 слева направо и сверху вниз.
//Инициализация : заполнить массив числами Фибоначчи : a[n] = a[n - 1] + a[n - 2].
//Вывод на экран : на каждый элемент массива отвести 7 позиций.
//[1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181 6765]
//= >
//[1  1   2    3     5
//8
//13
//89
//987
//144
//1597
//3. Функция strrchr.
//21
//233
//34
//377
//55
//610
//2584 4181  6765  ]