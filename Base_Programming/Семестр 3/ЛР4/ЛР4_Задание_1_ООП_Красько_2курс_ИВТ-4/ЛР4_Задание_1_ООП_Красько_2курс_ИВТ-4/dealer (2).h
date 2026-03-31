#ifndef DEALER_H
#define DEALER_H

#include "hand.h"

class Dealer {
private:
    Hand hand;
    Card hiddenCard;
    bool hasHiddenCard;

public:
    Dealer();

    void reset();
    void takeCard(Card card, bool isHidden = false);
    void revealCard();

    Hand& getHand();
    const Hand& getHand() const;

    void display(bool showAll = false) const;
};

#endif