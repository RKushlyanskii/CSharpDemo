﻿// Операторы

namespace ConsoleAppDemo
{
    internal class Chapter_4
    {
        int a = 3;
        int b = 5;

        void Арифметические_операторы()
        {
            var c = b = a;

            c = a + b;
            c = a - b;
            c = a * b;
            c = a / b;
            c = a % b;

            c += a;
            c -= a;
            c *= a;
            c /= a;
            c %= a;

            a++;    // Постфиксный инкремент
            a--;
            ++a;
            --a;    // Префиксный декоремент
        }

        void Операторы_отношения_и_логические_операторы()
        {
            int a = 5;
            int b = 3;
            var x = true;
            var y = false;
            var z = !x;

            // Операторы отношения
            x = a < b;
            x = a <= b;
            x = a > b;
            x = a >= b;
            x = a == b;
            x = a != b;

            // Логические операторы
            z = x & y; // И
            z = x | y; // ИЛИ
            z = x ^ y; // исключающее ИЛИ (true, когда разные значения)
            z = x && y; // укороченное И
            z = x || y; // укороченное ИЛИ
            z = !x; // НЕ
        }

        void Операторы_присваивания()
        {
            a = 5 + 3;
            a = b;
            var c = a = b;

            // Составные операторы присваивания
            a += b;
            a -= b;
            a *= b;
            a /= b;
            a %= b;
            a &= b;
            a |= b;
            a ^= b;

            c = a > 0 ? a : b; // Тернарный оператор
        }

        void Поразрядные_операторы()
        {
            var c = 0;

            c = a & b;  // Поразрядное И
            c = a | b;  // Поразрядное ИЛИ
            c = a ^ b;  // Поразрядное исключающее ИЛИ
            c = a << 1; // Сдвиг влево (на 1)
            c = a >> 5; // Сдвиг вправо (на 5)
            c = ~a; // Дополнение до 1 (унарный оператор НЕ)
        }

    }
}
