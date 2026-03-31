#include "card.h"

Card::Card(Suit s, Rank r) : suit(s), rank(r), faceUp(true) {}

int Card::getValue() const {
    return static_cast<int>(rank);
}

Rank Card::getRank() const {
    return rank;
}

bool Card::isAce() const {
    return rank == Rank::ACE;
}

bool Card::isTenValue() const {
    return rank == Rank::TEN || rank == Rank::JACK ||
        rank == Rank::QUEEN || rank == Rank::KING;
}

void Card::flip() {
    faceUp = !faceUp;
}

bool Card::isFaceUp() const {
    return faceUp;
}

std::string Card::suitToString() const {
    switch (suit) {
    case Suit::HEARTS: return std::string(1, char(3));    // Сердце
    case Suit::DIAMONDS: return std::string(1, char(4));  // ромб
    case Suit::CLUBS: return std::string(1, char(5));     // Клевер
    case Suit::SPADES: return std::string(1, char(6));    // Пика
    default: return "?";
    }
}

std::string Card::rankToString() const {
    if (rank == Rank::ACE) return "A";
    if (rank == Rank::JACK) return "J";
    if (rank == Rank::QUEEN) return "Q";
    if (rank == Rank::KING) return "K";
    return std::to_string(getValue());
}

void Card::display() const {
    if (faceUp) {
        std::cout << rankToString() << suitToString();
    }
    else {
        std::cout << "??";
    }
}