#ifndef DECK_H
#define DECK_H

#include "Card.h"
#include <vector>
#include <random>
#include <ctime>

class Deck {
private:
    std::vector<std::vector<Card>> decks;
    std::vector<int> currentIndices; // Позиция в каждой колоде
    int nextDeckIndex;  // Следующая карта для каждой колоды
    int deckCount; // Количество колод. Я добавил возможность выбирать число колод, 
    // чтобы вывод всех карт не был громоздким

public:
    Deck(int numDecks = 4);
    void initialize();
    Card giveCard();
    void shuffleDeck(int deckIndex); // shuffle - перемешать
    void displayDecksRemainingCards() const; // отобразить оставшиеся карты в каждой колоде
    int getRemainingAmountInDeck(int deckIndex) const; // Оставшееся колво карт в конкретной колод

    // Геттеры для адаптеров
    int getDeckCount() const { return deckCount; }
    int getTotalCards() const { return deckCount * 52; }
    int getRemainingCards() const;

    // Новый метод для адаптеров
    std::vector<std::vector<Card>> getAllCards() const; // Получить все карты всех колод
};

#endif