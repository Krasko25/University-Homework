#ifndef CARD_H
#define CARD_H

#include <string>
#include <iostream>

// Suit - масть
enum class Suit { HEARTS, DIAMONDS, CLUBS, SPADES };

// Ace - туз
enum class Rank {
    ACE = 11, TWO = 2, THREE = 3, FOUR = 4, FIVE = 5, SIX = 6, SEVEN = 7,
    EIGHT = 8, NINE = 9, TEN = 10, JACK = 12, QUEEN = 13, KING = 14
};

class Card {
private:
    Suit suit;
    Rank rank;
    bool faceUp; // Ќужно дл€ определени€, какие карты диллера показывать, а какие нет

public:
    Card(Suit s, Rank r);
    int getValue() const; 
    Rank getRank() const;
    bool isAce() const; 
    bool isTenValue() const;
    void flip(); // ѕоказать карту диллера
    bool isFaceUp() const; // ѕоказано ли содержание карты. Ќужно дл€ подсказок т.к. они делаютс€ только на основе той информации, 
    // котора€ есть у пользовател€
    std::string suitToString() const;
    std::string rankToString() const;
    void display() const;
};

#endif