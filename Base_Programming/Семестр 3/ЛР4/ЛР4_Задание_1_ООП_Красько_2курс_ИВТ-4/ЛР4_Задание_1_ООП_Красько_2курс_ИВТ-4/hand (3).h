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
    void addCard(const Card& card);
    void clear();
    int getTotal() const;
    int getCardCount() const;
    Card getCard(int index) const;
    const std::vector<Card>& getCards() const;
    bool isBust() const;
    bool hasBlackjack() const;
    bool canSplit() const;
    void display() const;
};

#endif