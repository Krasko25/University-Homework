#include "game.h"
#include <iostream>
#include <limits>

Game::Game() : gameOver(false) {
    dealer = std::make_unique<Dealer>();
}

void Game::initialize() {
    std::string playerName;

    std::cout << "Правила  игры:\n";
    std::cout << "Тип: базовый\n";
    std::cout << "Доп. правила: сплит\n";
    std::cout << "Вариация: 17+4. Особенности:\n";
    std::cout << "1. Диллер останавливается на 17 или выше\n";
    std::cout << "2. Четыре типа карт стоят 10 очков: 10, Валет, Дама, Король\n";
    std::cout << "3. Туз всегда стоит 11\n";
    std::cout << "4. Два туза = Блэкджек!\n";
    std::cout << "5. Разделение карт разрешено\n";

    std::cout << "Введите ваше имя: ";
    std::getline(std::cin, playerName);

    player = std::make_unique<Player>(playerName);
}

std::string Game::getHint() {
    int playerTotal = player->getCurrentHand().getTotal();
    int dealerCardValue = dealer->getVisibleCardValue();
    bool canSplitHand = player->canSplit();

    if (canSplitHand && player->getCurrentHand().getCardCount() == 2) {
        int cardValue = player->getCurrentHand().getCard(0).getValue();

        switch (cardValue) {
        case 10: return "Никогда не разделяйте карты стоимостью 10. Остановитесь";
        case 9:
            if (dealerCardValue == 7 || dealerCardValue == 10 || dealerCardValue == 11) {
                return "Не разделяйте девятки, если у дилера 7, 10 или туз. Остановитесь";
            }
            else {
                return "Разделяйте девятки, если у диллера 2-6, 8, 9";
            }
        case 8: return "Всегда разделяйте восьмерки!";
        case 7:
            if (dealerCardValue >= 2 && dealerCardValue <= 7) {
                return "Разделяйте семерки, если у диллера 2-7";
            }
            else {
                return "Не разделяйте семерки, если у диллер диллера 8 или выше. Берите ещё одну карту";
            }
        case 6:
            if (dealerCardValue >= 2 && dealerCardValue <= 6) {
                return "Разделяйте шестерки, если у диллера 2-6";
            }
            else {
                return "Не разделяйте шестерки, если у диллера 7 и выше. Берите карту";
            }
        case 5: return "Никогда не разделяйте пятерки";
        case 4:
            if (dealerCardValue == 5 || dealerCardValue == 6) {
                return "Разделяйте четверки, если у диллера 5 или 6";
            }
            else {
                return "Не разделяйте четверки. Берите ещё одну карту";
            }
        case 3: case 2:
            if (dealerCardValue >= 2 && dealerCardValue <= 7) {
                return "Разделяйте 3 или 4, если у диллера 2-7";
            }
            else {
                return "Не разделяйте 1, если у диллера 8 и выше. Берите ещё карту";
            }
        }
    }

    if (playerTotal >= 17) {
        return "Если у вас в сумме 17 или больше, останавливайтесь";
    }
    else if (playerTotal >= 12 && playerTotal <= 16) {
        if (dealerCardValue >= 2 && dealerCardValue <= 6) {
            return "Если у диллера 2-6, то остановитель";
        }
        else {
            return "Если у диллера 7 или выше, берите карту";
        }
    }
    else {
        return "Всегда берите карту, если у вас в сумме 11 или меньше";
    }
}

void Game::playRound() {
    player->resetRound();
    dealer->clearHands();

    if (player->getMoney() <= 0) {
        std::cout << "\nУ вас закончились деньги! Игра окончена.\n";
        gameOver = true;
        return;
    }

    std::cout << "\nНачало новой партии\n---------------------\n";
    std::cout << "Баланс: $" << player->getMoney() << std::endl;

    int betAmount;

    // выполняем пока пользователь не укажет допустимую сумму
    do {
        std::cout << "Ваша ставка?\n";
        std::cin >> betAmount;
        if (betAmount <= 0 || betAmount > player->getMoney()) {
            std::cout << "Невозможная сумма ставки\n";
        }
    } while (betAmount <= 0 || betAmount > player->getMoney());

    // Раздать начальные карты
    player->addCard(deck.giveCard());
    dealer->addCard(deck.giveCard());
    player->addCard(deck.giveCard());
    dealer->addCard(deck.giveCard());

    // Показать количество карт в колодах
    std::cout << "\n";
    deck.displayRemainingCardsInDeck();

    // Проверить на блэкджек диллера
    if (dealer->getCurrentHand().hasBlackjack()) {
        std::cout << "\nУ диллера Блэкджек!\n";
        std::cout << "Диллер: ";
        dealer->displayHand(true);
        std::cout << "\n";

        if (player->getCurrentHand().hasBlackjack()) {
            std::cout << "У вас тоже Блэкджек! Ничья.\n";
            player->push();
        }
        else {
            std::cout << "Вы проиграли.\n";
            player->lose();
        }
        return;
    }

    // Проверить на блэкДжек игрока
    if (player->getCurrentHand().hasBlackjack()) {
        std::cout << "\nБлэкджек! Вы выиграли 3:2!\n";
        std::cout << "Диллер: ";
        dealer->displayHand(true);
        std::cout << std::endl;
        player->win(betAmount * 1.5);
        return;
    }

    // Ход игрока для каждой руки
    player->resetToFirstHand();

    while (!player->allHandsDone()) {
        if (!player->getNextHandToPlay()) {
            break;
        }

        playPlayerHand();
    }

    // Ход диллера если игрок не перебрал
    bool hasPlayableHands = false;
    for (const auto& hand : player->getHands()) {
        if (!hand.isBust()) {
            hasPlayableHands = true;
            break;
        }
    }

    if (hasPlayableHands) {
        playDealerHand();
    }
    else {
        std::cout << "\nВы перебрали. Диллер выигрывает.\n";
    }

    settleBets();
}

