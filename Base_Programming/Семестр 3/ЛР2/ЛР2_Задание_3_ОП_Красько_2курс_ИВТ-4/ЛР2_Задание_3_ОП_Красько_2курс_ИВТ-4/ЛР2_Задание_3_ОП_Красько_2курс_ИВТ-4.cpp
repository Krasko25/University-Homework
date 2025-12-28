#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;

class Conditioner {
private:
    string brand;   
    string model;
    double weight;
    double temperature;
    string mode;
    int year;    

public:
    Conditioner() {
        brand = "";
        model = "";
        weight = 0;
        temperature = 0;
        mode = "";
        year = 0;
    }

    Conditioner(string brandInput, string modelInput, double weightInput, double temperatureInput, 
        string modeInput, int yearInput) {
        brand = brandInput;
        model = modelInput;
        weight = weightInput;
        temperature = temperatureInput;
        mode = modeInput;
        year = yearInput;
    }

    string getBrand() {return brand;}
    string getModel() {return model;}
    double getWeight() {return weight;}
    double getTemperature() {return temperature;}
    string getMode() {return mode;}
    int getYear() {return year;}

    void setBrand(string brandInput) {brand = brandInput;}
    void setModel(string modelInput) {model = modelInput;}
    void setWeight(double weightInput) {weight = weightInput;}
    void setTemperature(double temperatureInput) {temperature = temperatureInput;}
    void setMode(string modeInput) {mode = modeInput;}
    void setYear(int yearInput) {year = yearInput;}

    void print() {
        cout << "Фирма: " << brand << endl;
        cout << "Модель: " << model << endl;
        cout << "Вес: " << weight << " кг" << endl;
        cout << "Температура: " << temperature << " °C" << endl;
        cout << "Режим: " << mode << endl;
        cout << "Год выпуска: " << year << endl;
    }

    // Сохранение в файл с именем по умолчанию
    void serialize() {
        ofstream file("conditioner.txt");
        if (file.is_open()) {
            file << brand << endl;
            file << model << endl;
            file << weight << endl;
            file << temperature << endl;
            file << mode << endl;
            file << year << endl;
            file.close();
            cout << "Данные сохранены" << endl;
        }
    }

    // Сохранение в файл с указанным именем
    void serialize(const string& fileName) {
        ofstream file(fileName);
        if (file.is_open()) {
            file << brand << endl;
            file << model << endl;
            file << weight << endl;
            file << temperature << endl;
            file << mode << endl;
            file << year << endl;
            file.close();
            cout << "Данные сохранены в файл " << fileName << endl;
        }
    }

    // Чтение из файла с именем по умолчанию
    void deserialize() {
        ifstream file("conditioner.txt");
        if (file.is_open()) {
            getline(file, brand); // getline считывает строку вместе с пробелами
            getline(file, model);
            file >> weight; // Для чисел
            file >> temperature;
            file.ignore(); // Пропускаем символ новой строки перед getline
            getline(file, mode);
            file >> year;
            file.close();
            cout << "Данные загружены" << endl;
        }
    }

    // Чтение из файла с указанием имени
    void deserialize(const string& filename) {
        ifstream file(filename);
        if (file.is_open()) {
            getline(file, brand);
            getline(file, model);
            file >> weight;
            file >> temperature;
            file.ignore();
            getline(file, mode);
            file >> year;
            file.close();
            cout << "Данные загружены из файла " << filename << endl;
        }
    }
};

