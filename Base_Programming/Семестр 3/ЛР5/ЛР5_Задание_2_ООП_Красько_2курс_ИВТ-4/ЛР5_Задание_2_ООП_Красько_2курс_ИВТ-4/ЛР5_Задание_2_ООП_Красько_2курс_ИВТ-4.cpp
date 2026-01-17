#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <fstream>
#include <map>
#include <vector>
#include <cstring>
#include <cctype> // для нижнего регистра
#include <windows.h>  // Для смены кодировки консоли

using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    cout << "Введите имя файла: ";
    string filename;
    cin >> filename;

    ifstream file(filename);
    if (!file.is_open()) {
        cout << "Ошибка! Файл не найден." << endl;
        return 1;
    }

    map<string, int> wordsMap;

    const size_t stringLen = 250;
    char line[stringLen];

    while (file.getline(line, stringLen)) {
        char* word = strtok(line, " .,-:!;");

        while (word != NULL) {
            string currentWord = word;

            // Всё слова должны быть в нижнем регистре
            for (size_t i = 0; i < currentWord.length(); i++) {
                currentWord[i] = tolower((unsigned char)currentWord[i]);
            }

            // Проверяем длину слова
            if (currentWord.length() > 3) {
                wordsMap[currentWord]++;
            }
            // следующее слово для следующей иттерации
            word = strtok(NULL, " .,-:!;");
        }
    }

    file.close();

    // Переносим в вектор пар сторок с количеством вхождений
    vector<pair<string, int>> wordsVector;

    for (auto it = wordsMap.begin(); it != wordsMap.end(); ++it) {
        if (it->second >= 7) {
            wordsVector.push_back(make_pair(it->first, it->second));
        }
    }

    // пузырьковая сортировка
    if (!wordsVector.empty()) {
        for (size_t i = 0; i < wordsVector.size(); i++) {
            for (size_t j = 0; j < wordsVector.size() - 1; j++) {
                if (wordsVector[j].second < wordsVector[j + 1].second) {
                    auto temp = wordsVector[j];
                    wordsVector[j] = wordsVector[j + 1];
                    wordsVector[j + 1] = temp;
                }
            }
        }
    }

    // Выводим результаты
    cout << "\nСлова длиной > 3, которые встречаются > 6 раз):\n-----------------------------------------\n";

    if (wordsVector.empty()) {
        cout << "Нет слов, удовлетворяющих условию" << endl;
    }
    else {
        for (size_t i = 0; i < wordsVector.size(); i++) {
            cout << wordsVector[i].first << "\t\t" << wordsVector[i].second << endl;
        }
    }

    return 0;
}