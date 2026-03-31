#ifndef GAME_H
#define GAME_H

#include <string>
#include "deck.h"
#include "dealer.h"
#include "player.h"

class Game {
private:
    Deck deck;
    Dealer dealer;
    Player player;
    bool hintsEnabled;

public:
    Game(std::string playerName, int startMoney, bool hints);

    void startNewRound();
    void playerTurn();
    void dealerTurn();

    void play();

    std::string getHint() const;
    bool canSplit() const;

    void displayGameState(bool showDealerCard = false) const;

private:
    void processHandTurn(Hand& hand);
    void processSplit();
    void calculateResults();
};

#endif