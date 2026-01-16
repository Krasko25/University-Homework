#include "participant.h"

Participant::Participant() : currentHandIndex(0) {
    hands.emplace_back(); // добавляет новый объект Hand в конец вектора
}

void Participant::addCard(const Card& card) {
    hands[currentHandIndex].addCard(card);
}

Hand& Participant::getCurrentHand() {
    return hands[currentHandIndex];
}

// для безопасности и совместимости 2 метода, константный и не константный
std::vector<Hand>& Participant::getHands() {
    return hands;
}

const std::vector<Hand>& Participant::getHands() const {
    return hands;
}

void Participant::clearHands() {
    
    hands.clear();
    hands.emplace_back();
    currentHandIndex = 0;
}

bool Participant::isBust() const {
    return hands[currentHandIndex].isBust();
}

void Participant::displayHand(bool showAll) const {
    hands[currentHandIndex].display();
}