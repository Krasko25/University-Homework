#include "card.h"
#include <string>

Card::Card() {
    rank = 0;
    suit = 0;
}

Card::Card(int r, int s) {
    if (r < 2 || r > 14) throw std::invalid_argument("Неверный ранг карты");
    if (s < 1 || s > 4) throw std::invalid_argument("Неверная масть");
    rank = r;
    suit = s;
}

int Card::getRank() const {
    return rank;
}

int Card::getSuit() const {
    return suit;
}

int Card::getValue() const {
    if (rank >= 2 && rank <= 10) {
        return rank;
    }
    else if (rank >= 11 && rank <= 13) {
        return 10;
    }
    else if (rank == 14) {
        return 11;
    }
    return 0;
}

// Перегрузка оператора вывода в формате 2♠, Q♦
std::ostream& operator<<(std::ostream& os, const Card& card) {
    // Достоинство
    if (card.rank >= 2 && card.rank <= 10) {
        os << card.rank;
    }
    else {
        switch (card.rank) {
        case 11: os << "J"; break;  // Валет
        case 12: os << "Q"; break;  // Дама
        case 13: os << "K"; break;  // Король
        case 14: os << "A"; break;  // Туз
        default: os << "?";
        }
    }

    // Масть (символы UNICODE как в задании)
    switch (card.suit) {
    case 1: os << "\u2665"; break;   // ♥ (черви)
    case 2: os << "\u2666"; break;   // ♦ (бубны)
    case 3: os << "\u2663"; break;   // ♣ (трефы)
    case 4: os << "\u2660"; break;   // ♠ (пики)
    default: os << "?";
    }

    return os;
}