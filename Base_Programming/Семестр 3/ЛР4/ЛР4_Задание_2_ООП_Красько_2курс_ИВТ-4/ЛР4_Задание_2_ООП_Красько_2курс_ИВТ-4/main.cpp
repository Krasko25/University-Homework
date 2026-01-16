#include <iostream>
#include "IFormattable.h"
#include "DeckClassAdapter.h"
#include "DeckObjectAdapter.h"

int main() {
    setlocale(LC_ALL, "Russian");

    std::cout << "1. ÀÄÀÏÒÅÐ ÊËÀÑÑÀ (1 êîëîäà):\n";
    std::cout << std::string(40, '=') << "\n";

    DeckClassAdapter adapter(1);
    std::cout << "Áåð¸ì 10 êàðò\n";
    for (int i = 0; i < 10; i++) {
        adapter.giveCard();
    }
    prettyPrint(adapter);

    std::cout << "\n\n2. ÀÄÀÏÒÅÐ ÎÁÚÅÊÒÀ (2 êîëîäû):\n";
    std::cout << std::string(40, '=') << "\n";

    Deck deck2(2);
    std::cout << "Áåð¸ì 63 êàðòû...\n";
    for (int i = 0; i < 63; i++) {
        deck2.giveCard();
    }
    DeckObjectAdapter objectAdapter(deck2);
    prettyPrint(objectAdapter);

    return 0;
}