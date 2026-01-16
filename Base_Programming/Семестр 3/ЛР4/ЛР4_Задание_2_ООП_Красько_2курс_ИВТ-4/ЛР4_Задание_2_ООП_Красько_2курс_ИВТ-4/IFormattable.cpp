#include "IFormattable.h"
#include <iostream>

void prettyPrint(const IFormattable& object) {
    std::cout << "Форматированный вывод:\n";
    std::cout << object.format();
}