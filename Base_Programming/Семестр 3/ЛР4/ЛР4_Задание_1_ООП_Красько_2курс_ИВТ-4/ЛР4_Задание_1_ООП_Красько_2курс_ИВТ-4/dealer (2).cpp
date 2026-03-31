#include "dealer.h"
#include <iostream>

Dealer::Dealer() : hasHiddenCard(false) {
}

void Dealer::reset() {
    hand.clear();
    hasHiddenCard = false;
}

void Dealer::takeCard(Card card, bool isHidden) {
    if (isHidden) {
        hiddenCard = card;
        hasHiddenCard = true;
    }
    else {
        hand.addCard(card);
    }
}

void Dealer::revealCard() {
    if (hasHiddenCard) {
        hand.addCard(hiddenCard);
        hasHiddenCard = false;
    }
}

Hand& Dealer::getHand() {
    return hand;
}

const Hand& Dealer::getHand() const {
    return hand;
}

void Dealer::display(bool showAll) const {
    std::cout << "Карты дилера: ";

    if (showAll || !hasHiddenCard) {
        auto cards = hand.getCards();
        for (const Card& card : cards) {
            std::cout << card << " ";
        }
        std::cout << "(" << hand.getValue() << " оч.)";

        if (hand.isBlackjack()) {
            std::cout << " [Блэкджек!]";
        }
        else if (hand.isBust()) {
            std::cout << " [Перебор!]";
        }
    }
    else {
        // Показываем только первую карту
        auto cards = hand.getCards();
        if (!cards.empty()) {
            std::cout << cards[0] << " ?? ";
        }
        else if (hasHiddenCard) {
            std::cout << "?? ?? ";
        }
        std::cout << "(?? оч.)";
    }
    std::cout << std::endl;
}