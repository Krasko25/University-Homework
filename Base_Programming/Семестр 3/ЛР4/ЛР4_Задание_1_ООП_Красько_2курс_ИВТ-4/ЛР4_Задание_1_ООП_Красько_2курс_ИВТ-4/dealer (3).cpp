#include "dealer.h"

Dealer::Dealer() : Participant() {}

void Dealer::displayHand(bool showAll) const {
    if (!hands.empty()) {
        if (showAll) {
            hands[0].display();
        }
        else {
            if (hands[0].getCardCount() > 0) {
                hands[0].getCard(0).display();
                std::cout << " ??";
            }
        }
    }
}

bool Dealer::shouldTake() const {
    int total = hands[0].getTotal();
    return total < 17;
}

// Выдаёт стоимость открытой карты дилера для того, чтобы создать на основе этой информации подсказку
int Dealer::getVisibleCardValue() const {
    if (!hands.empty() && hands[0].getCardCount() > 0) {
        return hands[0].getCard(0).getValue();
    }
    return 0;
}