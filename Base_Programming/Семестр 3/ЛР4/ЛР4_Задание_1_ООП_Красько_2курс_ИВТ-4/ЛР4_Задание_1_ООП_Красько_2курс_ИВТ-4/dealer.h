#ifndef DEALER_H
#define DEALER_H

#include "participant.h"


// Player и Dealer наследуют у Participante
class Dealer : public Participant {
public:
    Dealer();
    void displayHand(bool showAll = false) const override;
    bool shouldHit() const; // Нужно для подсказок
    int getVisibleCardValue() const; // Тоже нужно для подсказок, так как они будут на основе только видимых карт диллера
};

#endif