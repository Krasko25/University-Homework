#pragma once
#include <string>

// Нельзя создать этот класс напрямую, только через наследников
class ILoggable {
public:
    virtual void logToScreen() = 0;
    virtual void logToFile(const std::string& filename) = 0;
    virtual ~ILoggable() {}
};