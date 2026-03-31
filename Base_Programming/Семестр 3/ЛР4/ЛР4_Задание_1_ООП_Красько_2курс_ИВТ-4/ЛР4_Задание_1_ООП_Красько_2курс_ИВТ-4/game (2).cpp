#include "game.h"
#include <iostream>
#include <limits>
#include <stdexcept>
#include <algorithm>
#include <cstdlib>
#include <ctime>

Game::Game(std::string playerName, int startMoney, bool hints)
    : deck(4), dealer(), player(playerName, startMoney) {
    hintsEnabled = hints;
    std::srand(static_cast<unsigned int>(std::time(nullptr)));
}

void Game::displayGameState(bool showDealerCard) const {
    std::cout << "\n--- ТЕКУЩАЯ ИГРА ---" << std::endl;

    // Колоды
    int totalCards = deck.cardsLeft();
    std::cout << "Колоды: ";
    for (int i = 0; i < 4; i++) {
        int cardsInDeck = totalCards / 4 + (i < totalCards % 4 ? 1 : 0);
        std::cout << "[" << cardsInDeck << "] ";
    }
    std::cout << std::endl;

    // Дилер
    dealer.display(!showDealerCard);

    // Игрок
    std::cout << player.getName() << ": ";
    if (player.getHandCount() > 1) {
        std::cout << "(Рука " << (player.getCurrentHandIndex() + 1) << "/" << player.getHandCount() << ") ";
    }
    player.getCurrentHand().display();
    std::cout << std::endl;
}

void Game::startNewRound() {
    std::cout << "\n=== НОВЫЙ РАУНД ===" << std::endl;

    // Очищаем руки
    player.clearHands();
    dealer.reset();

    // Перетасовываем колоду, если мало карт
    if (deck.cardsLeft() < 20) {
        deck.initialize();
        deck.shuffle();
    }

    player.displayInfo();

    // Получаем ставку
    int bet = 0;
    while (true) {
        std::cout << "Ваша ставка: ";

        if (!(std::cin >> bet)) {
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            std::cout << "Неверный ввод! Пожалуйста, введите число." << std::endl;
            continue;
        }

        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

        if (bet <= 0) {
            std::cout << "Ставка должна быть положительной!" << std::endl;
            continue;
        }

        try {
            player.placeBet(bet);
            break;
        }
        catch (const std::exception& e) {
            std::cout << "Ошибка: " << e.what() << std::endl;
        }
    }

    // Раздаем карты
    try {
        // Игроку
        player.getCurrentHand().addCard(deck.takeCard());
        player.getCurrentHand().addCard(deck.takeCard());

        // Дилеру
        dealer.takeCard(deck.takeCard());
        dealer.takeCard(deck.takeCard(), true);  // Вторая карта скрыта
    }
    catch (const BustException& e) {
        // Не должно происходить при раздаче
        std::cout << "Неожиданная ошибка при раздаче: " << e.what() << std::endl;
    }

    displayGameState();

    // Проверяем блэкджек у игрока
    if (player.getCurrentHand().isBlackjack()) {
        std::cout << "\nУ вас блэкджек!" << std::endl;
    }
}

bool Game::canSplit() const {
    return player.getCurrentHand().canSplit() &&
        player.getMoney() >= player.getCurrentHand().getBet();
}

std::string Game::getHint() const {
    int playerValue = player.getCurrentHand().getValue();
    auto dealerCards = dealer.getHand().getCards();

    if (dealerCards.empty()) {
        return "Нет подсказки";
    }

    int dealerUpcardValue = dealerCards[0].getValue();

    // Базовая стратегия
    if (playerValue <= 11) {
        return "Брать карту (у вас " + std::to_string(playerValue) + ")";
    }
    else if (playerValue >= 17) {
        return "Стоять (у вас " + std::to_string(playerValue) + ")";
    }
    else {
        // 12-16
        if (dealerUpcardValue >= 7) {
            return "Брать карту (у дилера сильная карта: " + std::to_string(dealerUpcardValue) + ")";
        }
        else {
            return "Стоять (у дилера слабая карта: " + std::to_string(dealerUpcardValue) + ")";
        }
    }
}

