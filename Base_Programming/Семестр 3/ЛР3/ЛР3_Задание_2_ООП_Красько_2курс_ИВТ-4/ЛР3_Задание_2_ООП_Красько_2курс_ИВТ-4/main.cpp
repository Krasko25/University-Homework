#include <iostream>

#include <vector>
#include <typeinfo>  // для RTTI

#include "conditioner.h"
#include "carconditioner.h"
#include "homeconditioner.h"

int main() {
    setlocale(LC_ALL, "Russian");

    // Создаем массив указателей на базовый класс
    std::vector<Conditioner*> conditioners;

    conditioners.push_back(new Conditioner("Samsung", "Basic", 25, 24, "Авто", 2022));
    conditioners.push_back(new CarConditioner("Toyota", "CarCool", 15, 25, "Охлаждение", 2023, 7, 
        "внедорожник", true));
    conditioners.push_back(new HomeConditioner("LG", "Comfort", 30, 26, "Охлаждение",
        2024, 35.5, 35));
    conditioners.push_back(new CarConditioner("Honda", "FastCool", 12, 27, "Вентиляция", 
        2023, 5, "седан", false));

    std::cout << "Полиморфизм:" << std::endl;
    for (int i = 0; i < conditioners.size(); i++) {
        std::cout << "\nКондиционер " << i + 1 << ":" << std::endl;
        conditioners[i]->printInfo();  // полиморфный вызов
        conditioners[i]->cool();       // полиморфный вызов
    }

    std::cout << "\n\nИспользование RTTI для определения типа:" << std::endl;
    for (int i = 0; i < conditioners.size(); i++) {
        std::cout << "\nОбъект " << i + 1 << ": ";

        if (dynamic_cast<CarConditioner*>(conditioners[i])) {
            std::cout << "Это автомобильный кондиционер!" << std::endl;
           
            // Вызываем методы, которые есть только у автомобильных кондиционеров
            CarConditioner* carCond = dynamic_cast<CarConditioner*>(conditioners[i]);
            carCond->showCarType();
        }
        else if (dynamic_cast<HomeConditioner*>(conditioners[i])) {
            std::cout << "Это домашний кондиционер!" << std::endl;
            
            HomeConditioner* homeCond = dynamic_cast<HomeConditioner*>(conditioners[i]);
            homeCond->showSuitableArea();
        }
        else {
            std::cout << "Это неклассифицированный кондиционер" << std::endl;
        }
    }

    // Демонстрация работы с файлами
    std::cout << "\n\nСохранение в файл:" << std::endl;
    conditioners[0]->saveToFile("base_cond.txt");

    Conditioner loadedCond;
    loadedCond.loadFromFile("base_cond.txt");
    std::cout << "Выгрузка из файла:" << std::endl;
    loadedCond.printInfo();

    // Очистка памяти
    for (int i = 0; i < conditioners.size(); i++) {
        delete conditioners[i];
    }

    return 0;
}