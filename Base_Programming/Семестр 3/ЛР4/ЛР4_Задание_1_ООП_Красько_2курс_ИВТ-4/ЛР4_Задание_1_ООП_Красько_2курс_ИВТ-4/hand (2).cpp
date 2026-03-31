#include "hand.h"
#include <iostream>

Hand::Hand() {
    bet = 0;
}

void Hand::addCard(Card card) {
    cards.push_back(card);

    // Бросаем исключение при переборе
    if (isBust()) {
        throw BustException();
    }
}

void Hand::clear() {
    cards.clear();
    bet = 0;
}

int Hand::getValue() const {
    int value = 0;
    int aceCount = 0;

    for (const Card& card : cards) {
        int cardValue = card.getValue();
        if (card.getRank() == 14) {
            aceCount++;
        }
        value += cardValue;
    }

    // Корректировка для тузов
    while (value > 21 && aceCount > 0) {
        value -= 10;
        aceCount--;
    }

    return value;
}

int Hand::getCardCount() const {
    return cards.size();
}

std::vector<Card> Hand::getCards() const {
    return cards;
}

void Hand::setBet(int b) {
    bet = b;
}

int Hand::getBet() const {
    return bet;
}

bool Hand::isBlackjack() const {
    return (cards.size() == 2 && getValue() == 21);
}

bool Hand::canSplit() const {
    if (cards.size() == 2) {
        // Карты одинакового достоинства
        if (cards[0].getRank() == cards[1].getRank()) {
            return true;
        }
        // Лицевые карты (10, J, Q, K) также можно сплитовать
        if (cards[0].getValue() == 10 && cards[1].getValue() == 10) {
            return true;
        }
    }
    return false;
}

bool Hand::isBust() const {
    return getValue() > 21;
}

bool Hand::isSoft17() const {
    int value = 0;
    int aceCount = 0;

    for (const Card& card : cards) {
        if (card.getRank() == 14) {
            aceCount++;
        }
        value += card.getValue();
    }

    // Это мягкие 17, если есть туз и его можно считать как 1 без перебора
    return (value == 17 && aceCount > 0 && (value - 10) <= 7);
}

void Hand::display() const {
    for (const Card& card : cards) {
        std::cout << card << " ";
    }
    std::cout << "(" << getValue() << " оч.)";

    if (isBlackjack()) {
        std::cout << " [Блэкджек!]";
    }
    else if (isBust()) {
        std::cout << " [Перебор!]";
    }
    else if (getValue() == 21) {
        std::cout << " [21!]";
    }
}