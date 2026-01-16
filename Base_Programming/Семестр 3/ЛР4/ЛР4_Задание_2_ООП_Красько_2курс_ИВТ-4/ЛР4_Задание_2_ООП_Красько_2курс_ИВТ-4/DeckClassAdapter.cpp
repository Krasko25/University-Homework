#include "DeckClassAdapter.h"
#include <sstream>
#include <iomanip>
#include <algorithm>

// Соединить все карты в один вектор из разных колод
std::vector<Card> DeckClassAdapter::getAllCardsFlat() const {
    std::vector<Card> allCards;
    auto decks = Deck::getAllCards();

    for (int deckIdx = 0; deckIdx < getDeckCount(); deckIdx++) {
        const auto& deck = decks[deckIdx];
        int currentIndex = getRemainingAmountInDeck(deckIdx); // Нужно оставшееся количество карт т.к. в векторах колод не удаляются карты при раздачи, 
        // просто смещается начальный индекс

        for (int i = 52 - currentIndex; i < 52; i++) {
            if (i >= 0 && i < static_cast<int>(deck.size())) {
                allCards.push_back(deck[i]);
            }
        }
    }
    return allCards;
}

// Отсортировать все карты по мастям
std::vector<std::vector<Card>> DeckClassAdapter::getCardsSortedBySuit() const {
    std::vector<std::vector<Card>> suits(4);

    auto allCards = getAllCardsFlat();

    for (const auto& card : allCards) {
        std::string suitSymbol;

        int suitIndex = -1;
        switch (card.getSuit()) {
        case Suit::HEARTS:   suitIndex = 0; break;
        case Suit::DIAMONDS: suitIndex = 1; break;
        case Suit::CLUBS:    suitIndex = 2; break;
        case Suit::SPADES:   suitIndex = 3; break;
        }

        if (suitIndex != -1) {
            suits[suitIndex].push_back(card);
        }
    }

    // Сортируем карты по ценности
    for (int suitIndex = 0; suitIndex < 4; suitIndex++) {
        std::vector<Card>& currentSuit = suits[suitIndex];
        int n = currentSuit.size();

        // Пузырьковая сортировка
        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - i - 1; j++) {
                if (currentSuit[j].getRank() < currentSuit[j + 1].getRank()) {
                    Card temp = currentSuit[j];
                    currentSuit[j] = currentSuit[j + 1];
                    currentSuit[j + 1] = temp;
                }
            }
        }
    }

    return suits;
}

std::string DeckClassAdapter::format() const {
    std::ostringstream resultString;

    resultString << "\n------------------------\n";

    resultString << formatAllCardsInOrder();
    resultString << "Содержимое колоды, отсортированное по мастям\n----------------------------\n";

    resultString << formatCardsBySuit();

    return resultString.str();
}

std::string DeckClassAdapter::formatAllCardsInOrder() const {
    std::ostringstream resultString;

    auto decks = Deck::getAllCards();

    for (int deckIdx = 0; deckIdx < getDeckCount(); deckIdx++) {
        int remaining = getRemainingAmountInDeck(deckIdx);

        resultString << "Колода " << (deckIdx + 1) << ": " << remaining << "/52 карт:\n";

        if (remaining == 0) continue; // Пропускаем пустые колоды

        const auto& deck = decks[deckIdx];
        int startIndex = 52 - remaining; // Начинаем с первой неразданной карты

        for (int i = startIndex; i < 52; i++) {
            const auto& card = deck[i];
            
            resultString << card.rankToString() << card.suitToString();

            // Перенос строки для читаемости
            if ((i - startIndex + 1) % 6 == 0) {
                resultString << "\n";
            }
            else {
                resultString << " ";
            }
        }
        resultString << "\n";
    }

    return resultString.str();
}

std::string DeckClassAdapter::formatCardsBySuit() const {
    std::ostringstream resultString;

    auto suits = getCardsSortedBySuit();

    // Названия мастей
    std::vector<std::string> suitNames = {
    std::string(1, char(3)),
    std::string(1, char(4)),
    std::string(1, char(5)),
    std::string(1, char(6))
    };
     
    int totalRemaining = getRemainingCards();
    for (int i = 0; i < 4; i++) {
        // Вывод информации о том, какие масти остались в каком процентном соотношении
        int suitCount = suits[i].size();
        double percentage;
        if (totalRemaining > 0) {
            percentage = suitCount * 100.0 / totalRemaining;
        }
        else {
            percentage = 0;
        }
        resultString << suitNames[i] << ": " << suitCount << " карт ("
            << std::fixed << std::setprecision(1) << percentage << "%)\n";
    }
    resultString << "\n";

    // Максимальное количество карт в одной масти
    size_t maxCards = 0; // Необходимо для того, чтобы определить сколько строк в таблице
    for (const auto& suitCards : suits) {
        maxCards = std::max(maxCards, suitCards.size());
    }

    // Заголовки
    for (int i = 0; i < 4; i++) {
        resultString << suitNames[i] << "        ";
    }
    resultString << "\n";

    for (int i = 0; i < 4; i++) {
        resultString << "---------";
    }
    resultString << "\n";

    // 4 столбика
    for (size_t row = 0; row < maxCards; row++) {
        for (int suitIdx = 0; suitIdx < 4; suitIdx++) {
            if (row < suits[suitIdx].size()) {
                const auto& card = suits[suitIdx][row];
                std::string cardStr = card.rankToString() + card.suitToString();
                resultString << std::setw(9) << std::left << cardStr;
            }
            else {
                resultString << std::setw(9) << " ";
            }
        }
        resultString << "\n";
    }

    return resultString.str();
}