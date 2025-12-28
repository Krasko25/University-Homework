#include <iostream>
#include <iomanip>

using namespace std;

class Vector {
private:
    int* data;
    int size;
public:
    Vector(int n) {
        size = n;
        data = new int[size];
    }

    ~Vector() {
        delete[] data;
    }

    // Перегрузка оператора индексации
    int& operator[](int index) {
        return data[index];
    }

    int getSize() const {
        return size;
    }

    // Префиксный инкремент
    Vector& operator++() {
        for (int i = 0; i < size; i++) {
            ++data[i];
        }
        return *this;
    }

    // Постфиксный инкремент
    void operator++(int) {
        for (int i = 0; i < size; i++) {
            data[i]++;
        }
    }

    // Префиксный декремент
    Vector& operator--() {
        for (int i = 0; i < size; i++) {
            --data[i];
        }
        return *this;
    }

    // Постфиксный декремент
    void operator--(int) {
        for (int i = 0; i < size; i++) {
            data[i]--;
        }
    }
};

class Matrix {
private:
    int** data;
    int rows;
    int colums;
public:
    Matrix(int r, int c) {
        rows = r;
        colums = c;
        data = new int* [colums];
        for (int i = 0; i < colums; i++) {
            data[i] = new int[rows];
        }
    }

    ~Matrix() {
        for (int i = 0; i < colums; i++) {
            delete[] data[i];
        }
        delete[] data;
    }

    int at(int i, int j) const {
        return data[i][j];
    }

    void setAt(int i, int j, int val) {
        data[i][j] = val;
    }

    int getRows() const {
        return rows;
    }

    int getcolums() const {
        return colums;
    }

    // Префиксный инкремент
    Matrix& operator++() {
        for (int i = 0; i < colums; i++) {
            for (int j = 0; j < rows; j++) {
                ++data[i][j];
            }
        }
        return *this;
    }

    // Постфиксный инкремент
    void operator++(int) {
        for (int i = 0; i < colums; i++) {
            for (int j = 0; j < rows; j++) {
                data[i][j]++;
            }
        }
    }

    // Префиксный декремент
    Matrix& operator--() {
        for (int i = 0; i < colums; i++) {
            for (int j = 0; j < rows; j++) {
                --data[i][j];
            }
        }
        return *this;
    }

    // Постфиксный декремент
    void operator--(int) {
        for (int i = 0; i < colums; i++) {
            for (int j = 0; j < rows; j++) {
                data[i][j]--;
            }
        }
    }
};

// на вход: длина массива одномерного
// на выход: указатель на одномерный массив
void generateArr(Vector& vec) {
    for (int i = 0; i < vec.getSize(); i++) {
        vec[i] = i * i + 1;
        if (i % 2 == 1) {
            vec[i] *= -1;
        }
    }
}

//на вход: длина массива, указатель на одномерный массив
//итог: выведенный в консоле массив со скобками квадратными
void print5SymbolArr(Vector& vec) {
    cout << "[ ";
    for (int i = 0; i < vec.getSize(); i++) {
        cout << setw(5) << vec[i] << " ";
    }
    cout << "]";
}

//на вход: количество столбцов в массиве (т.е. количество массивов в массиве), количество строк в массиве 
// (т.е. число элементов в каждом из саб массивов), указатель на двумерный массив
//итог: выведенный в консоле массив в виде матрицы со скобками квадратными
void print5Symbol2DArr(Matrix& mat) {
    int colums = mat.getcolums();
    int rows = mat.getRows();

    for (int i = 0; i < colums; i++) {
        for (int j = 0; j < rows; j++) {
            if (i == 0 && j == 0) {
                cout << "[" << setw(4) << mat.at(i, j) << "\t";
            }
            else {
                cout << setw(5) << mat.at(i, j) << "\t";
            }
        }
        if (i != (colums - 1)) {
            cout << "\n";
        }
    }
    cout << "]";
}

// на вход: длина массива, указатель на одномерный массив
// итог: отсортированный массив по тому же адрессу 
void bubbleSort(Vector& vec) {
    int length = vec.getSize();

    for (int i = 0; i < length; i++) {
        for (int j = 0; j < (length - 1 - i); j++) {
            if (vec[j] < vec[j + 1]) {
                int temp = vec[j];
                vec[j] = vec[j + 1];
                vec[j + 1] = temp;
            }
        }
    }
}

// на вход: указатель на одномерный массив, длина одномерного массива, количество желаемый строк, желаемое количество столбцов
// на выход: двумерный массив с суб массивами нужного размера
void splitArrIntoSmallerOnes(Vector& originalVec, Matrix& outputMat) {
    int originalLength = originalVec.getSize();
    int rows = outputMat.getRows();
    int colums = outputMat.getcolums();

    for (int i = 0; i < colums; i++) {
        for (int j = 0; j < rows; j++) {
            int index = i * rows + j;
            if (index >= originalLength) {
                outputMat.setAt(i, j, 0);
            }
            else {
                outputMat.setAt(i, j, originalVec[index]);
            }
        }
    }
}

int main() {
    setlocale(LC_ALL, "Russian");

    const int arrLength = 18;
    Vector arr1D(arrLength);

    generateArr(arr1D);

    cout << "Исходный массив: ";
    print5SymbolArr(arr1D);

    bubbleSort(arr1D);
    cout << "\nОтсортированный массив: ";
    print5SymbolArr(arr1D);

    int rowsAmount;

    cout << "\n\nВведите количество элементов в группе: ";
    while (true) {
        cin >> rowsAmount;
        if (cin.fail() || rowsAmount <= 0) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Ошибка ввода. Введите положительное число: ";
        }
        else {
            break;
        }
    }

    int columnsAmount = (arrLength + rowsAmount - 1) / rowsAmount;

    cout << "\nРазбиваем на " << columnsAmount << " групп(ы) по " << rowsAmount << " элементов\n";

    Matrix arr2D(rowsAmount, columnsAmount);
    splitArrIntoSmallerOnes(arr1D, arr2D);

    cout << "\nДвумерный массив:\n";
    print5Symbol2DArr(arr2D);

    cout << "\n\nДемонстрация операторов:";
    cout << "\nИсходный массив: ";
    print5SymbolArr(arr1D);

    ++arr1D;
    cout << "\nПосле ++arr1D: ";
    print5SymbolArr(arr1D);

    arr1D++;
    cout << "\nПосле arr1D++: ";
    print5SymbolArr(arr1D);

    cout << "\n\nДемонстрация для матрицы:";
    cout << "\nИсходная матрица:\n";
    print5Symbol2DArr(arr2D);

    ++arr2D;
    cout << "\n\nПосле ++arr2D:\n";
    print5Symbol2DArr(arr2D);

    return 0;
}