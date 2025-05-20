#include <iostream>
#include <string>
#include <vector>
#include <clocale> // для setlocale()
#include <Windows.h> // для SetConsoleCP() и SetConsoleOutputCP()

using namespace std;

// Функция для кодирования символа
char caesar_encode_char(char c, int key) {
    // Русский алфавит с "ё" и "й"
    string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    string numbers = "0123456789";

    // Проверяем, является ли символ буквой
    size_t pos = alphabet.find(c);
    if (pos != string::npos) {
        // Кодируем букву
        int new_pos = (pos + key) % alphabet.length();
        if (new_pos < 0) {
            new_pos += alphabet.length(); // Обрабатываем отрицательные значения
        }
        return alphabet[new_pos];
    }

    // Проверяем, является ли символ цифрой
    pos = numbers.find(c);
    if (pos != string::npos) {
        // Кодируем цифру
        int new_pos = (pos + key) % numbers.length();
        if (new_pos < 0) {
            new_pos += numbers.length(); // Обрабатываем отрицательные значения
        }
        return numbers[new_pos];
    }


    // Если символ не буква и не цифра, возвращаем его без изменений
    return c;
}

// Функция для декодирования символа
char caesar_decode_char(char c, int key) {
    // Для декодирования используем отрицательный сдвиг
    return caesar_encode_char(c, -key);
}

// Функция для кодирования строки
string caesar_encode(string text, int key) {
    string result = "";
    for (char c : text) {
        result += caesar_encode_char(c, key);
    }
    return result;
}

// Функция для декодирования строки
string caesar_decode(string text, int key) {
    return caesar_encode(text, -key); // Используем encode с отрицательным ключом
}

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    setlocale(LC_ALL, "Russian");
    string text;
    int key;

    cout << "Введите слово: ";
    cin >> text;

    cout << "Введите ключ (целое число): ";
    cin >> key;

    string encoded_text = caesar_encode(text, key);
    string decoded_text = caesar_decode(encoded_text, key);

    cout << "Зашифрованное слово: " << encoded_text << endl;
    cout << "Расшифрованное слово: " << decoded_text << endl;

    return 0;
}