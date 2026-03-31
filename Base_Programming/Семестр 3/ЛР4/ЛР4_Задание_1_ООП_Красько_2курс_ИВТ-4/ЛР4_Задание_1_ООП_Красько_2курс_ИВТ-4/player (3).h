#ifndef PLAYER_H
#define PLAYER_H

#include "participant.h"
#include <string>
#include <vector>

class Player : public Participant {
private:
    std::string name;
    int money;
    std::vector<int> bets;
    bool hasSplit;
    std::vector<bool> handDone;
    std::vector<bool> handStand;

public:
    Player(std::string n);
    bool placeBet(int amount, int handIndex = 0);
    bool split();
    bool canSplit() const;
    bool hasCurrentHandStood() const;
    void standCurrentHand();
    void markCurrentHandDone();
    bool getNextHandToPlay();
    void resetToFirstHand();
    bool allHandsDone() const;
    void resetRound();
    void win(int amount, int handIndex = 0);
    void lose(int handIndex = 0);
    void push(int handIndex = 0);

    // Методы получения данных
    std::string getName() const;
    int getMoney() const;
    int getCurrentBet() const;
    bool getHasSplit() const;
    int getCurrentHandIndex() const;
    int getTotalHands() const;
    void displayHands() const;
};

#endif