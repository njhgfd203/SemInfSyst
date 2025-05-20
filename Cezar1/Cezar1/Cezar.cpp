#include <iostream>
#include <string>
#include <vector>
#include <clocale> // ��� setlocale()
#include <Windows.h> // ��� SetConsoleCP() � SetConsoleOutputCP()

using namespace std;

// ������� ��� ����������� �������
char caesar_encode_char(char c, int key) {
    // ������� ������� � "�" � "�"
    string alphabet = "��������������������������������";
    string numbers = "0123456789";

    // ���������, �������� �� ������ ������
    size_t pos = alphabet.find(c);
    if (pos != string::npos) {
        // �������� �����
        int new_pos = (pos + key) % alphabet.length();
        if (new_pos < 0) {
            new_pos += alphabet.length(); // ������������ ������������� ��������
        }
        return alphabet[new_pos];
    }

    // ���������, �������� �� ������ ������
    pos = numbers.find(c);
    if (pos != string::npos) {
        // �������� �����
        int new_pos = (pos + key) % numbers.length();
        if (new_pos < 0) {
            new_pos += numbers.length(); // ������������ ������������� ��������
        }
        return numbers[new_pos];
    }


    // ���� ������ �� ����� � �� �����, ���������� ��� ��� ���������
    return c;
}

// ������� ��� ������������� �������
char caesar_decode_char(char c, int key) {
    // ��� ������������� ���������� ������������� �����
    return caesar_encode_char(c, -key);
}

// ������� ��� ����������� ������
string caesar_encode(string text, int key) {
    string result = "";
    for (char c : text) {
        result += caesar_encode_char(c, key);
    }
    return result;
}

// ������� ��� ������������� ������
string caesar_decode(string text, int key) {
    return caesar_encode(text, -key); // ���������� encode � ������������� ������
}

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    setlocale(LC_ALL, "Russian");
    string text;
    int key;

    cout << "������� �����: ";
    cin >> text;

    cout << "������� ���� (����� �����): ";
    cin >> key;

    string encoded_text = caesar_encode(text, key);
    string decoded_text = caesar_decode(encoded_text, key);

    cout << "������������� �����: " << encoded_text << endl;
    cout << "�������������� �����: " << decoded_text << endl;

    return 0;
}