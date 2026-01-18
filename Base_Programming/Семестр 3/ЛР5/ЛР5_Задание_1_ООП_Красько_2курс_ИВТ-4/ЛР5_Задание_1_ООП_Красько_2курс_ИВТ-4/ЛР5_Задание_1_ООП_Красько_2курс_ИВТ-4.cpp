#include <iostream>
#include <fstream>
#include <algorithm>
#include <iterator>
#include <cctype>
#include <vector>

template <typename T> 
class DataManager {
private:
    T data[64];
    int currentSize;
    const char* filename = "dump.dat";
    std::fstream file;

public:
    DataManager() : currentSize(0) {
        // Открываем файл для работы
        file.open(filename, std::ios::in | std::ios::out | std::ios::binary); // открытие файла для чтения и записи в бинарном режиме
        if (!file.is_open()) {
            // Создание файла только для записи, закрытие и открытие уже с чтением
            file.open(filename, std::ios::out | std::ios::binary);
            file.close();
            file.open(filename, std::ios::in | std::ios::out | std::ios::binary);
        }
    }

    ~DataManager() {
        if (file.is_open()) {
            file.close();
        }
    }

    void push(T elem) {
        if (currentSize == 64) {
            dumpToFile();
            currentSize = 0;
        }

        // Добавляем элемент в начало
        for (int i = currentSize; i > 0; i--) {
            data[i] = data[i - 1];
        }
        data[0] = elem;
        currentSize++;
    }

    void push(T elems[], size_t n) {
        size_t elementsToAdd;
        if (n > 64) { // Защита от переполнения
            elementsToAdd = 64;
        }
        else {
            elementsToAdd = n;
        }
        for (size_t i = 0; i < elementsToAdd; i++) {
            push(elems[i]);
        }
    }

    T peek() const {
        if (currentSize == 0) return T(0);

        // Для четного количества тоже возвращаем 0
        if (currentSize % 2 == 0) {
            return T(0);
        }
        else {
            return data[currentSize / 2];
        }
    }

    T pop() {
        if (currentSize == 0) {
            loadFromFile();
            // Если файл пустой
            if (currentSize == 0) return T(0);
        }

        int index;
        if (currentSize % 2 == 0) {
            index = currentSize / 2 - 1; // Первый элемент слева от центра
        }
        else {
            index = currentSize / 2; // Центральный элемент
        }

        T result = data[index];

        // Сдвиг элементов влево от удаляемого включительно и до конца
        for (int i = index; i < currentSize - 1; i++) {
            data[i] = data[i + 1];
        }
        currentSize--;

        return result;
    }

    void print(std::ostream& os = std::cout) const {
        // итератор вывода типа T
        std::ostream_iterator<T> out_it(os, ", "); // out_it пишет в поток os (т.е. std::cout)
        for (int i = 0; i < currentSize; i++) {
            // Убираем запятую после последнего элемента
            if (i == currentSize - 1) {
                os << data[i];
            }
            else {
                *out_it = data[i];
                ++out_it;
            }
        }
        os << std::endl;
    }

    int size() const {
        return currentSize;
    }

private:
    void dumpToFile() {
        if (!file.is_open()) return;

        file.seekp(0, std::ios::end); // seekp тут перемещает указатель в конец файла
        // Исправлено: записываем только текущие элементы, не весь массив
        for (int i = 0; i < currentSize; i++) {
            file.write(reinterpret_cast<const char*>(&data[i]), sizeof(T)); // Преобразует указатель на T в указатель на char
        }
        file.flush(); // запись данных из буфера на диск
    }

    void loadFromFile() {
        if (!file.is_open()) return;

        file.seekg(0, std::ios::beg); // Начало файла
        file.clear(); // Сброс флагов ошибок

        int elementsRead = 0;
        for (elementsRead = 0; elementsRead < 64; elementsRead++) {
            if (!file.read(reinterpret_cast<char*>(&data[elementsRead]), sizeof(T))) {
                break;
            }
        }
        currentSize = elementsRead;


        if (elementsRead > 0) {
            file.close();

            // Открываем файл и очищаем его
            file.open(filename, std::ios::out | std::ios::trunc);
            file.close();
            // Снова открываем для чтения и записи
            file.open(filename, std::ios::in | std::ios::out | std::ios::binary);
        }
    }
};

// Специализация для char
template <>
class DataManager<char> {
private:
    char data[64];
    int currentSize;
    const char* filename = "dump.dat";
    std::fstream file;

public:
    // Открываем файл для работы
    DataManager() : currentSize(0) {
        file.open(filename, std::ios::in | std::ios::out | std::ios::binary); // открытие файла для чтения и записи в бинарном режиме
        if (!file.is_open()) {
            // Создание файла только для записи, закрытие и открытие уже с чтением
            file.open(filename, std::ios::out | std::ios::binary);
            file.close();
            file.open(filename, std::ios::in | std::ios::out | std::ios::binary);
        }
    }

    ~DataManager() {
        if (file.is_open()) {
            file.close();
        }
    }

    void push(char elem) {
        // Заменяем пунктуацию на _
        if (std::ispunct(elem)) {
            elem = '_';
        }

        if (currentSize == 64) {
            dumpToFile();
            currentSize = 0;
        }

        for (int i = currentSize; i > 0; i--) {
            data[i] = data[i - 1];
        }
        data[0] = elem;
        currentSize++;
    }

