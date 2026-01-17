#include <iostream>
#include <vector>
#include <string>
#include <stdexcept> // для исключений


template <typename T> // T - тип-заглушка
class Cache {
private:
    std::vector<T> elements;

public:
    void put(T elem) {
        elements.push_back(elem);
    }

    Cache<T>& operator+=(T elem) {
        // Чтобы не дублировать код
        put(elem);
        return *this; // Возвращает сам себя
    }

    // Метод проверки наличия элемента
    bool contains(T elem) {
        for (size_t i = 0; i < elements.size(); i++) {
            if (elements[i] == elem) {
                return true;
            }
        }
        return false;
    }
};

// Явная специализация
template <> // <> знак специализации
class Cache<std::string> {
private:
    std::vector<std::string> elements;

public:
    void put(std::string elem) {
        if (elements.size() >= 100) {
            throw std::runtime_error("Нельзя добавить больше 100 строк!");
        }
        elements.push_back(elem);
    }

    Cache<std::string>& operator+=(std::string elem) {
        put(elem);
        return *this;
    }

    // Метод проверки наличия сравнивает только первые символы
    bool contains(std::string elem) {
        char firstChar = elem[0];

        for (size_t i = 0; i < elements.size(); i++) {
            if (!elements[i].empty() && elements[i][0] == firstChar) {
                return true;
            }
        }
        return false;
    }
};

int main() {
    setlocale(LC_ALL, "Russian");

    Cache<int> cache;

    cache.put(1);
    cache.put(5);
    cache += 98;
    cache += 113;
    std::cout << "Содержимое: 1, 2, 98, 113\n\n";

    std::cout << "Содержит 1: " << cache.contains(1) << "\n";
    std::cout << "Содержит 5: " << cache.contains(5) << "\n";
    std::cout << "Содержит 7: " << cache.contains(7) << "\n";

    Cache<std::string> voc;

    voc.put("Text");
    voc.put("Mouse");
    voc += "Lamp";
    std::cout << "\nСодержимое: \"Text\", \"Mouse\", \"Lamp\"\n\n";

    std::cout << "Содержит \"Tesla\": " << voc.contains("Tesla") << "\n";
    std::cout << "Содержит \"Apple\": " << voc.contains("Apple") << "\n";
    std::cout << "Содержит\"Table\": " << voc.contains("Table") << "\n";

    std::cout << "\nТестирование ограничения в 100 строк:" << "\n";
    Cache<std::string> Cache2;

    try {
        for (int i = 0; i < 101; i++) {
            Cache2 += "text " + std::to_string(i);
        }
        std::cout << "101-я строка добавлена" << "\n";
    }
    catch (const std::runtime_error& e) {
        std::cout << "Исключение: " << e.what() << "\n";
    }
    return 0;
}