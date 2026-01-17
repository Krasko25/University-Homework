#include "game.h"
#include <iostream>
#include <limits>

Game::Game() : gameOver(false) {
    dealer = std::make_unique<Dealer>();
}

// initialize отдельно от конструктора, чтобы не было ввода данных в конструкторе
void Game::initialize() {
    std::string playerName;

    std::cout << "Тип: базовый\nДоп. правила: сплит\n---------------------------\nОсобый вариант игры: 17+4. Особенности:\n";
    std::cout << "1. При сумме карт 17+ диллер останавливается\n";
    std::cout << "2. Список карт, имеющих стоимость 10: 10, валет, дама, король\n";
    std::cout << "3. Туз всегда стоит 11\n";
    std::cout << "4. Два туза = блэкджек!\n";
    std::cout << "5. Сплит разрешён\n";

    std::cout << "\nВведите ваше имя: ";
    std::getline(std::cin, playerName);

    player = std::make_unique<Player>(playerName);
}

std::string Game::getHint() {

    int playerTotal = player->getCurrentHand().getTotal();
    int dealerCardValue = dealer->getVisibleCardValue();
    bool canSplitHand = player->canSplit();

    // Если есть возможность сплита
    if (canSplitHand) {

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
        case 8: return "Всегда разделяйте восьмерки";
        case 7:
            if (dealerCardValue >= 2 && dealerCardValue <= 7) {
                return "Разделяйте семерки, если у дилера 2-7";
            }
            else {

                return "Не разделяйте семерки, если у диллера 8 и больше в сумме. Берите карту";
            }
        case 6:
            if (dealerCardValue >= 2 && dealerCardValue <= 6) {
                return "Разделяйте шестерки, если у диллера 2-6";
            }
            else {
                return "Не разделяйте шестерки, если у диллера 7 и выше. Берите карту";
            }
        case 5: return "Никогда не разделяйте пятерки. Берите карту если у вас меньше 17";
        case 4:
            if (dealerCardValue == 5 || dealerCardValue == 6) {
                return "Разделяйте четверки, если у диллера 5 или 6";
            }
            else {
                return "Не разделяйте четверки. Берите карту";
            }
        case 3: 
        case 2:
            if (dealerCardValue >= 2 && dealerCardValue <= 7) {
                return "Разделяйте 2 или 3, если у диллера 2-7";
            }
            else {
                return "Не разделяйте 2 или  3, если у диллера 8 или более. Берите карту";
            }
        }
    }

    if (playerTotal >= 17) {
        return "Если у вас больше 17, всегда останавливайтесь";
    }

    else if (playerTotal >= 13 && playerTotal <= 16) {
        if (dealerCardValue >= 2 && dealerCardValue <= 6) {
            return "Останавливайтесь, если у вас 13-16, а у диллера 2-6";
        }
        else {
            return "Берите карту, если у вас 13 -16, а у диллера 7 и более";
        }
    }
    else {
        return "Всегда берите карту на 12 или меньше";
    }
}

void Game::playRound() {
    player->resetRound();
    dealer->clearHands();

    if (player->getMoney() <= 0) {
        std::cout << "\nУ вас закончились деньги. Игра окончена\n";
        gameOver = true;
        return;
    }

    std::cout << "\nНачало новой партии\n---------------------\n";
    
    std::cout << "Баланс: $" << player->getMoney() << "\n";

    int betAmount;

    // выполняем пока пользователь не укажет допустимую сумму
    do {
        std::cout << "Ваша ставка?\n";
        std::cin >> betAmount;
        if (betAmount <= 0 || betAmount > player->getMoney()) {
            std::cout << "Невозможная сумма ставки\n";
        }
    } while (betAmount <= 0 || betAmount > player->getMoney());

    player->placeBet(betAmount);

    // Раздача первой партии карт
    player->addCard(deck.giveCard());
    dealer->addCard(deck.giveCard());
    player->addCard(deck.giveCard());
    dealer->addCard(deck.giveCard());

    // Показать количество карт в колодах
    std::cout << "\n";
    deck.displayDecksRemainingCards();

    // Проверить на блэкджек диллера
    if (dealer->getCurrentHand().hasBlackjack()) {
        betResults();
        return;
    }

    // Проверить на блэкДжек игрока
    if (player->getCurrentHand().hasBlackjack()) {
        betResults();
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


    // Ход диллера если у игрока есть руки, в которых не более 21 очка
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
        std::cout << "\nВы взяли слишком много карт! Диллер выигрывает\n";
    }

    betResults();
}

void Game::printCards() {
    std::cout << "Диллер: ";
    dealer->displayHand(false);
    // Выводим сообщение про руку только если больше одной руки
    
    std::cout << "\n";
    if (player->getTotalHands() > 1) {
        std::cout << "---Рука " << (player->getCurrentHandIndex() + 1) << "---\n";
    }
    player->displayHands();
}