void Game::processHandTurn(Hand& hand) {
    bool handFinished = false;

    while (!handFinished && !hand.isBust()) {
        std::cout << "\nВыберите действие: 1. Стоять, 2. Взять карту";

        if (hand.getCardCount() == 2 && canSplit()) {
            std::cout << ", 3. Сплит";
        }

        if (hintsEnabled) {
            std::cout << ", 9. Подсказка";
        }

        std::cout << "\nВаш выбор: ";

        int choice;
        if (!(std::cin >> choice)) {
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            std::cout << "Неверный ввод! Пожалуйста, введите число." << std::endl;
            continue;
        }

        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

        switch (choice) {
        case 1:
            std::cout << "Вы остановились на " << hand.getValue() << " очках" << std::endl;
            handFinished = true;
            break;

        case 2: {
            try {
                Card newCard = deck.takeCard();
                std::cout << "Вы взяли карту: " << newCard << std::endl;
                hand.addCard(newCard);
                displayGameState();

                if (hand.isBust()) {
                    std::cout << "ПЕРЕБОР! " << hand.getValue() << " очков!" << std::endl;
                    handFinished = true;
                }
                else if (hand.getValue() == 21) {
                    std::cout << "У вас 21 очко!" << std::endl;
                    handFinished = true;
                }
            }
            catch (const BustException& e) {
                std::cout << "ПОЙМАНО ИСКЛЮЧЕНИЕ: " << e.what() << std::endl;
                handFinished = true;
            }
            break;
        }

        case 3:
            if (hand.getCardCount() == 2 && canSplit()) {
                processSplit();
                handFinished = true;
                return;
            }
            else {
                std::cout << "Нельзя разделить эту руку!" << std::endl;
            }
            break;

        case 9:
            if (hintsEnabled) {
                std::cout << "Подсказка: " << getHint() << std::endl;
            }
            else {
                std::cout << "Подсказки отключены!" << std::endl;
            }
            break;

        default:
            std::cout << "Неверный выбор! Пожалуйста, выберите 1, 2";
            if (hand.getCardCount() == 2 && canSplit()) {
                std::cout << ", 3";
            }
            if (hintsEnabled) {
                std::cout << ", 9";
            }
            std::cout << std::endl;
        }
    }
}

void Game::processSplit() {
    std::cout << "\n=== РАЗДЕЛЕНИЕ РУКИ ===" << std::endl;

    // Получаем текущую руку и карты
    Hand& currentHand = player.getCurrentHand();
    auto cards = currentHand.getCards();
    int originalBet = currentHand.getBet();

    // Проверяем, достаточно ли денег для сплита
    if (player.getMoney() < originalBet) {
        std::cout << "Недостаточно денег для разделения руки!" << std::endl;
        return;
    }

    // Снимаем дополнительные деньги
    player.placeBet(originalBet);

    // Создаем две новые руки
    Hand hand1, hand2;

    try {
        // Первая рука: первая карта + новая карта
        hand1.addCard(cards[0]);
        hand1.addCard(deck.takeCard());
        hand1.setBet(originalBet);

        // Вторая рука: вторая карта + новая карта
        hand2.addCard(cards[1]);
        hand2.addCard(deck.takeCard());
        hand2.setBet(originalBet);
    }
    catch (const BustException& e) {
        std::cout << "Ошибка при создании разделенных рук: " << e.what() << std::endl;
        return;
    }

    // Заменяем текущие руки
    player.clearHands();
    player.addHand(hand1);
    player.addHand(hand2);

    std::cout << "Рука разделена на две:" << std::endl;
    std::cout << "Рука 1: ";
    player.getHands()[0].display();
    std::cout << "\nРука 2: ";
    player.getHands()[1].display();
    std::cout << std::endl;

    // Играем каждую руку по очереди
    player.resetToFirstHand();
    for (int i = 0; i < player.getHandCount(); i++) {
        if (i > 0) {
            std::cout << "\n--- ИГРАЕМ РУКУ " << (i + 1) << " ---" << std::endl;
        }

        displayGameState();

        if (!player.getCurrentHand().isBlackjack()) {
            processHandTurn(player.getCurrentHand());
        }
        else {
            std::cout << "Блэкджек в руке " << (i + 1) << "!" << std::endl;
        }

        if (i < player.getHandCount() - 1) {
            player.nextHand();
        }
    }
}

