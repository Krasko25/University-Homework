#include "Card.h"

Card::Card(Suit s, Rank r) : suit(s), rank(r), faceUp(true) {
}

int Card::getValue() const {
    if (isTenValue())
        return 10;
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
        case Suit::DIAMONDS: return std::string(1, char(4));  // Ромб
        case Suit::CLUBS: return std::string(1, char(5));     // Клевер
        case Suit::SPADES: return std::string(1, char(6));    // пика
    default: return "?";
    }
}


std::string Card::rankToString() const {
    switch (rank) {
        case Rank::ACE: return "A";
        case Rank::JACK: return "J";
        case Rank::QUEEN: return "Q";
        case Rank::KING: return "K";
    default: return std::to_string(getValue());
    }
}

void Card::display() const {
    // Встроенная функция показа только тех карт, которые можно видеть игроку
    if (faceUp) {
        std::cout << rankToString() << suitToString();
    }
    else {
        std::cout << "??";
    }
}