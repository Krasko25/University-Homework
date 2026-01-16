#include "carconditioner.h"

CarConditioner::CarConditioner() : Conditioner() {
    
    // Значения по умолчанию
    maxFanSpeed = 5;
    carType = "легковой";
    hasAirFilter = true;
}

CarConditioner::CarConditioner(std::string brand, std::string model, double weight,
    double temp, std::string mode, int year,
    int maxSpeed, std::string type, bool filter)
    : Conditioner(brand, model, weight, temp, mode, year) {

    maxFanSpeed = maxSpeed;
    carType = type;
    hasAirFilter = filter;
}

void CarConditioner::printInfo() {
    std::cout << "Кондиционер для автомобиля\n-----------------" << std::endl;
    Conditioner::printInfo();
    std::cout << "Максимальная скорость вентилятора: " << maxFanSpeed << std::endl;
    std::cout << "Тип авто: " << carType << std::endl;
    if (hasAirFilter) {
        std::cout << "Фильтр воздуха: есть" << std::endl;
    }
    else {
        std::cout << "Фильтр воздуха: нет" << std::endl;
    }
}

void CarConditioner::cool() {
    std::cout << "Автокондиционер быстро охлаждает салон" << std::endl;
    temperature -= 3;  // в машине кондиционер охлаждает быстрее
}

void CarConditioner::setFanSpeed(int speed) {
    if (speed <= maxFanSpeed) {
        std::cout << "Скорость вентилятора установлена на " << speed << std::endl;
    }
    else {
        std::cout << "Слишком большая скорость! Максимум " << maxFanSpeed << std::endl;
    }
}

void CarConditioner::showCarType() {
    std::cout << "Тип автомобиля, для которого предназначен этот кондиционер: " << carType << std::endl;
}