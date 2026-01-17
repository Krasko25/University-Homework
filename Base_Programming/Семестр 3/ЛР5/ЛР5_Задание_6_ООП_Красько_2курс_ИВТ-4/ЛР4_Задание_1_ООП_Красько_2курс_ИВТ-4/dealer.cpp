#include "dealer.h"

Dealer::Dealer() : Participant() {}

void Dealer::displayHand(bool showAll) const {
    
    if (!hands.empty()) {
        if (showAll) {
            hands[0].display();
        }
        else {
            if (hands[0].getCardAmount() > 0) {
                hands[0].getCard(0).display();
                std::cout << " ??";
            }
        }
    }
}

bool Dealer::shouldHit() const {
    int total = hands[0].getTotal();
    bool result = total < 17;
    return result;
}

int Dealer::getVisibleCardValue() const {
    if (hands.empty()) {
        return 0;
    }

    // Проверяем, есть ли карты в первой руке
    if (hands[0].getCardAmount() == 0) {
        return 0;
    }

    // Получаем видимую карту диллера
    Card firstCard = hands[0].getCard(0);

    return firstCard.getValue();
}