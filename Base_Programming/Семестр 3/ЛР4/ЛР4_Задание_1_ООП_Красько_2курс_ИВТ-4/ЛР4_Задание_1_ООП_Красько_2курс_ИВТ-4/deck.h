#ifndef DECK_H
#define DECK_H

#include "card.h"
#include <vector>
#include <random>
#include <ctime>

class Deck {
private:
    std::vector<std::vector<Card>> decks;  // дл€ отдельных колод
    std::vector<int> currentIndices;       // “екуща€ позици€ в каждой колоде
    int nextDeckIndex;                     // —ледующа€ карта дл€ каждой колоды

public:
    Deck();
    void initialize();
    Card giveCard();
    void shuffleDeck(int deckIndex); // shuffle - перемешать
    void displayDecksRemainingCards() const; // отобразить оставшиес€ карты в каждой колоде
    int getRemainingAmountInDeck(int deckIndex) const; // ќставшеес€ колво карт в конкретной колоде
};

#endif