#include "CustomExpressionEvaluator.h"
#include <iostream>
#include <algorithm>
#include <cmath>

CustomExpressionEvaluator::CustomExpressionEvaluator(size_t n) : ExpressionEvaluator(n) {}

double CustomExpressionEvaluator::calculate() {
    double result = operands[0];

    for (int i = 1; i < numOperands; i++) {
        if (i % 2 == 1) {  // Если нечетный индекс
            if (i + 1 < numOperands) {
                result += operands[i] * operands[i + 1];
            }
            else {
                result += operands[i];
            }
        }
    }

    return result;
}

std::string CustomExpressionEvaluator::getExpression() {
    std::string text;

    // Первое число
    std::string firstN = doubleToString(operands[0]);
    // Проверяем, отрицательное ли число
    if (operands[0] < 0) {
        text = "(" + firstN + ")";
    }
    else {
        text = firstN;
    }

    // Остальные числа
    for (size_t i = 1; i < numOperands; i += 2) {
        text += " + ";

        std::string nStr = doubleToString(operands[i]);
        if (operands[i] < 0) {
            text += "(" + nStr + ")";
        }
        else {
            text += nStr;
        }

        if (i + 1 < numOperands) {
            text += "*";

            std::string nextNStr = doubleToString(operands[i + 1]);
            if (operands[i + 1] < 0) {
                text += "(" + nextNStr + ")";
            }
            else {
                text += nextNStr;
            }
        }
    }

    return text;
}

void CustomExpressionEvaluator::shuffle() {
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

void CustomExpressionEvaluator::shuffle(size_t i, size_t j) {
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