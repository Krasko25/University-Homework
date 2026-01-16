#ifndef PLAYER_H
#define PLAYER_H

#include "participant.h"
#include <string>
#include <vector>

class Player : public Participant {
private:
    std::string name;
    int money;
    std::vector<int> bets; // может быть несколько ставок на несколько рук
    bool hasSplit; // был ли сплит
    std::vector<bool> handDone;
    std::vector<bool> handStand;

public:
    Player(std::string n);
    bool placeBet(int amount, int handIndex = 0);
    bool split();
    bool canSplit() const;
    bool hasCurrentHandStood() const; // Ѕыла ли остановлена текуща€ рука
    void standCurrentHand(); // ќстановить текущую руку, больше карт не брать
    void markCurrentHandDone(); // «авершить партию дл€ 
    void resetToFirstHand(); // выбрать первую руку
    bool allHandsDone() const; // «авершить партию дл€ всех рук
    void resetRound();
    void win(int amount, int handIndex = 0);
    void lose(int handIndex = 0);
    void draw(int handIndex = 0);
    bool getNextHandToPlay();

    // ћетоды получени€ данных
    std::string getName() const;
    int getMoney() const;
    int getCurrentBet() const;
    bool getHasSplit() const;
    int getCurrentHandIndex() const;
    int getTotalHands() const;
    void displayHands() const;
    int getBetForHand(int handIndex) const;
};

#endif