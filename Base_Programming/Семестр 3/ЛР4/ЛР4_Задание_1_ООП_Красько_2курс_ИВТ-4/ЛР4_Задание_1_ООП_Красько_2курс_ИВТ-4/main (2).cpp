#include <iostream>
#include <limits>
#include "game.h"

int main() {
    setlocale(LC_ALL, "Russian");

    std::cout << "=== ИГРА БЛЭКДЖЕК 17+4 ===" << std::endl;
    std::cout << "Специальный вариант с правилами сплита\n" << std::endl;

    std::string playerName;
    std::cout << "Введите ваше имя: ";
    std::getline(std::cin, playerName);

    if (playerName.empty()) {
        playerName = "Игрок";
    }

    bool hints = false;
    char hintChoice;
    std::cout << "\nВключить подсказки? (д/н): ";
    std::cin >> hintChoice;

    if (hintChoice == 'д' || hintChoice == 'Д' || hintChoice == 'y' || hintChoice == 'Y') {
        hints = true;
        std::cout << "Подсказки включены!" << std::endl;
    }

    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

    // Создаем и запускаем игру
    Game game(playerName, 1000, hints);
    game.play();

    return 0;
}