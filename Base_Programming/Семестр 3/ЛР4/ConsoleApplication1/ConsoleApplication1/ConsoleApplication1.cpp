#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include <random>
#include <ctime>
#include <memory>
#include <limits>

// Перечисления для мастей карт
enum class Suit { HEARTS, DIAMONDS, CLUBS, SPADES };

// Перечисления для достоинств карт
enum class Rank {
    ACE = 11, TWO = 2, THREE = 3, FOUR = 4, FIVE = 5, SIX = 6, SEVEN = 7,
    EIGHT = 8, NINE = 9, TEN = 10, JACK = 10, QUEEN = 10, KING = 10
};

// Предварительные объявления
class Card;
class Deck;
class Player;
class Dealer;
class Game;

// Класс Карты
class Card {
private:
    Suit suit;
    Rank rank;
    bool faceUp;

public:
    Card(Suit s, Rank r) : suit(s), rank(r), faceUp(true) {}

    int getValue() const {
        return static_cast<int>(rank);
    }

    Rank getRank() const { return rank; }

    bool isAce() const { return rank == Rank::ACE; }

    bool isTenValue() const {
        return rank == Rank::TEN || rank == Rank::JACK ||
            rank == Rank::QUEEN || rank == Rank::KING;
    }

    void flip() { faceUp = !faceUp; }

    bool isFaceUp() const { return faceUp; }

    std::string suitToString() const {
        switch (suit) {
        case Suit::HEARTS: return std::string(1, char(3));    // ♥
        case Suit::DIAMONDS: return std::string(1, char(4));  // ♦
        case Suit::CLUBS: return std::string(1, char(5));     // ♣
        case Suit::SPADES: return std::string(1, char(6));    // ♠
        default: return "?";
        }
    }

    std::string rankToString() const {
        if (rank == Rank::ACE) return "A";
        if (rank == Rank::JACK) return "J";
        if (rank == Rank::QUEEN) return "Q";
        if (rank == Rank::KING) return "K";
        return std::to_string(getValue());
    }

    void display() const {
        if (faceUp) {
            std::cout << rankToString() << suitToString();
        }
        else {
            std::cout << "??";
        }
    }
};

// Класс Колоды с 4 отдельными колодами
class Deck {
private:
    std::vector<std::vector<Card>> decks;  // 4 отдельные колоды
    std::vector<int> currentIndices;       // Текущая позиция в каждой колоде
    int nextDeckIndex;                     // Из какой колоды брать следующую карту

public:
    Deck() {
        initialize();
    }

    // Инициализация 4 колод по 52 карты в каждой
    void initialize() {
        decks.clear();
        currentIndices.clear();

        // Создаем 4 отдельные колоды
        for (int deckNum = 0; deckNum < 4; deckNum++) {
            std::vector<Card> deck;
            for (int s = 0; s < 4; s++) {
                for (int r = 1; r <= 13; r++) {
                    deck.emplace_back(static_cast<Suit>(s), static_cast<Rank>(r));
                }
            }
            decks.push_back(deck);
            currentIndices.push_back(0);
        }

        // Перемешиваем каждую колоду
        for (int i = 0; i < 4; i++) {
            shuffleDeck(i);
        }

        nextDeckIndex = 0;
    }

    // Перемешать конкретную колоду
    void shuffleDeck(int deckIndex) {
        std::random_device rd;
        std::mt19937 g(rd());
        std::shuffle(decks[deckIndex].begin(), decks[deckIndex].end(), g);
        currentIndices[deckIndex] = 0;
    }

    // Раздать одну карту из текущей колоды, затем перейти к следующей колоде
    Card dealCard() {
        // Если текущая колода закончилась, перетасовать ее
        if (currentIndices[nextDeckIndex] >= 52) {
            shuffleDeck(nextDeckIndex);
        }

        Card card = decks[nextDeckIndex][currentIndices[nextDeckIndex]];
        currentIndices[nextDeckIndex]++;

        // Перейти к следующей колоде для следующего взятия (1-я, 2-я, 3-я, 4-я, затем снова 1-я)
        nextDeckIndex = (nextDeckIndex + 1) % 4;

        return card;
    }

