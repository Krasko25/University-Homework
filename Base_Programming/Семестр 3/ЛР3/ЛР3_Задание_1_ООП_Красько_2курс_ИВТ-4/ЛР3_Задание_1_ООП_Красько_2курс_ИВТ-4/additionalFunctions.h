#ifndef ADDITIONALFUNCTIONS_H
#define ADDITIONALFUNCTIONS_H

#include <string>

#include <sstream> // для удаление лишних нулей при переводе дробного числа в строку

// для удаление лишних нулей при переводе дробного числа в строку
static std::string doubleToString(double value) {
    std::stringstream ss;
    ss << value;
    return ss.str();
}

#endif