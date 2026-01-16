#pragma once
#include "ILoggable.h"
#include <string>
#include <fstream>

class ExpressionEvaluator : public ILoggable {
protected:
    size_t numOperands; // Количество операндов
    double* operands;  // Массив операторов

public:
    ExpressionEvaluator();
    ExpressionEvaluator(size_t n);
    virtual ~ExpressionEvaluator();

    // Присвоить значение одному операнду на позиции pos
    void setOperand(size_t pos, double value);

    // Присвоить значения группе операндов
    void setOperands(double ops[], size_t n);

    virtual double calculate() = 0;
    void logToScreen() override;
    void logToFile(const std::string& filename) override;

    virtual std::string getExpression() = 0;

    size_t getNumOperands() const { return numOperands; }
};