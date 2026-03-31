#include "deck.h"

Deck::Deck() {
    initialize();
}

// 4 колоды по 52 карты в каждой
void Deck::initialize() {
    decks.clear();
    currentIndices.clear();

    // Создаём 4 отдельные колоды
    for (int deckNum = 0; deckNum < 4; deckNum++) {
        std::vector<Card> deck;
        for (int s = 0; s < 4; s++) {
            for (int r = 1; r <= 13; r++) {
                deck.emplace_back(static_cast<Suit>(s), static_cast<Rank>(r));
            }
        }
        decks.push_back(deck);
        currentIndices.push_back(0);
    }

    // Перемешиваем
    for (int i = 0; i < 4; i++) {
        shuffleDeck(i);
    }

    nextDeckIndex = 0;
}

// Перемешать конкретную колоду
void Deck::shuffleDeck(int deckIndex) {
    std::random_device rd;
    std::mt19937 g(rd());
    std::shuffle(decks[deckIndex].begin(), decks[deckIndex].end(), g);
    currentIndices[deckIndex] = 0;
}

// Дать одну карту из текущей колоды и перейти к следующей колоде
Card Deck::giveCard() {
    // Если текущая колода закончилась, перетасовать ее
    if (currentIndices[nextDeckIndex] >= 52) {
        shuffleDeck(nextDeckIndex);
    }

    Card card = decks[nextDeckIndex][currentIndices[nextDeckIndex]];
    currentIndices[nextDeckIndex]++;

    // Индекс следующей колоды
    nextDeckIndex = (nextDeckIndex + 1) % 4;

    return card;
}

// Показать оставшиеся карты в каждой колоде
void Deck::displayRemainingCardsInDeck() const {
    std::cout << "Колоды: ";
    for (int i = 0; i < 4; i++) {
        int remaining = 52 - currentIndices[i];
        std::cout << "[" << remaining << "] ";
    }
    std::cout << std::endl;
}

// Получить оставшиеся карты в конкретной колоде
int Deck::getRemainingCardsInDeck(int deckIndex) const {
    if (deckIndex >= 0 && deckIndex < 4) {
        return 52 - currentIndices[deckIndex];
    }
    return 0;
}