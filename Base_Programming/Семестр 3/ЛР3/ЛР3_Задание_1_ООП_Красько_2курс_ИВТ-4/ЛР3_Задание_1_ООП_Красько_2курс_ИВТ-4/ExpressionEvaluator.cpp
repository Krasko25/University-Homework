#include "ExpressionEvaluator.h"
#include <iostream>
#include <fstream>

// ѕо умолчанию количество операндов ставим 20
ExpressionEvaluator::ExpressionEvaluator() {
    numOperands = 20;
    operands = new double[20];
    for (size_t i = 0; i < 20; i++) {
        operands[i] = 0;
    }
}

ExpressionEvaluator::ExpressionEvaluator(size_t n) {
    numOperands = n;
    operands = new double[n];
    for (size_t i = 0; i < n; i++) {
        operands[i] = 0;
    }
}


ExpressionEvaluator::~ExpressionEvaluator() {
    delete[] operands;
}


void ExpressionEvaluator::setOperand(size_t pos, double value) {
    operands[pos] = value;
}

void ExpressionEvaluator::setOperands(double ops[], size_t n) {
    for (int i = 0; i < n; i++) {
        operands[i] = ops[i];
    }
}

void ExpressionEvaluator::logToScreen() {
    std::cout << getExpression() << std::endl;
    // ¬ывод в консоль на английском, потому что так по заданию
    std::cout << "Result: " << calculate() << std::endl;
}

void ExpressionEvaluator::logToFile(const std::string& filename) {
    std::ofstream file(filename, std::ios::app);
    if (file.is_open()) {
        file << getExpression() << std::endl;
        file << "Result: " << calculate() << std::endl;
        file.close();
    }
}