    // Показать оставшиеся карты в каждой колоде
    void displayDeckCounts() const {
        std::cout << "Колоды: ";
        for (int i = 0; i < 4; i++) {
            int remaining = 52 - currentIndices[i];
            std::cout << "[" << remaining << "] ";
        }
        std::cout << std::endl;
    }

    // Получить оставшиеся карты в конкретной колоде
    int getRemainingInDeck(int deckIndex) const {
        if (deckIndex >= 0 && deckIndex < 4) {
            return 52 - currentIndices[deckIndex];
        }
        return 0;
    }
};

// Класс Руки
class Hand {
private:
    std::vector<Card> cards;

public:
    Hand() = default;

    // Добавить карту в руку и проверить на перебор
    void addCard(const Card& card) {
        cards.push_back(card);
        // Бросить исключение если перебор
        /*if (getTotal() > 21) {
            throw std::runtime_error("ПЕРЕБОР! Сумма карт: " + std::to_string(getTotal()));
        }*/
    }

    void clear() {
        cards.clear();
    }

    int getTotal() const {
        int total = 0;
        int aceCount = 0;

        for (const auto& card : cards) {
            if (card.isFaceUp()) {
                total += card.getValue();
                if (card.isAce()) {
                    aceCount++;
                }
            }
        }

        if (cards.size() == 2 && aceCount == 2) {
            return 21;
        }

        return total;
    }

    int getCardCount() const {
        return cards.size();
    }

    Card getCard(int index) const {
        if (index >= 0 && index < static_cast<int>(cards.size())) {
            return cards[index];
        }
        throw std::out_of_range("Неверный индекс карты");
    }

    const std::vector<Card>& getCards() const {
        return cards;
    }

    bool isBust() const {
        return getTotal() > 21;
    }

    bool hasBlackjack() const {
        if (getCardCount() == 2) {
            if (cards[0].isAce() && cards[1].isAce()) {
                return true;
            }
            if ((cards[0].isAce() && cards[1].isTenValue()) ||
                (cards[1].isAce() && cards[0].isTenValue())) {
                return true;
            }
        }
        return false;
    }

    bool canSplit() const {
        if (cards.size() == 2) {
            return cards[0].getValue() == cards[1].getValue();
        }
        return false;
    }

    void display() const {
        for (const auto& card : cards) {
            card.display();
            std::cout << " ";
        }
    }
};

// Базовый класс Участника
class Participant {
protected:
    std::vector<Hand> hands;
    int currentHandIndex;

public:
    Participant() : currentHandIndex(0) {
        hands.emplace_back();
    }

    virtual void addCard(const Card& card) {
        hands[currentHandIndex].addCard(card);
    }

    Hand& getCurrentHand() {
        return hands[currentHandIndex];
    }

    std::vector<Hand>& getHands() {
        return hands;
    }

    const std::vector<Hand>& getHands() const {
        return hands;
    }

    void clearHands() {
        hands.clear();
        hands.emplace_back();
        currentHandIndex = 0;
    }

    bool isBust() const {
        return hands[currentHandIndex].isBust();
    }

    virtual void displayHand(bool showAll = true) const {
        hands[currentHandIndex].display();
    }

    virtual ~Participant() = default;
};

// Класс Игрока
class Player : public Participant {
private:
    std::string name;
    int money;
    std::vector<int> bets;
    bool hasSplit;
    std::vector<bool> handDone;
    std::vector<bool> handStand;

public:
    Player(std::string n)
        : name(std::move(n)), money(2500), hasSplit(false) {
        bets.push_back(0);
        handDone.push_back(false);
        handStand.push_back(false);
    }

    bool placeBet(int amount, int handIndex = 0) {
        if (handIndex >= static_cast<int>(bets.size())) {
            bets.resize(handIndex + 1, 0);
        }

        if (money >= amount) {
            money -= amount;
            bets[handIndex] = amount;
            return true;
        }
        return false;
    }

