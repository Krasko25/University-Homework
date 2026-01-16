#pragma once
#include "ExpressionEvaluator.h"
#include "IShuffle.h"

#include "additionalFunctions.h"

class Multiplier : public ExpressionEvaluator, public IShuffle {
public:
    Multiplier(size_t n);
    double calculate() override;
    std::string getExpression() override;

    void shuffle() override;
    void shuffle(size_t i, size_t j) override;
};