#ifndef PARTICIPANT_H
#define PARTICIPANT_H

#include "hand.h"
#include <vector>

// из этого класса наследуются диллер и игрок
class Participant {
protected:
    std::vector<Hand> hands;
    int currentHandIndex;

public:
    Participant();
    virtual void addCard(const Card& card);
    Hand& getCurrentHand();
    std::vector<Hand>& getHands();
    const std::vector<Hand>& getHands() const;
    void clearHands();
    bool isBust() const;
    virtual void displayHand(bool showAll = true) const;
    virtual ~Participant() = default;
};

#endif