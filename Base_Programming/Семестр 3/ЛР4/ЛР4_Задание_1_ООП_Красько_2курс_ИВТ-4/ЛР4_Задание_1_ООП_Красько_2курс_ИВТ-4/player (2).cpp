#include "player.h"
#include <iostream>
#include <stdexcept>
#include <algorithm>

Player::Player(std::string playerName, int startMoney) {
    name = playerName;
    money = startMoney;
    currentHandIndex = 0;
    hands.push_back(Hand());  // Начинаем с одной руки
    totalBet = 0;
}

void Player::addHand(const Hand& hand) {
    hands.push_back(hand);
}

void Player::clearHands() {
    hands.clear();
    currentHandIndex = 0;
    hands.push_back(Hand());
    totalBet = 0;
}

Hand& Player::getCurrentHand() {
    if (currentHandIndex >= 0 && currentHandIndex < hands.size()) {
        return hands[currentHandIndex];
    }
    throw std::out_of_range("Недопустимый индекс руки");
}

const Hand& Player::getCurrentHand() const {
    if (currentHandIndex >= 0 && currentHandIndex < hands.size()) {
        return hands[currentHandIndex];
    }
    throw std::out_of_range("Недопустимый индекс руки");
}

std::vector<Hand>& Player::getHands() {
    return hands;
}

const std::vector<Hand>& Player::getHands() const {
    return hands;
}

bool Player::nextHand() {
    if (currentHandIndex + 1 < hands.size()) {
        currentHandIndex++;
        return true;
    }
    return false;
}

void Player::resetToFirstHand() {
    currentHandIndex = 0;
}

int Player::getCurrentHandIndex() const {
    return currentHandIndex;
}

int Player::getHandCount() const {
    return hands.size();
}

void Player::placeBet(int amount) {
    if (amount <= 0) {
        throw std::invalid_argument("Ставка должна быть положительной!");
    }

    if (amount > money) {
        throw std::runtime_error("Недостаточно денег! Доступно: " + std::to_string(money));
    }

    money -= amount;
    totalBet += amount;

    if (hands.empty()) {
        hands.push_back(Hand());
    }
    hands[currentHandIndex].setBet(amount);
}

// ДОБАВЬТЕ ЭТОТ МЕТОД
void Player::addMoney(int amount) {
    if (amount < 0) {
        throw std::invalid_argument("Сумма не может быть отрицательной!");
    }
    money += amount;
}

void Player::win(bool isBlackjack) {
    // Этот метод теперь не используется для расчета, только для отображения
    std::cout << name << " выиграл!" << std::endl;
}

void Player::lose() {
    // Этот метод теперь не используется для расчета, только для отображения
    std::cout << name << " проиграл!" << std::endl;
}

void Player::draw() {
    // Этот метод теперь не используется для расчета, только для отображения
    money += totalBet; // Возвращаем ставку
    std::cout << name << " сыграл вничью" << std::endl;
    totalBet = 0;
}

std::string Player::getName() const {
    return name;
}

int Player::getMoney() const {
    return money;
}

int Player::getTotalBet() const {
    return totalBet;
}

void Player::setTotalBet(int bet) {
    totalBet = bet;
}

void Player::displayInfo() const {
    std::cout << "Игрок: " << name << " | Баланс: " << money;
    if (totalBet > 0) {
        std::cout << " | Общая ставка: " << totalBet;
    }
    std::cout << std::endl;
}