    bool split() {
        if (hands[currentHandIndex].canSplit() && !hasSplit &&
            hands[currentHandIndex].getCardCount() == 2) {

            Hand newHand;
            Card secondCard = hands[currentHandIndex].getCard(1);
            newHand.addCard(secondCard);

            Hand currentHand;
            currentHand.addCard(hands[currentHandIndex].getCard(0));
            hands[currentHandIndex] = currentHand;

            hands.push_back(newHand);

            bets.push_back(bets[currentHandIndex]);
            money -= bets[currentHandIndex];

            handDone.push_back(false);
            handStand.push_back(false);

            hasSplit = true;
            return true;
        }
        return false;
    }

    bool canSplit() const {
        return hands[currentHandIndex].canSplit() && !hasSplit &&
            hands[currentHandIndex].getCardCount() == 2;
    }

    bool hasCurrentHandStood() const {
        if (currentHandIndex < static_cast<int>(handStand.size())) {
            return handStand[currentHandIndex];
        }
        return false;
    }

    void standCurrentHand() {
        if (currentHandIndex < static_cast<int>(handStand.size())) {
            handStand[currentHandIndex] = true;
            handDone[currentHandIndex] = true;
        }
    }

    void markCurrentHandDone() {
        if (currentHandIndex < static_cast<int>(handDone.size())) {
            handDone[currentHandIndex] = true;
        }
    }

    bool getNextHandToPlay() {
        for (int i = 0; i < static_cast<int>(hands.size()); i++) {
            if (!handDone[i] && !hands[i].isBust()) {
                currentHandIndex = i;
                return true;
            }
        }
        return false;
    }

    void resetToFirstHand() {
        currentHandIndex = 0;
    }

    bool allHandsDone() const {
        for (size_t i = 0; i < hands.size(); i++) {
            if (!handDone[i] && !hands[i].isBust()) {
                return false;
            }
        }
        return true;
    }

    void resetRound() {
        clearHands();
        bets.clear();
        bets.push_back(0);
        handDone.clear();
        handDone.push_back(false);
        handStand.clear();
        handStand.push_back(false);
        currentHandIndex = 0;
        hasSplit = false;
    }

    void win(int amount, int handIndex = 0) {
        if (handIndex < static_cast<int>(bets.size())) {
            money += amount + bets[handIndex];
            bets[handIndex] = 0;
        }
    }

    void lose(int handIndex = 0) {
        if (handIndex < static_cast<int>(bets.size())) {
            bets[handIndex] = 0;
        }
    }

    void push(int handIndex = 0) {
        if (handIndex < static_cast<int>(bets.size())) {
            money += bets[handIndex];
            bets[handIndex] = 0;
        }
    }

    // Методы получения данных
    std::string getName() const { return name; }
    int getMoney() const { return money; }
    int getCurrentBet() const {
        return (currentHandIndex < static_cast<int>(bets.size())) ? bets[currentHandIndex] : 0;
    }
    bool getHasSplit() const { return hasSplit; }
    int getCurrentHandIndex() const { return currentHandIndex; }
    int getTotalHands() const { return hands.size(); }

    void displayHands() const {
        std::cout << name << ": ";
        for (size_t i = 0; i < hands.size(); i++) {
            if (i > 0) std::cout << "  ";
            hands[i].display();
        }
        std::cout << std::endl;
    }
};

// Класс Диллера
class Dealer : public Participant {
public:
    Dealer() : Participant() {}

    void displayHand(bool showAll = false) const override {
        if (!hands.empty()) {
            if (showAll) {
                hands[0].display();
            }
            else {
                if (hands[0].getCardCount() > 0) {
                    hands[0].getCard(0).display();
                    std::cout << " ??";
                }
            }
        }
    }

    bool shouldHit() const {
        int total = hands[0].getTotal();
        return total < 17;
    }

    int getVisibleCardValue() const {
        if (!hands.empty() && hands[0].getCardCount() > 0) {
            return hands[0].getCard(0).getValue();
        }
        return 0;
    }
};

// Класс Игры
class Game {
private:
    Deck deck;
    std::unique_ptr<Player> player;
    std::unique_ptr<Dealer> dealer;
    bool gameOver;

