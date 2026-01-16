#ifndef IFORMATTABLE_H
#define IFORMATTABLE_H

#include <string>

class IFormattable {
public:
    virtual ~IFormattable() = default; // сначала деструкторы производных классов, а после этот
    virtual std::string format() const = 0; // метод нельзя создать напрямую
};

void prettyPrint(const IFormattable& object);

#endif