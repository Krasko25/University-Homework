#ifndef CARD_H
#define CARD_H

#include <string>
#include <iostream>

// Suit - масть
enum class Suit { HEARTS, DIAMONDS, CLUBS, SPADES };

// Ценность карт в варианте 17+4
// Ace - туз
enum class Rank {
    ACE = 11, TWO = 2, THREE = 3, FOUR = 4, FIVE = 5, SIX = 6, SEVEN = 7,
    EIGHT = 8, NINE = 9, TEN = 10, JACK = 10, QUEEN = 10, KING = 10
};

class Card {
private:
    Suit suit;
    Rank rank;
    bool faceUp; // Раскрыта ли карта

public:
    Card(Suit s, Rank r);
    int getValue() const;
    Rank getRank() const;
    bool isAce() const; // Нужно т.к. 2 туза - это Блэк джек
    bool isTenValue() const;
    void flip(); // раскрыть карту дилера для игрока
    bool isFaceUp() const; 
    std::string suitToString() const;
    std::string rankToString() const;
    void display() const;
};

#endif