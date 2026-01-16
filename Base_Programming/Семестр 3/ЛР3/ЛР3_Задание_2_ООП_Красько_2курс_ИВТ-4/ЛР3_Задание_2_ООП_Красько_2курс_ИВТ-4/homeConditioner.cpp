#include "homeconditioner.h"

HomeConditioner::HomeConditioner() : Conditioner() {
    roomArea = 20.0;
    noiseLevel = 40;
}

HomeConditioner::HomeConditioner(std::string brand, std::string model, double weight,
    double temp, std::string mode, int year,
    double area, int noise)
    : Conditioner(brand, model, weight, temp, mode, year) {
    roomArea = area;
    noiseLevel = noise;
}

void HomeConditioner::printInfo() {
    std::cout << "Кондиционер для дома\n-------------------" << std::endl;
    Conditioner::printInfo();
    std::cout << "Площадь помещения: " << roomArea << " м2" << std::endl;
    std::cout << "Уровень шума: " << noiseLevel << " дБ" << std::endl;
}

void HomeConditioner::cool() {
    std::cout << "Домашний кондиционер плавно охлаждает комнату" << std::endl;
    temperature -= 0.5;  // дома охлаждает медленнее
}

void HomeConditioner::showSuitableArea() {
    std::cout << "Этот кондиционер подходит для комнаты " << roomArea << " м2" << std::endl;
}