void Game::playPlayerHand() {
    bool handDone = false;
    
    printCards();

    while (!handDone && !player->getCurrentHand().isBust()) {
        

        std::cout << "\n1. Остановиться\n2. Взять карту\n";
        if (player->canSplit()) {
            std::cout << "3. Сплит\n";
        }
        std::cout << "9. Получить подсказку\n";

        int choice;
        std::cin >> choice;

        switch (choice) {
        case 1: // Остановиться
            std::cout << "Вы остановились\n";
            player->standCurrentHand();
            handDone = true;
            player->displayHands();
            break;

        case 2: // Взять карту
            player->addCard(deck.giveCard());
            std::cout << "Вы взяли карту\n";
            player->displayHands();
            break;

        case 3: // Сплит
            if (player->canSplit()) {
                if (player->split()) {
                    std::cout << "Рука разделена!\n";

                    // Раздать карты в обе руки
                    player->addCard(deck.giveCard());

                    if (player->getHands().size() > 1) {
                        Card newCard = deck.giveCard();
                        player->getHands()[1].addCard(newCard);
                    }
                    
                    //printCards();
                    player->displayHands();
                }
                else {
                    std::cout << "Невозможно сделать сплит\n";
                }
            }
            else {
                std::cout << "Невозможно сделать сплит\n";
            }
            break;

        case 9: // Подсказка
            std::cout << "ПОДСКАЗКА: " << getHint() << "\n";
            break;

        default:
            std::cout << "Неверный выбор\n";
            break;
        }
    }

    if (player->getCurrentHand().isBust()) {
        player->markCurrentHandDone();
    }
}

void Game::playDealerHand() {
    std::cout << "\nХод Диллера\n-------------------\n";
    std::cout << "Диллер: ";
    dealer->displayHand(true); // показать все карты диллера

    while (dealer->shouldHit() && !dealer->isBust()) {
        std::cout << "\nДиллер берет карту...\n";
        dealer->addCard(deck.giveCard());

        std::cout << "Диллер: ";
        dealer->displayHand(true);
    }
    std::cout << "\n";

    if (dealer->isBust()) {
        std::cout << "Диллер перебрал\n";
        // Такая ситуация однако не произойдёт, т.к. мы обрабатываем перебор как исключение
    }
}

void Game::betResults() {
    int dealerTotal = dealer->getCurrentHand().getTotal();
    bool dealerBust = dealer->isBust();
    bool dealerBlackjack = dealer->getCurrentHand().hasBlackjack();

    std::cout << "-------------\n";
    printCards();
    std::cout << "-------------\n";

    for (int i = 0; i < player->getTotalHands(); i++) {
        Hand& hand = player->getHands()[i];
        int playerTotal = hand.getTotal();
        bool playerBlackjack = hand.hasBlackjack();
        if (player->getTotalHands() > 1)
            std::cout << "---Рука " << i + 1 << "---\n";

        if (hand.isBust()) {
            std::cout << "Итог: вы проиграли " << player->getCurrentBet() << "\n";
            player->lose(i);
        }
        else if (playerBlackjack && !dealerBlackjack) {
            std::cout << "Поздравляем! Блэкджек! Вы выиграли " << (player->getCurrentBet() * 1.5) << "\n";
            
            player->win(player->getCurrentBet() * 1.5, i);
        }
        else if (dealerBlackjack && !playerBlackjack) {
            std::cout << "Итог: У диллера блэкджек, вы проиграли " << player->getCurrentBet() << "\n";
            player->lose(i);
        }
        else if (playerBlackjack && dealerBlackjack) {
            std::cout << "Итог: У обоих блэкджек, ничья\n";
            player->draw(i);
        }
        else if (dealerBust) {
            std::cout << "Поздравляем! Диллер перебрал, вы выиграли " << player->getCurrentBet() << "\n";
            player->win(player->getCurrentBet(), i);
        }
        else if (playerTotal > dealerTotal) {
            std::cout << "Поздравляем! Вы выиграли " << player->getCurrentBet() << "\n";
            player->win(player->getCurrentBet(), i);
        }
        else if (playerTotal < dealerTotal) {
            std::cout << "Итог: вы проиграли " << player->getCurrentBet() << "\n";
            player->lose(i);
        }
        else {
            std::cout << "Итог: Ничья, ставка возвращена\n";
            player->draw(i);
        }
    }

    std::cout << "\nБаланс: " << player->getMoney() << "\n";
}


void Game::run() {
    initialize();

    while (!gameOver) {
        
        playRound();

        if (!gameOver) {
            std::cout << "\nСыграть еще раунд?\n1 - да\n2 - нет\nВаш выбор: ";
            std::string choice;
            std::cin >> choice;

            if (choice == "1") {
                continue;
            }
            else if (choice == "2") {
                gameOver = true;
                std::cout << "\nСпасибо за игру! Итоговый баланс: "
                    << player->getMoney() << "\n";
            }
            else {
                std::cout << "Неправильный вариант ответа\n";
            }
        }
    }
}