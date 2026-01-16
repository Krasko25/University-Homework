#include "conditioner.h"

Conditioner::Conditioner() {
    brand = "";
    model = "";
    weight = 0;
    temperature = 0;
    mode = "";
    year = 0;
}

Conditioner::Conditioner(std::string brandInput, std::string modelInput, double weightInput,
    double temperatureInput, std::string modeInput, int yearInput) {
    brand = brandInput;
    model = modelInput;
    weight = weightInput;
    temperature = temperatureInput;
    mode = modeInput;
    year = yearInput;
}

std::string Conditioner::getBrand() { return brand; }
std::string Conditioner::getModel() { return model; }
double Conditioner::getWeight() { return weight; }
double Conditioner::getTemperature() { return temperature; }
std::string Conditioner::getMode() { return mode; }
int Conditioner::getYear() { return year; }

void Conditioner::setBrand(std::string brandInput) { brand = brandInput; }
void Conditioner::setModel(std::string modelInput) { model = modelInput; }
void Conditioner::setWeight(double weightInput) { weight = weightInput; }
void Conditioner::setTemperature(double temperatureInput) { temperature = temperatureInput; }
void Conditioner::setMode(std::string modeInput) { mode = modeInput; }
void Conditioner::setYear(int yearInput) { year = yearInput; }

void Conditioner::printInfo() {
    std::cout << "Фирма: " << brand << std::endl;
    std::cout << "Модель: " << model << std::endl;
    std::cout << "Вес: " << weight << " кг" << std::endl;
    std::cout << "Температура: " << temperature << " °C" << std::endl;
    std::cout << "Режим: " << mode << std::endl;
    std::cout << "Год выпуска: " << year << std::endl;
}

void Conditioner::cool() {
    std::cout << "Кондиционер охлаждает воздух" << std::endl;
    temperature -= 1;
}

void Conditioner::saveToFile(std::string filename) {
    std::ofstream file(filename);
    if (file.is_open()) {
        file << brand << std::endl;
        file << model << std::endl;
        file << weight << std::endl;
        file << temperature << std::endl;
        file << mode << std::endl;
        file << year << std::endl;
        file.close();
        std::cout << "Данные сохранены в файл " << filename << std::endl;
    }
}

void Conditioner::loadFromFile(std::string filename) {
    std::ifstream file(filename);
    if (file.is_open()) {
        std::getline(file, brand);
        std::getline(file, model);
        file >> weight;
        file >> temperature;
        file.ignore();
        std::getline(file, mode);
        file >> year;
        file.close();
        std::cout << "Данные загружены из файла " << filename << std::endl;
    }
}