void Game::playerTurn() {
    std::cout << "\n--- ВАШ ХОД ---" << std::endl;

    player.resetToFirstHand();

    for (int i = 0; i < player.getHandCount(); i++) {
        if (i > 0) {
            std::cout << "\n--- РУКА " << (i + 1) << " ---" << std::endl;
        }

        Hand& hand = player.getCurrentHand();

        if (hand.isBlackjack()) {
            std::cout << "Блэкджек! У вас 21 с двух карт!" << std::endl;
        }
        else {
            processHandTurn(hand);
        }

        if (i < player.getHandCount() - 1) {
            player.nextHand();
        }
    }
}

void Game::dealerTurn() {
    std::cout << "\n--- ХОД ДИЛЕРА ---" << std::endl;

    // Открываем скрытую карту дилера
    dealer.revealCard();
    displayGameState(true);

    // Правила 17+4: дилер берет на мягких 17 с 4 картами или меньше
    bool dealerFinished = false;

    while (!dealerFinished) {
        int dealerValue = dealer.getHand().getValue();
        int cardCount = dealer.getHand().getCardCount();
        bool isSoft17 = dealer.getHand().isSoft17();

        if (dealerValue < 17) {
            // Дилер берет карту
            try {
                Card newCard = deck.takeCard();
                dealer.getHand().addCard(newCard);
                std::cout << "Дилер берет карту: " << newCard << std::endl;
                displayGameState(true);
            }
            catch (const BustException& e) {
                std::cout << "Дилер перебрал! " << e.what() << std::endl;
                dealerFinished = true;
            }
        }
        else if (dealerValue == 17 && isSoft17 && cardCount < 4) {
            // Мягкие 17 с менее чем 4 картами - берет еще
            try {
                Card newCard = deck.takeCard();
                dealer.getHand().addCard(newCard);
                std::cout << "Дилер берет карту на мягких 17: " << newCard << std::endl;
                displayGameState(true);
            }
            catch (const BustException& e) {
                std::cout << "Дилер перебрал! " << e.what() << std::endl;
                dealerFinished = true;
            }
        }
        else {
            // Дилер останавливается
            dealerFinished = true;
        }

        if (dealer.getHand().isBust()) {
            dealerFinished = true;
        }
    }

    std::cout << "Дилер остановился на " << dealer.getHand().getValue() << " очках" << std::endl;
}

void Game::calculateResults() {
    std::cout << "\n=== РЕЗУЛЬТАТЫ ===" << std::endl;

    int dealerValue = dealer.getHand().getValue();
    bool dealerBust = dealer.getHand().isBust();
    bool dealerBlackjack = dealer.getHand().isBlackjack();

    int totalWin = 0;
    int totalLoss = 0;
    int totalDraw = 0;

    player.resetToFirstHand();
    for (int i = 0; i < player.getHandCount(); i++) {
        Hand& hand = player.getCurrentHand();
        int bet = hand.getBet();

        std::cout << (i == 0 ? "Основная рука: " : "Рука " + std::to_string(i + 1) + ": ");
        hand.display();
        std::cout << std::endl;

        int playerValue = hand.getValue();
        bool playerBust = hand.isBust();
        bool playerBlackjack = hand.isBlackjack();

        if (playerBust) {
            std::cout << "  -> Проигрыш (перебор)" << std::endl;
            totalLoss += bet;
        }
        else if (dealerBust) {
            std::cout << "  -> Выигрыш (дилер перебрал)" << std::endl;
            if (playerBlackjack) {
                // Блэкджек платит 3:2
                int winAmount = bet + (bet * 3) / 2;
                player.addMoney(winAmount);
                totalWin += winAmount;
                std::cout << "     Блэкджек! Выигрыш: " << winAmount << " (ставка: " << bet << ")" << std::endl;
            }
            else {
                // Обычный выигрыш 1:1
                player.addMoney(bet * 2);
                totalWin += bet * 2;
                std::cout << "     Выигрыш: " << (bet * 2) << " (ставка: " << bet << ")" << std::endl;
            }
        }
        else if (playerBlackjack && !dealerBlackjack) {
            std::cout << "  -> Выигрыш (у вас блэкджек!)" << std::endl;
            int winAmount = bet + (bet * 3) / 2;
            player.addMoney(winAmount);
            totalWin += winAmount;
            std::cout << "     Блэкджек! Выигрыш: " << winAmount << " (ставка: " << bet << ")" << std::endl;
        }
        else if (!playerBlackjack && dealerBlackjack) {
            std::cout << "  -> Проигрыш (у дилера блэкджек)" << std::endl;
            totalLoss += bet;
        }
        else if (playerValue > dealerValue) {
            std::cout << "  -> Выигрыш (" << playerValue << " > " << dealerValue << ")" << std::endl;
            player.addMoney(bet * 2);
            totalWin += bet * 2;
            std::cout << "     Выигрыш: " << (bet * 2) << " (ставка: " << bet << ")" << std::endl;
        }
        else if (playerValue < dealerValue) {
            std::cout << "  -> Проигрыш (" << playerValue << " < " << dealerValue << ")" << std::endl;
            totalLoss += bet;
        }
        else {
            std::cout << "  -> Ничья (" << playerValue << " = " << dealerValue << ")" << std::endl;
            player.addMoney(bet); // Возвращаем ставку
            totalDraw += bet;
            std::cout << "     Возврат ставки: " << bet << std::endl;
        }

        if (i < player.getHandCount() - 1) {
            player.nextHand();
        }
    }

    // Выводим итоги
    int netResult = (totalWin + totalDraw) - player.getTotalBet();

    std::cout << "\nИтог раунда:" << std::endl;
    std::cout << "Общий выигрыш: " << totalWin << std::endl;
    std::cout << "Общий проигрыш: " << totalLoss << std::endl;
    std::cout << "Ничья: " << totalDraw << std::endl;
    std::cout << "Общая ставка: " << player.getTotalBet() << std::endl;
    std::cout << "Чистый результат: " << (netResult >= 0 ? "+" : "") << netResult << std::endl;
    std::cout << "Новый баланс: " << player.getMoney() << std::endl;

    // Сбрасываем общую ставку
    player.setTotalBet(0);
}