    void push(char elems[], size_t n) {
        size_t elementsToAdd;
        if (n > 64) { // Защита от переполнения
            elementsToAdd = 64;
        }
        else {
            elementsToAdd = n;
        }
        for (size_t i = 0; i < elementsToAdd; i++) {
            push(elems[i]);
        }
    }

    char peek() const {
        if (currentSize == 0) return 0;

        // Для четного количества тоже возвращаем 0
        if (currentSize % 2 == 0) {
            return 0;
        }
        else {
            return data[currentSize / 2];
        }
    }

    char pop() {
        if (currentSize == 0) {
            loadFromFile();
            // Если файл пустой
            if (currentSize == 0) return 0;
        }

        int index;
        if (currentSize % 2 == 0) {
            index = currentSize / 2 - 1; // Первый элемент слева от центра
        }
        else {
            index = currentSize / 2; // Центральный элемент
        }

        char result = data[index];

        // Сдвиг элементов влево от удаляемого включительно и до конца
        for (int i = index; i < currentSize - 1; i++) {
            data[i] = data[i + 1];
        }
        currentSize--;

        return result;
    }

    char popUpper() {
        char c = pop(); // Получаем символ из массива
        return static_cast<char>(
            std::toupper(static_cast<unsigned char>(c))); // Преобразование char в unsigned char и обратно
    }

    char popLower() {
        char c = pop();
        return static_cast<char>(
            std::tolower(static_cast<unsigned char>(c)));
    }

    // Метод для вывода с использованием ostream_iterator
    void print(std::ostream& os = std::cout) const {
        std::ostream_iterator<char> out_it(os, " ");
        for (int i = 0; i < currentSize; i++) {
            *out_it = data[i];
            ++out_it;
        }
        os << std::endl;
    }

    int size() const {
        return currentSize;
    }

private:
    void dumpToFile() {
        if (!file.is_open()) return;

        file.seekp(0, std::ios::end); // seekp тут перемещает указатель в конец файла
        for (int i = 0; i < currentSize; i++) {
            file.write(&data[i], sizeof(char));
        }
        file.flush(); // запись данных из буфера на диск
    }

    void loadFromFile() {
        if (!file.is_open()) return;

        file.seekg(0, std::ios::beg); // Начало файла
        file.clear(); // Сброс флагов ошибок

        int elementsRead = 0;
        for (elementsRead = 0; elementsRead < 64; elementsRead++) {
            if (!file.read(&data[elementsRead], sizeof(char))) {
                break;
            }
        }
        currentSize = elementsRead;


        if (elementsRead > 0) {
            file.close();
            
            // Открываем файл и очищаем его
            file.open(filename, std::ios::out | std::ios::trunc);
            file.close();
            // Снова открываем для чтения и записи
            file.open(filename, std::ios::in | std::ios::out | std::ios::binary);
        }
    }
};

int main() {
    setlocale(LC_ALL, "Russian");

    std::cout << "Работа с int\n===========\n";
    DataManager<int> intManager;

    int intArr[] = { 20, 10, 8, 45, 3, 12, 5 };
    intManager.push(intArr, 7);

    std::cout << "Содержимое: ";
    intManager.print();

    std::cout << "peek(): " << intManager.peek() << "\n";
    std::cout << "pop(): " << intManager.pop() << "\n";
    std::cout << "Результат pop: ";
    intManager.print();

    std::cout << "\nРабота с double\n==============\n";
    DataManager<double> doubleManager;

    double doubleArr[] = { 8.1, 12.432, 72.8, 10, 5.12 };
    doubleManager.push(doubleArr, 5);

    std::cout << "Содержимое: ";
    doubleManager.print();

    std::cout << "peek(): " << doubleManager.peek() << "\n";
    std::cout << "pop(): " << doubleManager.pop() << "\n";
    std::cout << "Результат pop: ";
    doubleManager.print();

    std::cout << "\nРабота с char\n==============\n";
    DataManager<char> charManager;

    char charArr[] = "Some text, punctuation marks:,.";
    
    charManager.push(charArr, strlen(charArr));

    std::cout << "Содержимое: ";
    charManager.print();

    std::cout << "peek(): " << charManager.peek() << "\n";
    std::cout << "pop(): " << charManager.pop() << "\n";
    std::cout << "popUpper(): " << charManager.popUpper() << "\n";
    std::cout << "popLower(): " << charManager.popLower() << "\n";
    std::cout << "После извлечений: ";
    charManager.print();

    std::cout << "\nПереполнение\n==============\n";
    DataManager<int> testManager;

    for (int i = 1; i <= 70; i++) {
        testManager.push(i);
    }

    std::cout << "Добавляем 70 элементов 1, 2, 3, ..., 70\n";
    std::cout << "\nСодержимое: ";
    testManager.print();

    std::cout << "\nИзвлекаем 30 элементов, загружаются элементы из файла\n";
    for (int i = 1; i <= 30; i++) {
        testManager.pop();
    }

    std::cout << "\nСодержимое: ";
    testManager.print();

    return 0;
}