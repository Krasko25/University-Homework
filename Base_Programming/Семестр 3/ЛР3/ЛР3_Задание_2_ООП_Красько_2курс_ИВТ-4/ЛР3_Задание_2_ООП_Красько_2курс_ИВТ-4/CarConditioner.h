#pragma once

#include "conditioner.h"

class CarConditioner : public Conditioner {
private:
    int maxFanSpeed;
    std::string carType;
    bool hasAirFilter;

public:
    CarConditioner();
    CarConditioner(std::string brand, std::string model, double weight,
        double temp, std::string mode, int year,
        int maxSpeed, std::string type, bool filter);

    // Переопределение виртуальных методов
    void printInfo() override;
    void cool() override;

    void setFanSpeed(int speed);
    void showCarType();
};