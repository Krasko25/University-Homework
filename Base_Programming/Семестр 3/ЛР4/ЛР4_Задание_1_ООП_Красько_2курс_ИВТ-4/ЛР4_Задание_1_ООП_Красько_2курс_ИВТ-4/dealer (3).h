#ifndef DEALER_H
#define DEALER_H

#include "participant.h"

class Dealer : public Participant {
public:
    Dealer();
    void displayHand(bool showAll = false) const override;
    bool shouldTake() const; // Стоит ли дилеру брать больше карт
    int getVisibleCardValue() const; // Нужно для создания подсказок так как подсказки делаются только на основе открытых карт
};

#endif