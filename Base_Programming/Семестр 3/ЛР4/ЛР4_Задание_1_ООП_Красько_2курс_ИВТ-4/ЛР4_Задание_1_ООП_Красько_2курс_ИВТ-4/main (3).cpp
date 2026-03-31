#include "game.h"

int main() {
    setlocale(LC_ALL, "Russian");
    std::srand(static_cast<unsigned int>(std::time(nullptr)));

    Game blackjackGame;
    blackjackGame.run();

    return 0;
}