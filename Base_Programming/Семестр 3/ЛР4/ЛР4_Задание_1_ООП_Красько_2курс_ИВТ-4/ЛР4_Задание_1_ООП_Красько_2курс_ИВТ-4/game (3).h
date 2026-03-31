#ifndef GAME_H
#define GAME_H

#include "deck.h"
#include "player.h"
#include "dealer.h"
#include <memory>

class Game {
private:
    Deck deck;
    std::unique_ptr<Player> player; // unique_ptr дл€ автоматического освобождени€ пам€ти
    std::unique_ptr<Dealer> dealer;
    bool gameOver;

    std::string getHint(); // ¬озвращает текст подсказки
    void playPlayerHand();
    void playDealerHand();
    void settleBets(); // установить ставку

public:
    Game();
    void initialize();
    void playRound();
    void run(); // ƒл€ того, чтобы весь функционал, в том числе повторна€ парти€, был в классе, а не в main
};

#endif