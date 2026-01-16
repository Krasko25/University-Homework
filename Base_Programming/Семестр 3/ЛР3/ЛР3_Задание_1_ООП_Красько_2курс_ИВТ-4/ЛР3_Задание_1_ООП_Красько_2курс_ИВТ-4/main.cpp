#include "Divisor.h"
#include "Multiplier.h"
#include "CustomExpressionEvaluator.h"
#include <iostream>


int main() {
    setlocale(LC_ALL, "Russian");

    // Массив указателей
    ExpressionEvaluator* evaluators[3];

    // Divisor
    Divisor* div = new Divisor(4);
    
    // Поэлементно
    div->setOperand(0, 150);
    div->setOperand(1, -3);
    div->setOperand(2, 10);
    div->setOperand(3, -2.5);
    evaluators[0] = div;

    // CustomExpressionEvaluator
    CustomExpressionEvaluator* custom = new CustomExpressionEvaluator(5);
    
    // Групповое присваивание
    double customOps[] = { 5, 16, -3, 10, 12 };
    custom->setOperands(customOps, 5);
    evaluators[1] = custom;

    // Multiplier
    Multiplier* mult = new Multiplier(5);
    double multOps[] = { 1.5, 4, -2.5, -8, -15 };
    mult->setOperands(multOps, 5);
    evaluators[2] = mult;

    // Логирование
    std::cout << "Логирование\n------------------------" << std::endl;
    for (int i = 0; i < 3; i++) {
        evaluators[i]->logToScreen();
        evaluators[i]->logToFile("log.txt");
        std::cout << std::endl;
    }

    std::cout << "Перемешивание\n-------------------------------------" << std::endl;
    for (int i = 0; i < 3; i++) {
    IShuffle* shuffleable = dynamic_cast<IShuffle*>(evaluators[i]);
    
    if (shuffleable) {

        // заранее всё перемешиваем
        if (i == 0) {
            shuffleable->shuffle();  // для деления
        }
        else if (i == 1) {
            shuffleable->shuffle(0, 1);  // для сложения произведений
        }
        else if (i == 2) {
            shuffleable->shuffle(0, 2);  // для умноженя
        }
        
        // Вывод
        std::cout << evaluators[i]->getExpression() 
                  << " < Total " << evaluators[i]->getNumOperands() << " >" << std::endl;
        std::cout << "< Result " << evaluators[i]->calculate() << " >" << std::endl;
        std::cout << std::endl;
        evaluators[i]->logToFile("log.txt");
    }
}

    delete div;
    delete custom;
    delete mult;

    return 0;
}