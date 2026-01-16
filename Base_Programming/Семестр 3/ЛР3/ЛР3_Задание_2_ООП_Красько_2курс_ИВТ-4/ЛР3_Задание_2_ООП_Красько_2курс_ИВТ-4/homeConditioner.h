#pragma once

#include "conditioner.h"

class HomeConditioner : public Conditioner {
private:
    double roomArea;
    int noiseLevel;       

public:
    HomeConditioner();
    HomeConditioner(std::string brand, std::string model, double weight,
        double temp, std::string mode, int year,
        double area, int noise);

    void printInfo() override;
    void cool() override;

    void showSuitableArea();
};