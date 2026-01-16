#include "Deck.h"
#include <algorithm>
#include <iostream>

Deck::Deck(int numDecks) : deckCount(numDecks), nextDeckIndex(0) {
    initialize();
}

void Deck::initialize() {
    decks.clear();
    currentIndices.clear();

    // Создаем указанное количество колод
    for (int deckNum = 0; deckNum < deckCount; deckNum++) {
        std::vector<Card> deck;

        for (int suitIndex = 0; suitIndex < 4; suitIndex++) {
            Suit suit = static_cast<Suit>(suitIndex);

            for (int rankValue = 1; rankValue <= 13; rankValue++) {
                Rank rank = static_cast<Rank>(rankValue);
                deck.emplace_back(suit, rank);
            }
        }

        // Сохраняем созданную колоду
        decks.push_back(deck);
        currentIndices.push_back(0);
    }

    for (int i = 0; i < deckCount; i++) {
        shuffleDeck(i);
    }

    nextDeckIndex = 0;
}

void Deck::shuffleDeck(int deckIndex) {
    // Создаем генератор случайных чисел
    std::random_device rd;
    std::mt19937 g(rd());

    // Перемешиваем карты в указанной колоде
    std::shuffle(decks[deckIndex].begin(), decks[deckIndex].end(), g);

    currentIndices[deckIndex] = 0;
}

// Дать одну карту и перейти к следующей колоде
Card Deck::giveCard() {
    // Если текущая колода закончилась, перетасовать ее
    if (currentIndices[nextDeckIndex] >= 52) {
        shuffleDeck(nextDeckIndex);
    }

    Card card = decks[nextDeckIndex][currentIndices[nextDeckIndex]];
    currentIndices[nextDeckIndex]++;

    nextDeckIndex = (nextDeckIndex + 1) % deckCount;

    return card;
}

// Показать оставшиеся карты в каждой колоде
void Deck::displayDecksRemainingCards() const {
    std::cout << "Колоды: ";
    for (int i = 0; i < deckCount; i++) {
        int remaining = 52 - currentIndices[i];
        std::cout << "[" << remaining << "] ";
    }

    std::cout << std::endl;
}

// Получить оставшиеся карты в конкретной колоде
int Deck::getRemainingAmountInDeck(int deckIndex) const {
    if (deckIndex >= 0 && deckIndex < deckCount) {
        return 52 - currentIndices[deckIndex];
    }
    return 0;
}

// Получить все карты всех колод
std::vector<std::vector<Card>> Deck::getAllCards() const {
    return decks;
}

// Получить общее количество оставшихся карт
int Deck::getRemainingCards() const {
    int total = 0;
    for (int i = 0; i < deckCount; i++) {
        total += getRemainingAmountInDeck(i);
    }
    return total;
}