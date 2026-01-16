#ifndef DECKCLASSADAPTER_H
#define DECKCLASSADAPTER_H

#include "Deck.h"
#include "IFormattable.h"

// Наследует Deck и IFormatable
class DeckClassAdapter : public Deck, public IFormattable {
public:
    DeckClassAdapter(int numDecks = 1) : Deck(numDecks) {}
    std::string format() const override;

private:
    std::string formatAllCardsInOrder() const; // Выводит все карты в консоль в том порядке, в котором они были в колоде
    std::string formatCardsBySuit() const; // Выводит карты, отсортированные через getCardsSortedbySuit в консоль

    std::vector<Card> getAllCardsFlat() const; // Превращает двухмерный вектор в одномерный для удобства работы
    std::vector<std::vector<Card>> getCardsSortedBySuit() const; // Сортирует карты по масти
};

#endif