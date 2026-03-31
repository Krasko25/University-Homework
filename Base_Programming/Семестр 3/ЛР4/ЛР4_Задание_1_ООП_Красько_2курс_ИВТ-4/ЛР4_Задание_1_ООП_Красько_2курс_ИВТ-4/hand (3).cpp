#include "hand.h"

// Добавить карту в руку и проверить на перебор
void Hand::addCard(const Card& card) {
    cards.push_back(card);
    // Бросить исключение если перебор
    /*if (getTotal() > 21) {
        throw std::runtime_error("ПЕРЕБОР! Сумма карт: " + std::to_string(getTotal()));
    }*/
}

void Hand::clear() {
    cards.clear();
}

int Hand::getTotal() const {
    int total = 0;
    int aceCount = 0;

    for (const auto& card : cards) {
        if (card.isFaceUp()) {
            total += card.getValue();
            if (card.isAce()) {
                aceCount++;
            }
        }
    }

    if (cards.size() == 2 && aceCount == 2) {
        return 21;
    }

    return total;
}

int Hand::getCardCount() const {
    return cards.size();
}

Card Hand::getCard(int index) const {
    if (index >= 0 && index < static_cast<int>(cards.size())) {
        return cards[index];
    }
    throw std::out_of_range("Неверный индекс карты");
}

const std::vector<Card>& Hand::getCards() const {
    return cards;
}

bool Hand::isBust() const {
    return getTotal() > 21;
}

bool Hand::hasBlackjack() const {
    if (getCardCount() == 2) {
        if (cards[0].isAce() && cards[1].isAce()) {
            return true;
        }
        if ((cards[0].isAce() && cards[1].isTenValue()) ||
            (cards[1].isAce() && cards[0].isTenValue())) {
            return true;
        }
    }
    return false;
}

bool Hand::canSplit() const {
    if (cards.size() == 2) {
        return cards[0].getValue() == cards[1].getValue();
    }
    return false;
}

void Hand::display() const {
    for (const auto& card : cards) {
        card.display();
        std::cout << " ";
    }
}