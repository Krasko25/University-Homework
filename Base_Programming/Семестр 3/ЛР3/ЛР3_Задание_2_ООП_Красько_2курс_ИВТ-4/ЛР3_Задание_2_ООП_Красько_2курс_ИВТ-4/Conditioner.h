#pragma once

#include <iostream>
#include <fstream>
#include <string>
#include <vector>

class Conditioner {
protected:
    std::string brand;
    std::string model;
    double weight;
    double temperature;
    std::string mode;
    int year;

public:
    Conditioner();
    Conditioner(std::string brandInput, std::string modelInput, double weightInput,
        double temperatureInput, std::string modeInput, int yearInput);

    virtual ~Conditioner() {}

    // Геттеры
    std::string getBrand();
    std::string getModel();
    double getWeight();
    double getTemperature();
    std::string getMode();
    int getYear();

    // Сеттеры
    void setBrand(std::string brandInput);
    void setModel(std::string modelInput);
    void setWeight(double weightInput);
    void setTemperature(double temperatureInput);
    void setMode(std::string modeInput);
    void setYear(int yearInput);

    virtual void printInfo();
    virtual void cool();  // Охлаждение
    virtual void saveToFile(std::string filename = "conditioner.txt");
    virtual void loadFromFile(std::string filename = "conditioner.txt");
};