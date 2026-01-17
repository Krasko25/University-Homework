#include <iostream>
#include <vector>
#include <algorithm>
#include <string>

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
    // find_if ищет превый элемент, для которого функтор возвращает true

    std::cout << "\nКниги в диапазоне года издания 2005 - 2014:\n\n";

    while (finder != books.end())
    {
        std::cout << (*finder)->getAuthor() << " \""
            << (*finder)->getName() << "\"" << std::endl;
        finder = std::find_if(++finder, books.end(), bookFinderObject);
    }

    for (i = books.begin(); i != books.end(); ++i)
    {
        delete (*i);
    }

    return 0;
}