    std::string getHint() {
        int playerTotal = player->getCurrentHand().getTotal();
        int dealerCardValue = dealer->getVisibleCardValue();
        bool canSplitHand = player->canSplit();

        if (player->getCurrentHand().hasBlackjack()) {
            return "У вас Блэкджек! Остановитесь.";
        }

        if (canSplitHand && player->getCurrentHand().getCardCount() == 2) {
            int cardValue = player->getCurrentHand().getCard(0).getValue();

            switch (cardValue) {
            case 11: return "Разделяйте тузы!";
            case 10: return "Никогда не разделяйте карты стоимостью 10. Остановитесь.";
            case 9:
                if (dealerCardValue == 7 || dealerCardValue == 10 || dealerCardValue == 11) {
                    return "Не разделяйте девятки против 7, 10 или туза. Остановитесь.";
                }
                else {
                    return "Разделяйте девятки против диллера 2-6, 8, 9.";
                }
            case 8: return "Всегда разделяйте восьмерки!";
            case 7:
                if (dealerCardValue >= 2 && dealerCardValue <= 7) {
                    return "Разделяйте семерки против диллера 2-7.";
                }
                else {
                    return "Не разделяйте семерки против диллера 8-туз. Берите карту.";
                }
            case 6:
                if (dealerCardValue >= 2 && dealerCardValue <= 6) {
                    return "Разделяйте шестерки против диллера 2-6.";
                }
                else {
                    return "Не разделяйте шестерки против диллера 7-туз. Берите карту.";
                }
            case 5: return "Никогда не разделяйте пятерки. Считайте как 10. Берите карту если меньше 17.";
            case 4:
                if (dealerCardValue == 5 || dealerCardValue == 6) {
                    return "Разделяйте четверки против диллера 5-6.";
                }
                else {
                    return "Не разделяйте четверки против других карт. Берите карту.";
                }
            case 3: case 2:
                if (dealerCardValue >= 2 && dealerCardValue <= 7) {
                    return "Разделяйте " + std::to_string(cardValue) + " против диллера 2-7.";
                }
                else {
                    return "Не разделяйте " + std::to_string(cardValue) + " против диллера 8-туз. Берите карту.";
                }
            }
        }

        if (playerTotal >= 17) {
            return "Останавливайтесь на 17 или выше.";
        }
        else if (playerTotal >= 13 && playerTotal <= 16) {
            if (dealerCardValue >= 2 && dealerCardValue <= 6) {
                return "Остановитесь против диллера 2-6.";
            }
            else {
                return "Берите карту против диллера 7-туз.";
            }
        }
        else if (playerTotal == 12) {
            if (dealerCardValue >= 4 && dealerCardValue <= 6) {
                return "Остановитесь против диллера 4-6.";
            }
            else {
                return "Берите карту против диллера 2-3, 7-туз.";
            }
        }
        else {
            return "Всегда берите карту на 11 или меньше.";
        }
    }

public:
    Game() : gameOver(false) {
        dealer = std::make_unique<Dealer>();
    }

    void initialize() {
        std::string playerName;

        std::cout << "Добро пожаловать в 17+4 Блэкджек!\n";
        std::cout << "Правила:\n";
        std::cout << "1. Диллер останавливается на 17 или выше\n";
        std::cout << "2. Четыре достоинства стоят 10: 10, Валет, Дама, Король\n";
        std::cout << "3. Туз всегда стоит 11\n";
        std::cout << "4. Два туза = Блэкджек!\n";
        std::cout << "5. Разделение карт разрешено\n";
        std::cout << "6. Стартовые деньги: $2500\n\n";

        std::cout << "Введите ваше имя: ";
        std::getline(std::cin, playerName);

        player = std::make_unique<Player>(playerName);
    }

