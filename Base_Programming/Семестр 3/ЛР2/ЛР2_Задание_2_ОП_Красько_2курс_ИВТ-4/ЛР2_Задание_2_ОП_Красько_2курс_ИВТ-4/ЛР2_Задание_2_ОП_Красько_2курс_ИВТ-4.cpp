#include <iostream>
#include <cstring>
#include <cmath>

using namespace std;

class Fraction {
private:
    int x; // Числитель
    int y; // Знаменатель

public:
    // Счетчик всех созданных дробей
    static int counter;

    Fraction(int chisl, int znam) {
        x = chisl;
        y = znam;
        if (y == 0) {
            y = 1;
            cout << "Ошибка: знаменатель не может быть нулем! Установлен 1." << endl;
        }
        counter++;
    }

    ~Fraction() {
        counter--; // Нужно, чтобы в случае удаления дроби число всех дробей было верно
    }

    void print() {
        cout << x << "/" << y;
    }

    // Сокращение дроби
    void reduce() {
        int divider = gcd(abs(x), abs(y));
        x /= divider;
        y /= divider;
    }

    // НОД
    static int gcd(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Перегрузка оператора +
    Fraction operator+(const Fraction& otherFraction) {
        // a/b + c/d = (a*d + c*b) / (b*d)
        int new_x = x * otherFraction.y + otherFraction.x * y;
        int new_y = y * otherFraction.y;
        Fraction result(new_x, new_y);
        result.reduce();
        return result;
    }

    // Перегрузка оператора -
    Fraction operator-(const Fraction& otherFraction) {
        int new_x = x * otherFraction.y - otherFraction.x * y;
        int new_y = y * otherFraction.y;
        Fraction result(new_x, new_y);
        result.reduce();
        return result;
    }

    // Перегрузка оператора *
    Fraction operator*(const Fraction& otherFraction) {
        int new_x = x * otherFraction.x;
        int new_y = y * otherFraction.y;
        Fraction result(new_x, new_y);
        result.reduce();
        return result;
    }

    // Перегрузка оператора /
    Fraction operator/(const Fraction& otherFraction) {
        int new_x = x * otherFraction.y;
        int new_y = y * otherFraction.x;
        Fraction result(new_x, new_y);
        result.reduce();
        return result;
    }

    // Статический метод для вывода десятичной дроби DOUBLE
    static void printAsFraction(double num) {
        // сохраняем первые 2 цифры от числа
        int chisl = num * 10000;
        int znam = 10000;

        Fraction f(chisl, znam);
        f.reduce();
        cout << num << " = ";
        f.print();
        cout << endl;
    }

    // Статический метод для вывода десятичной дроби СТРОКА
    static void printAsFraction(const char* num_str) {
        double num = atof(num_str);
        printAsFraction(num);
    }
};

int Fraction::counter = 0;

int main() {
    setlocale(LC_ALL, "Russian");
    cout << "Задание 2\n" << endl;

    Fraction f1(2, 4);  
    Fraction f2(3, 9); 
    Fraction f3(1, 5); 

    cout << "Дроби: " << Fraction::counter << endl;
    cout << endl;

    cout << "Дробь 1: "; f1.print(); cout << endl;
    cout << "Дробь 2: "; f2.print(); cout << endl;
    cout << "Дробь 3: "; f3.print(); cout << endl;
    cout << endl;

    f1.reduce();
    f2.reduce();
    cout << "После сокращения:" << endl;
    cout << "Дробь 1: "; f1.print(); cout << endl;
    cout << "Дробь 2: "; f2.print(); cout << endl;
    cout << endl;

    cout << "Арифметические операции:" << endl;

    Fraction sum = f1 + f2;
    cout << "f1 + f2 = "; f1.print(); cout << " + "; f2.print(); cout << " = "; sum.print(); cout << endl;
    Fraction diff = f1 - f2;
    cout << "f1 - f2 = "; f1.print(); cout << " - "; f2.print(); cout << " = "; diff.print(); cout << endl;
    Fraction prod = f1 * f2;
    cout << "f1 * f2 = "; f1.print(); cout << " * "; f2.print(); cout << " = "; prod.print(); cout << endl;
    Fraction quot = f1 / f2;
    cout << "f1 / f2 = "; f1.print(); cout << " / "; f2.print(); cout << " = "; quot.print(); cout << endl;

    cout << endl;

    cout << "Статические методы:" << endl;

    cout << "НОД(14, 18) = " << Fraction::gcd(14, 18) << endl;
    cout << "НОД(8, 3) = " << Fraction::gcd(8, 3) << endl;

    cout << endl;

    cout << "Преобразование десятичных дробей:" << endl;
    Fraction::printAsFraction(0.47);
    Fraction::printAsFraction(0.22);
    Fraction::printAsFraction(0.61);
    Fraction::printAsFraction(0.128);

    cout << endl;

    cout << "Из строки:" << endl;
    Fraction::printAsFraction("0.25");
    Fraction::printAsFraction("0.125");

    cout << endl;
    cout << "Всего создано дробей: " << Fraction::counter << endl;

    return 0;
}