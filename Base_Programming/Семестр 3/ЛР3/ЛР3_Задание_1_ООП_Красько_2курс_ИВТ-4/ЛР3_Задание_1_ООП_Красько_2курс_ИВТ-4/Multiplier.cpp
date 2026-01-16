#include "Multiplier.h"
#include <iostream>
#include <algorithm>
#include <cmath>

Multiplier::Multiplier(size_t n) : ExpressionEvaluator(n) {}

double Multiplier::calculate() {
    double result = 1.0;
    for (size_t i = 0; i < numOperands; i++) {
        result *= operands[i];
    }
    return result;
}

std::string Multiplier::getExpression() {
    std::string text;
    for (size_t i = 0; i < numOperands; i++) {
        
        std::string nStr = doubleToString(operands[i]);
        
        // Отрицательные числа берём в скобки
        if (operands[i] < 0) {
            text += "(" + nStr + ")";
        }
        else {
            text += nStr;
        }

        // Ставим * перед всеми числами, кроме последнего
        if (i < numOperands - 1) {
            text += "*";
        }
    }
    return text;
}

void Multiplier::shuffle() {
    // Пузырьковая сортировка
    for (int i = 0; i < numOperands; i++) {
        for (int j = 0; j < numOperands - 1; j++) {
            if (operands[j] > operands[j + 1]) {
                double temp = operands[j];
                operands[j] = operands[j + 1];
                operands[j + 1] = temp;
            }
        }
    }
}

void Multiplier::shuffle(size_t i, size_t j) {
    // Проверяем, находятся ли i и j в рамках массива операндов
    if (i >= 0 && i < numOperands && j >= 0 && j < numOperands) {

        // если есть дробная часть, то меняем местами
        if ((operands[i] != (int)operands[i]) || (operands[j] != (int)operands[j])) {
            double temp = operands[i];
            operands[i] = operands[j];
            operands[j] = temp;
        }
    }
}