void Game::playPlayerHand() {
    bool handDone = false;

    while (!handDone && !player->getCurrentHand().isBust()) {
        std::cout << "Диллер: ";
        dealer->displayHand(false);

        // Выводим сообщение про руку только если у игрока больше одной руки
        if (player->getHasSplit()) {
            std::cout << "\nРука " << (player->getCurrentHandIndex() + 1);
        }
        std::cout << std::endl;
        player->displayHands();

        std::cout << "\n1. Остановиться\n2. Взять карту";
        if (player->canSplit()) {
            std::cout << "\n3. Разделить";
        }
        std::cout << "\n9. Получить подсказку\n";
        std::cout << "";

        int choice;
        std::cin >> choice;

        switch (choice) {
        case 1: // Остановиться
            std::cout << "Вы остановились.\n";
            player->standCurrentHand();
            handDone = true;
            break;

        case 2: // Взять карту
            try {
                player->addCard(deck.giveCard());
                std::cout << "Вы взяли карту.\n";
            }
            catch (const std::runtime_error& e) {
                std::cout << e.what() << std::endl;
                player->markCurrentHandDone();
                handDone = true;
            }
            break;

        case 3: // Разделить
            if (player->canSplit()) {
                if (player->split()) {
                    std::cout << "Рука разделена!";
                    // Раздать карты в обе руки
                    player->addCard(deck.giveCard());

                    if (player->getHands().size() > 1) {
                        Card newCard = deck.giveCard();
                        player->getHands()[1].addCard(newCard);
                    }
                }
                else {
                    std::cout << "Невозможно разделить эту руку.\n";
                }
            }
            else {
                std::cout << "Невозможно разделить эту руку.\n";
            }
            break;

        case 9: // Подсказка
            std::cout << "ПОДСКАЗКА: " << getHint() << std::endl;
            break;

        default:
            std::cout << "Неверный выбор.\n";
            break;
        }
    }

    if (player->getCurrentHand().isBust()) {
        player->markCurrentHandDone();
    }
}

void Game::playDealerHand() {
    std::cout << "\n--- Ход Диллера ---\n";
    std::cout << "Диллер: ";
    dealer->displayHand(true);
    std::cout << std::endl;

    while (dealer->shouldTake() && !dealer->isBust()) {
        std::cout << "Диллер берет карту...\n";
        dealer->addCard(deck.giveCard());
        std::cout << "Диллер: ";
        dealer->displayHand(true);
        std::cout << std::endl;
    }

    if (dealer->isBust()) {
        std::cout << "Диллер перебрал!\n";
    }
    else {
        std::cout << "Диллер остановился.\n";
    }
}

void Game::settleBets() {
    int dealerTotal = dealer->getCurrentHand().getTotal();
    bool dealerBust = dealer->isBust();
    bool dealerBlackjack = dealer->getCurrentHand().hasBlackjack();

    std::cout << "\n=== Результаты ===\n";

    for (int i = 0; i < player->getTotalHands(); i++) {
        Hand& hand = player->getHands()[i];
        int playerTotal = hand.getTotal();
        bool playerBlackjack = hand.hasBlackjack();

        std::cout << "Рука " << (i + 1) << ": ";
        hand.display();
        std::cout << " против Диллера: " << dealerTotal;

        if (hand.isBust()) {
            std::cout << " - Проиграли $" << player->getCurrentBet() << std::endl;
            player->lose(i);
        }
        else if (playerBlackjack && !dealerBlackjack) {
            std::cout << " - Блэкджек! Выиграли $" << (player->getCurrentBet() * 1.5) << std::endl;
            player->win(player->getCurrentBet() * 1.5, i);
        }
        else if (dealerBlackjack && !playerBlackjack) {
            std::cout << " - У диллера блэкджек, проиграли $" << player->getCurrentBet() << std::endl;
            player->lose(i);
        }
        else if (playerBlackjack && dealerBlackjack) {
            std::cout << " - У обоих блэкджек, ничья\n";
            player->push(i);
        }
        else if (dealerBust) {
            std::cout << " - Диллер перебрал, выиграли $" << player->getCurrentBet() << std::endl;
            player->win(player->getCurrentBet(), i);
        }
        else if (playerTotal > dealerTotal) {
            std::cout << " - Выиграли $" << player->getCurrentBet() << std::endl;
            player->win(player->getCurrentBet(), i);
        }
        else if (playerTotal < dealerTotal) {
            std::cout << " - Проиграли $" << player->getCurrentBet() << std::endl;
            player->lose(i);
        }
        else {
            std::cout << " - Ничья, ставка возвращена\n";
            player->push(i);
        }
    }

    std::cout << "\nВсего денег: $" << player->getMoney() << std::endl;
}

void Game::run() {
    initialize();

    while (!gameOver) {
        playRound();

        if (!gameOver) {
            std::cout << "\nСыграть еще раунд?\n1 - да\n2 - нет\nВаш выбор: ";
            std::string choice;
            std::cin >> choice;

            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            if (choice == "1") {
                continue;
            }
            else if (choice == "2") {
                gameOver = true;
                std::cout << "\nСпасибо за игру! Итоговый баланс: "
                    << player->getMoney() << std::endl;
            }
            else {
                std::cout << "Неправильный вариант ответа\n";
            }
        }
    }
}