#include "hand.h"

// Добавить карту в руку и проверить на перебор
void Hand::addCard(const Card& card) {
    cards.push_back(card);
    // Исключение если перебор
    if (getTotal() > 21) {
        throw std::runtime_error("ПЕРЕБОР! Сумма карт: " + std::to_string(getTotal()));
    }
}

void Hand::clear() {
    cards.clear();
}


int Hand::getTotal() const {
    int total = 0;
    int aceCount = 0;

    std::for_each(cards.begin(), cards.end(), [&](const Card& card) {
        if (card.isFaceUp()) {
            total += card.getValue();
            if (card.isAce()) {
                aceCount++;
            }
        }
        });

    if (cards.size() == 2 && aceCount == 2) {
        return 21;
    }

    return total;
}

int Hand::getCardAmount() const {
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
    if (getTotal() == 21)
        return true;
    return false;
}

bool Hand::canSplit() const {
    if (cards.size() == 2) {
        return cards[0].getRank() == cards[1].getRank();
    }
    return false; // на случай, если карт не 2
}

void Hand::display() const {
    // Тут можно и через цикл проще, но для задания использую for_each
    std::for_each(cards.begin(), cards.end(), [](const Card& card) {
        card.display();
        std::cout << " ";
    });
}