    void playRound() {
        player->resetRound();
        dealer->clearHands();

        if (player->getMoney() <= 0) {
            std::cout << "\nУ вас закончились деньги! Игра окончена.\n";
            gameOver = true;
            return;
        }

        std::cout << "\n=== Новый Раунд ===\n";
        std::cout << "Деньги: $" << player->getMoney() << std::endl;

        int betAmount;
        do {
            std::cout << "Ваша ставка? ";
            std::cin >> betAmount;
            if (betAmount <= 0 || betAmount > player->getMoney()) {
                std::cout << "Неверная сумма ставки. У вас $" << player->getMoney() << std::endl;
            }
        } while (betAmount <= 0 || betAmount > player->getMoney());

        if (!player->placeBet(betAmount)) {
            std::cout << "Недостаточно денег!\n";
            return;
        }

        // Показать количество карт в колодах
        deck.displayDeckCounts();

        // Раздать начальные карты (по кругу: игрок из колоды 1, диллер из колоды 2, игрок из колоды 3, диллер из колоды 4)
        player->addCard(deck.dealCard());
        dealer->addCard(deck.dealCard());
        player->addCard(deck.dealCard());
        dealer->addCard(deck.dealCard());

        // Показать стол в запрошенном формате
        std::cout << "Диллер: ";
        dealer->displayHand(false);
        std::cout << std::endl;
        player->displayHands();

        // Проверить на блэкджек диллера
        if (dealer->getCurrentHand().hasBlackjack()) {
            std::cout << "\nУ диллера Блэкджек!\n";
            std::cout << "Диллер: ";
            dealer->displayHand(true);
            std::cout << std::endl;

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

        // Проверить на блэкджек игрока
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

            std::cout << "\n--- Рука " << (player->getCurrentHandIndex() + 1)
                << " ---" << std::endl;

            playPlayerHand();
        }

        // Ход диллера если у игрока есть не переборные руки
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
            std::cout << "\nВсе ваши руки перебрали! Диллер выигрывает.\n";
        }

        settleBets();
    }

    void playPlayerHand() {
        bool handDone = false;

        while (!handDone && !player->getCurrentHand().isBust()) {
            std::cout << "Диллер: ";
            dealer->displayHand(false);
            std::cout << std::endl;
            player->displayHands();

            std::cout << "\n1. Остановиться 2. Взять карту";
            if (player->canSplit()) {
                std::cout << " 3. Разделить";
            }
            std::cout << " 9. Получить подсказку\n... ";
            std::cout << "Выбор: ";

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
                    player->addCard(deck.dealCard());
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
                        std::cout << "Рука разделена! Теперь у вас "
                            << player->getTotalHands() << " рук.\n";
                        // Раздать карты в обе руки
                        try {
                            player->addCard(deck.dealCard());
                        }
                        catch (const std::runtime_error& e) {
                            std::cout << e.what() << std::endl;
                        }

                        if (player->getHands().size() > 1) {
                            Card newCard = deck.dealCard();
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

    void playDealerHand() {
        std::cout << "\n--- Ход Диллера ---\n";
        std::cout << "Диллер: ";
        dealer->displayHand(true);
        std::cout << std::endl;

        while (dealer->shouldHit() && !dealer->isBust()) {
            std::cout << "Диллер берет карту...\n";
            dealer->addCard(deck.dealCard());
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

    void settleBets() {
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

    void run() {
        initialize();

        while (!gameOver) {
            playRound();

            if (!gameOver) {
                std::cout << "\nСыграть еще раунд? (д/н): ";
                std::string choice;
                std::cin >> choice;

                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

                if (choice == "д" || choice == "Д" || choice == "y" || choice == "Y") {
                    continue;
                }
                else if (choice == "н" || choice == "Н" || choice == "n" || choice == "N") {
                    gameOver = true;
                    std::cout << "\nСпасибо за игру в 17+4 Блэкджек! Итоговые деньги: $"
                        << player->getMoney() << std::endl;
                }
                else {
                    std::cout << "Неверный выбор.\n";
                }
            }
        }
    }
};

// Главная функция
int main() {
    setlocale(LC_ALL, "Russian");
    std::srand(static_cast<unsigned int>(std::time(nullptr)));

    Game blackjackGame;
    blackjackGame.run();

    return 0;
}