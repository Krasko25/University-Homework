#ifndef DECKOBJECTADAPTER_H
#define DECKOBJECTADAPTER_H

#include "Deck.h"
#include "IFormattable.h"

class DeckObjectAdapter : public IFormattable {
private:
    const Deck& deck;

public:
    explicit DeckObjectAdapter(const Deck& d) : deck(d) {} // Защита от неявного преобразования
    std::string format() const override;

private:
    std::string formatAllCardsInOrder() const;
    std::string formatCardsBySuit() const;

    std::vector<Card> getAllCardsFlat() const;
    std::vector<std::vector<Card>> getCardsSortedBySuit() const;
};

#endif