#include "deck.h"

Deck::Deck() {
    initialize();
}

void Deck::initialize() {
    decks.clear();
    currentIndices.clear();

    // Создаем 4 отдельные колоды
    for (int deckNum = 0; deckNum < 4; deckNum++) {
        std::vector<Card> deck;

        for (int suitIndex = 0; suitIndex < 4; suitIndex++) {
            Suit suit = static_cast<Suit>(suitIndex);

            for (int rankValue = 1; rankValue <= 13; rankValue++) {
                Rank rank;
                //if ((rankValue == 11) || (rankValue == 12) || (rankValue == 13)) {
                //    rank = static_cast<Rank>(10);
                //}
                //else {
                    rank = static_cast<Rank>(rankValue);
                //}

                deck.emplace_back(suit, rank);
            }
        }

        // Сохраняем созданную колоду
        decks.push_back(deck);
        currentIndices.push_back(0);
    }

    for (int i = 0; i < 4; i++) {
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

    nextDeckIndex = (nextDeckIndex + 1) % 4;

    return card;
}

// Показать оставшиеся карты в каждой колоде
void Deck::displayDecksRemainingCards() const {
    std::cout << "Колоды: ";
    for (int i = 0; i < 4; i++) {
        int remaining = 52 - currentIndices[i];
        std::cout << "[" << remaining << "] ";
    }

    std::cout << std::endl;
}


// Получить оставшиеся карты в конкретной колоде
int Deck::getRemainingAmountInDeck(int deckIndex) const {
    if (deckIndex >= 0 && deckIndex < 4) {
        return 52 - currentIndices[deckIndex];
    }
    return 0;
}
