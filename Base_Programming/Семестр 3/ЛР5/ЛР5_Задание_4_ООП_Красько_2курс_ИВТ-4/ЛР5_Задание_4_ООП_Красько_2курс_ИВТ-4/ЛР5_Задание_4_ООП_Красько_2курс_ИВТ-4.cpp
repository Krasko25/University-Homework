#include <iostream>
#include <vector>
#include <algorithm>
#include <string>
#include <functional>  // Необходимо для greater и bind2nd

using namespace std;


class Book {
private:
    string name;
    string author;
    int year;

public:
    Book(string n, string a, int y) {
        name = n;
        author = a;
        year = y;
    }

    // Геттеры
    string getName() const {
        return name;
    }

    string getAuthor() const {
        return author;
    }

    int getYear() const {
        return year;
    }
};

// Функтор для сортировки
class BookSorter {
public:
    bool operator()(Book* b1, Book* b2) {
        // В первую очередь сравниваются авторы
        if (b1->getAuthor() != b2->getAuthor()) {
            return b1->getAuthor() < b2->getAuthor();
        }
        // Если авторы одинаковые, сравниваются названия
        return b1->getName() < b2->getName();
    }
};

// Функтор для фильтрации книг по годам
class BookFinder {
private:
    int startYear;
    int endYear;

public:
    BookFinder(int start, int end) {
        startYear = start;
        endYear = end;
    }

    bool operator()(Book* book) {
        return book->getYear() >= startYear && book->getYear() <= endYear;
    }
};

int main() {
    setlocale(LC_ALL, "RUSSIAN");

    std::vector<Book*> books;
    books.push_back(new Book("Война и мир", "Толстой Л.Н.", 2010));
    books.push_back(new Book("Подросток", "Достоевский Ф.М.", 2004));
    books.push_back(new Book("Обрыв", "Гончаров И.А.", 2010));
    books.push_back(new Book("Анна Каренина", "Толстой Л.Н.", 1999));
    books.push_back(new Book("Обыкновенная история", "Гончаров И.А.", 2011));
    books.push_back(new Book("Утраченные иллюзии", "Бальзак О.", 2009));
    books.push_back(new Book("Оливер Твист", "Диккенс Ч.", 2001));
    books.push_back(new Book("Фауст", "Гёте И.В.", 2010));
    books.push_back(new Book("Лилия долины", "Бальзак О.", 1998));

    std::cout << "\nКниги в алфавитном порядке:\n\n";

    BookSorter bookSorterObject;
    std::sort(books.begin(), books.end(), bookSorterObject); // bookSorterObject - признак сортировки

    std::vector<Book*>::iterator i; // умный указатель, ходящий по списку книг
    for (i = books.begin(); i != books.end(); ++i)
    {
        std::cout << (*i)->getAuthor() << " \""
            << (*i)->getName() << "\"" << std::endl;
    }

    BookFinder bookFinderObject(2005, 2014);
    std::vector<Book*>::iterator finder = std::find_if(books.begin(), books.end(), bookFinderObject);
    // find_if ищет первый элемент, для которого функтор возвращает true

    std::cout << "\nКниги в диапазоне года издания 2005 - 2014:\n\n";

    while (finder != books.end())
    {
        std::cout << (*finder)->getAuthor() << " \""
            << (*finder)->getName() << "\"\n";;
        finder = std::find_if(++finder, books.end(), bookFinderObject);
    }


    std::cout << "\nКоличество книг новее 2009 года: ";

    // Получаем годы в отдельный вектор
    std::vector<int> years;
    for (i = books.begin(); i != books.end(); ++i) {
        years.push_back((*i)->getYear());
    }

    int count = std::count_if(years.begin(), years.end(),
        std::bind2nd(std::greater<int>(), 2009));

    // std::greater<int> - функтор для целых чисел, возвращает, больше ли 1-е число 2-го
    // std::bind2nd() - функция-адаптер, создающий новый функтор

    std::cout << count << std::endl;

    std::cout << "\nКниги новее 2009 года:\n";
    for (i = books.begin(); i != books.end(); ++i) {
        if ((*i)->getYear() > 2009) {  // Проверяем, новее ли 2009 года
            std::cout << (*i)->getAuthor() << " \""
                << (*i)->getName() << "\" ("
                << (*i)->getYear() << ")\n";
        }
    }

    for (i = books.begin(); i != books.end(); ++i)
    {
        delete (*i);
    }

    return 0;
}