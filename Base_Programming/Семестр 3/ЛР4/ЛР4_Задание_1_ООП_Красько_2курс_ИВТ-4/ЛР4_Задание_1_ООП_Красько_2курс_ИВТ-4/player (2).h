#ifndef PLAYER_H
#define PLAYER_H

#include <string>
#include <vector>
#include "hand.h"

class Player {
private:
    std::string name;
    int money;
    std::vector<Hand> hands;  // Вектор рук для поддержки сплита
    int currentHandIndex;     // Текущая активная рука
    int totalBet;

public:
    Player(std::string playerName, int startMoney);

    // Управление руками
    void addHand(const Hand& hand);
    void clearHands();
    Hand& getCurrentHand();
    const Hand& getCurrentHand() const;
    std::vector<Hand>& getHands();
    const std::vector<Hand>& getHands() const;
    bool nextHand();
    void resetToFirstHand();
    int getCurrentHandIndex() const;
    int getHandCount() const;

    // Базовые операции
    void placeBet(int amount);
    void addMoney(int amount);  // ДОБАВЬТЕ ЭТУ СТРОКУ
    void win(bool isBlackjack = false);
    void lose();
    void draw();

    // Геттеры и сеттеры
    std::string getName() const;
    int getMoney() const;
    int getTotalBet() const;
    void setTotalBet(int bet);

    void displayInfo() const;
};

#endif