int main() {
    setlocale(LC_ALL, "Russian");

    // В куче
    Conditioner* conditioner1 = new Conditioner("Samsung", "WindFree", 25.9, 22.0, "Авто", 2022);
    Conditioner* conditioner2 = new Conditioner("Lenovo", "BlueCool", 29.0, 24.0, "Вентиляция", 2023);

    // Кондиционер в стеке
    Conditioner conditioner3;
    conditioner3.setBrand("Dog");
    conditioner3.setModel("Pro");
    conditioner3.setWeight(28.0);
    conditioner3.setTemperature(20.0);
    conditioner3.setMode("Сушка");
    conditioner3.setYear(2023);

    cout << "-----------------\nИнформация о кондиционерах\n---------------" << endl;
    conditioner1->print();
    conditioner2->print();
    conditioner3.print(); // Тут точка т.к. это объект в стеке

    vector<double> history1;
    vector<double> history2;
    vector<double> history3;

    // Имитация настройки кондиционеров
    cout << "\n1-е настройки" << endl;

    cout << "Кондиционер 1: ";
    conditioner1->setMode("Охлаждение");
    conditioner1->setTemperature(18.0);
    history1.push_back(18.0);
    cout << "Режим: Охлаждение, температура: 18°C" << endl;

    cout << "Кондиционер 2: ";
    conditioner2->setMode("Вентиляция");
    cout << "Режим: Вентиляция" << endl;

    cout << "Кондиционер 3: ";
    conditioner3.setMode("Охлаждение");
    conditioner3.setTemperature(21.0);
    history3.push_back(21.0);
    cout << "Режим: Охлаждение, температура: 21°C" << endl;


    // Вторая настройка
    cout << "\n2-е настройки" << endl;

    cout << "Кондиционер 1: ";
    conditioner1->setMode("Обогрев");
    cout << "Режим: Обогрев" << endl;

    cout << "Кондиционер 2: ";
    conditioner2->setMode("Охлаждение");
    conditioner2->setTemperature(22.0);
    history2.push_back(22.0);
    cout << "Режим: Охлаждение, температура: 22°C" << endl;

    cout << "Кондиционер 3: ";
    conditioner3.setMode("Охлаждение");
    conditioner3.setTemperature(23.0);
    history3.push_back(23.0);
    cout << "Режим: Охлаждение, температура: 23°C" << endl;


    // Третья настройка
    cout << "\n3-я настройка" << endl;

    cout << "Кондиционер 1: ";
    conditioner1->setMode("Охлаждение");
    conditioner1->setTemperature(20.0);
    history1.push_back(20.0);
    cout << "Режим: Охлаждение, температура: 20°C" << endl;

    cout << "Кондиционер 2: ";
    conditioner2->setMode("Охлаждение");
    conditioner2->setTemperature(19.0);
    history2.push_back(19.0);
    cout << "Режим: Охлаждение, температура: 19°C" << endl;

    cout << "Кондиционер 3: ";
    conditioner3.setMode("Авто");
    cout << "Режим: Авто" << endl;

    cout << "\n------------------\nИтоги использования кондиционеров\n-----------------------------" << endl;

    // Кондиционер 1
    cout << "Кондиционер 1:" << endl;
    cout << "Текущий режим: " << conditioner1->getMode() << endl;
    double sum = 0;
    for (double temp : history1) {
        sum += temp;
    }
    double avg = sum / history1.size();
    cout << "Средняя температура в режиме охлаждения: " << avg << "°C" << endl;

    // Кондиционер 2
    cout << "Кондиционер 2:" << endl;
    cout << "Текущий режим: " << conditioner2->getMode() << endl;
    sum = 0;
    for (double temp : history2) {
        sum += temp;
    }
    avg = sum / history2.size();
    cout << "Средняя температура в режиме охлаждения: " << avg << "°C" << endl;

    // Кондиционер 3
    cout << "Кондиционер 3:" << endl;
    cout << "Текущий режим: " << conditioner3.getMode() << endl;
    sum = 0;
    for (double temp : history3) {
        sum += temp;
    }
    avg = sum / history3.size();
    cout << "Средняя температура в режиме охлаждения: " << avg << "°C" << endl;

    cout << "\n------------------\nРабота с файлами\n-----------------" << endl;

    // Сохраняем первый кондиционер в файл
    conditioner1->serialize("conditioner1Data.txt");

    // Создаем новый кондиционер и загружаем данные из файла
    Conditioner conditioner4;
    conditioner4.deserialize("conditioner1Data.txt");

    cout << "\nЗагруженный из файла кондиционер:" << endl;
    conditioner4.print();

    // Очищаем память
    delete conditioner1; // так как они создавались с new
    delete conditioner2;

    return 0;
}