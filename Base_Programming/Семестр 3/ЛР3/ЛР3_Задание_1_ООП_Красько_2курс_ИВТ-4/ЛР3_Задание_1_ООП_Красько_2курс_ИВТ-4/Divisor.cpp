#include "Divisor.h"
#include <iostream>
#include <algorithm>

Divisor::Divisor(size_t n) : ExpressionEvaluator(n) {}

double Divisor::calculate() {
    double result = operands[0];

    // Все остальные числа
    for (size_t i = 1; i < numOperands; i++) {
        // проверка деления на 0
        if (operands[i] == 0) {
            return 0;
        }
        result /= operands[i];
    }
    return result;
}

std::string Divisor::getExpression() {
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
            text += "\\";
        }
    }
    return text;
}

void Divisor::shuffle() {
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

void Divisor::shuffle(size_t i, size_t j) {
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