#include "player.h"

Player::Player(std::string n) : name(std::move(n)), money(2500), hasSplit(false) {

    // name(std::move(n)) передаЄт владение строкой без копировани€
    bets.push_back(0);
    handDone.push_back(false);
    handStand.push_back(false);
}

bool Player::placeBet(int amount, int handIndex) {
    if (money < amount) return false;

    // ≈сли нужно, расшир€ем список
    while (handIndex >= static_cast<int>(bets.size())) {
        bets.push_back(0);
    }

    auto iter = bets.begin();
    std::advance(iter, handIndex);

    money -= amount;
    *iter = amount;

    return true;
}


bool Player::split() {
    // Ќужно чтобы руку можно было поделить, она не была уже поделена и количество карт было равно 2
    if (hands[currentHandIndex].canSplit() && !hasSplit &&
        hands[currentHandIndex].getCardAmount() == 2) {

        Hand newHand;
        Card secondCard = hands[currentHandIndex].getCard(1);
        newHand.addCard(secondCard);

        Hand currentHand;
        currentHand.addCard(hands[currentHandIndex].getCard(0));
        hands[currentHandIndex] = currentHand;

        hands.push_back(newHand);

        bets.push_back(getCurrentBet());
        money -= getCurrentBet();

        handDone.push_back(false);
        handStand.push_back(false);

        hasSplit = true;
        return true;
    }
    return false;
}

bool Player::canSplit() const {
    return hands[currentHandIndex].canSplit() && !hasSplit &&
        hands[currentHandIndex].getCardAmount() == 2;
}

bool Player::hasCurrentHandStood() const {
    // проверка, что не будет выхода за границу вектора handStand
    if (currentHandIndex < static_cast<int>(handStand.size())) {
        return handStand[currentHandIndex];

    }
    return false;
}

void Player::standCurrentHand() {
    if (currentHandIndex < static_cast<int>(handStand.size())) {
        handStand[currentHandIndex] = true;
        handDone[currentHandIndex] = true;
    }
}

void Player::markCurrentHandDone() {
    if (currentHandIndex < static_cast<int>(handDone.size())) {
        handDone[currentHandIndex] = true;
    }
}

bool Player::getNextHandToPlay() {
    for (size_t i = 0; i < handDone.size(); i++) {
        if (!handDone[i] && !hands[i].isBust()) {
            currentHandIndex = i;
            return true;
        }
    }
    return false;
}

void Player::resetToFirstHand() {
    currentHandIndex = 0;
}

bool Player::allHandsDone() const {
    // »спользуем all_of
    return std::all_of(handDone.begin(), handDone.end(), [](bool done) {
        return done;
    });
}

void Player::resetRound() {
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

void Player::win(int amount, int handIndex) {
    
    if (handIndex < static_cast<int>(bets.size())) {
        auto iter = bets.begin();
        std::advance(iter, handIndex);
        money += amount + (*iter);
        *iter = 0;
    }
}

void Player::lose(int handIndex) {
    if (handIndex < static_cast<int>(bets.size())) {
        auto iter = bets.begin();
        std::advance(iter, handIndex);
        *iter = 0;
    }
}

void Player::draw(int handIndex) {
    if (handIndex < static_cast<int>(bets.size())) {
        auto iter = bets.begin();
        std::advance(iter, handIndex);
        money += *iter;
        *iter = 0;
    }
}

std::string Player::getName() const {
    return name;
}

int Player::getMoney() const {
    return money;
}

int Player::getCurrentBet() const {
    if (currentHandIndex < static_cast<int>(bets.size())) {
        auto iter = bets.begin();
        std::advance(iter, currentHandIndex);
        return *iter;
    }
    return 0;
}

bool Player::getHasSplit() const {
    return hasSplit;
}


int Player::getCurrentHandIndex() const {
    return currentHandIndex;
}

int Player::getTotalHands() const {
    return hands.size();
}

void Player::displayHands() const {
    std::cout << name << ": ";
    for (size_t i = 0; i < hands.size(); i++) {
        if (i > 0) std::cout << "  ";
        hands[i].display();
    }
    std::cout << std::endl;
}

int Player::getBetForHand(int handIndex) const {
    if (handIndex >= 0 && handIndex < static_cast<int>(bets.size())) {
        auto iter = bets.begin();
        std::advance(iter, handIndex);
        return *iter;
    }
    return 0;
}