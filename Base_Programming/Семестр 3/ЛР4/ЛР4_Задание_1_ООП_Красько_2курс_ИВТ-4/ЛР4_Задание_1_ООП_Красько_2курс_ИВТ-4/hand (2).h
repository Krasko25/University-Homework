#ifndef HAND_H
#define HAND_H

#include <vector>
#include <stdexcept>
#include "card.h"

class BustException : public std::runtime_error {
public:
    BustException() : std::runtime_error("Перебор! Сумма очков превысила 21") {}
};

class Hand {
private:
    std::vector<Card> cards;
    int bet;

public:
    Hand();

    void addCard(Card card);
    void clear();

    int getValue() const;
    int getCardCount() const;
    std::vector<Card> getCards() const;

    void setBet(int b);
    int getBet() const;

    bool isBlackjack() const;
    bool canSplit() const;
    bool isBust() const;
    bool isSoft17() const;

    void display() const;
};

#endif