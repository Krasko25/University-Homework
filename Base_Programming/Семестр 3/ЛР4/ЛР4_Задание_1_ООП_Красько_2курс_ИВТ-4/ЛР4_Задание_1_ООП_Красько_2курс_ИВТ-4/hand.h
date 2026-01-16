#ifndef HAND_H
#define HAND_H

#include "card.h"
#include <vector>
#include <stdexcept>

class Hand {
private:
    std::vector<Card> cards;

public:
    Hand() = default;
    void addCard(const Card& card); // Добавить карту в руку
    void clear(); // Убрать карты из руки
    int getTotal() const; // Общая стоимость руки

    Card getCard(int index) const; // Вернуть карту из руки под определённым индексом
    int getCardAmount() const;
    const std::vector<Card>& getCards() const;  // Все карты руки
    bool isBust() const; // Был ли привышен лимит в 21 очко
    bool hasBlackjack() const;
    bool canSplit() const;
    void display() const;
};

#endif