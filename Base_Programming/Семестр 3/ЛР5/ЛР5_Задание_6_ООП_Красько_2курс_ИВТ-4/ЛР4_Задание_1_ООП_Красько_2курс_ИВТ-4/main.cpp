#include "game.h"

int main() {
    setlocale(LC_ALL, "Russian");

    // Рандом
    std::srand(static_cast<unsigned int>(std::time(nullptr)));

    // Всё делается внутри класса
    Game blackjackGame;
    blackjackGame.run();

    return 0;
}