void Game::play() {
    std::cout << "=== БЛЭКДЖЕК 17+4 СО СПЛИТОМ ===" << std::endl;
    std::cout << "Правила:" << std::endl;
    std::cout << "- Дилер стоит на жестких 17" << std::endl;
    std::cout << "- Дилер берет на мягких 17 с 4 картами или меньше" << std::endl;
    std::cout << "- Можно разделять одинаковые карты (сплит)" << std::endl;
    std::cout << "- Блэкджек оплачивается 3:2" << std::endl;
    std::cout << "- При переборе бросается исключение\n" << std::endl;

    bool continuePlaying = true;

    while (continuePlaying && player.getMoney() > 0) {
        try {
            startNewRound();

            // Ход игрока, если нет блэкджека
            if (!player.getCurrentHand().isBlackjack()) {
                playerTurn();
            }

            // Ход дилера, если игрок не перебрал во всех руках
            bool allHandsBusted = true;
            for (const auto& hand : player.getHands()) {
                if (!hand.isBust()) {
                    allHandsBusted = false;
                    break;
                }
            }

            if (!allHandsBusted) {
                dealerTurn();
            }

            calculateResults();
        }
        catch (const BustException& e) {
            std::cout << "\n!!! ПОЙМАНО ИСКЛЮЧЕНИЕ: " << e.what() << " !!!" << std::endl;
            calculateResults();
        }
        catch (const std::exception& e) {
            std::cout << "\nОшибка: " << e.what() << std::endl;
        }

        if (player.getMoney() <= 0) {
            std::cout << "\nУ вас закончились деньги! Игра окончена." << std::endl;
            break;
        }

        // Спрашиваем, хочет ли игрок продолжить
        char choice;
        std::cout << "\nХотите сыграть еще раз? (д/н): ";

        // Очищаем буфер ввода
        std::cin.clear();
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

        if (!(std::cin >> choice)) {
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            continuePlaying = false;
        }
        else {
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            if (choice == 'д' || choice == 'Д' || choice == 'y' || choice == 'Y') {
                continuePlaying = true;
                std::cout << "\nПродолжаем игру..." << std::endl;
            }
            else {
                continuePlaying = false;
            }
        }
    }

    std::cout << "\n=== ИГРА ОКОНЧЕНА ===" << std::endl;
    std::cout << "Итоговый баланс " << player.getName() << ": " << player.getMoney() << std::endl;
    if (player.getMoney() > 1000) {
        std::cout << "Отличный результат! Вы в плюсе!" << std::endl;
    }
    else if (player.getMoney() == 1000) {
        std::cout << "Вы закончили с тем же, с чего начинали." << std::endl;
    }
    else {
        std::cout << "В следующий раз повезет больше!" << std::endl;
    }
    std::cout << "Спасибо за игру!" << std::endl;
}