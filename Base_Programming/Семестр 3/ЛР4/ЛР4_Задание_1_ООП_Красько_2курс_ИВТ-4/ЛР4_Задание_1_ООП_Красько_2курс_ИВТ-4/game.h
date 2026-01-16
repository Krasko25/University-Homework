#ifndef GAME_H
#define GAME_H

#include "deck.h"
#include "player.h"
#include "dealer.h"
#include <memory>

class Game {
private:
    Deck deck;
    std::unique_ptr<Player> player; // unique_ptr для автоматического освобождения памяти
    std::unique_ptr<Dealer> dealer;
    bool gameOver;

    void betResults();
    std::string getHint();
    void playPlayerHand();
    void playDealerHand();

public:
    Game();
    void initialize();
    void playRound();
    void run(); // Нужно, чтобы все этапы игры были в классе, а не часть в main
    void printCards();
};

#endif