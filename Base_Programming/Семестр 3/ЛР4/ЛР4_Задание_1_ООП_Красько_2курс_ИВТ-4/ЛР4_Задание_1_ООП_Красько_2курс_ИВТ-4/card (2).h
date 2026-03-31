#ifndef CARD_H
#define CARD_H

#include <iostream>
#include <string>
#include <stdexcept>

class Card {
private:
    int rank;
    int suit;

public:
    Card();
    Card(int r, int s);

    int getRank() const;
    int getSuit() const;
    int getValue() const;

    friend std::ostream& operator<<(std::ostream& os, const Card& card);
};

#endif