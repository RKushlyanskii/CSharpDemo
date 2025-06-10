// # Типы данных, литералы и переменные
using System;

namespace ConsoleAppDemo
{
    internal class Chapter_3
    {
        void Типы_данных()
        {
            // Типы значений

            // Простые типы
            bool bl = true;         // true / false
            char ch = 'a';          // 0 - 65535 (32 bit)

            byte bt = 255;           // 0 - 255 (8 bit)
            short sh = -32768;       // -32 768 - 32 767 (16 bit)
            int i = -1000;          // -2 147 483 648 - 2 147 483 647 (32 bit)
            long l = -1000000L;      // - 9 223 372 036 854 775 808 - 9 223 372 036 854 775 807

            sbyte sb = -128;         // -128 - 127 (8 bit)
            ushort us = 65535;       // 0 - 65 535 (16 bit)
            uint ui = 1000U;          // 0 - 4 294 968 295 (32 bit)
            ulong ul = 1000UL;         // 0 - 18 446 744 073 709 551 615 (64 bit)

            float fl = 100.99f;      // 5E-45 - 3,4E+38 (32 bit)
            double db = 1000.99d;    // 5E-324 - 1,7E+308 (64 bit)
            decimal dm = 1000.99m;   // 1E-28 - 7,9E+28 (128 bit)

            var v = 5; // Неявно типизированная переменная

            //Ссылочные типы
            string st = "Hello world";
            int[] array = new int[5];
            //Program pg = new Program(); // class
        }

        void Управляющие_последовательности()
        {
            char ch;

            ch = '\a';  // Звуковой сигнал
            ch = '\b';  // Возврат на одну позицию
            ch = '\f';  // Перевод на новую страницу
            ch = '\n';  // Перевод на новую строку
            ch = '\r';  // Возврат каретки
            ch = '\t';  // Табуляция
            ch = '\v';  // Вертикальная табуляция
            ch = '\0';  // Пустой символ
            ch = '\'';  // '
            ch = '\"';  // "
            ch = '\\';  // \
        }
        
        public static void Возможности_консольного_вывода()
        {
            Console.WriteLine("Hello");
            //
            string name = "Dolly";
            Console.WriteLine("Hello {0}", name);
            //
            Console.WriteLine("Деление 10/3 даёт: " + 10 / 3);
            //
            float res = 10 / 3;
            Console.WriteLine("Деление 10/3 даёт: {0,15}", res); // 15 - минимальная ширина поля
            //
            Console.WriteLine("Деление 10/3 даёт: {0:#.##} результат", res); // выводит два знака после запятой
        }

        void Приведение_типов()
        {
            int i = 5;
            double d = i;   // автоматическое преобразование типов
            i = (int) d;    // явное приведение типов
        }
    }
}
