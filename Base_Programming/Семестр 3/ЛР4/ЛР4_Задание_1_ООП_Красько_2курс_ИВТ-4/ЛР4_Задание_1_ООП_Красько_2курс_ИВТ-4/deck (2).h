#ifndef DECK_H
#define DECK_H

#include "card.h"
#include <vector>
#include <random>
#include <ctime>

class Deck {
private:
    std::vector<std::vector<Card>> decks;  // 4 отдельные колоды
    std::vector<int> currentIndices;       // Текущая позиция в каждой колоде
    int nextDeckIndex;                     // Индекс колоды, из которой нужно брать следующую карту

public:
    Deck();
    void initialize();
    void shuffleDeck(int deckIndex); // Перемешать колоду
    Card giveCard();
    void displayRemainingCardsInDeck() const; // Показать оставшиеся в колодах карты
    int getRemainingCardsInDeck(int deckIndex) const; // Узнать, сколько в конкретной колоде карт осталось
};

#endif