using System;

namespace ConsoleAppDemo
{
    internal class Chapter_5
    {
        void If()
        {
            var a = 5;
            var b = 10;
            int c;

            if (a > b)
            {
                c = a;
            }
            else if ( a < b)
            {
                c = b;
            }
            else
            {
                c = 0;
            }
        }

        void Switch()
        {
            var name = "Bill";

            switch(name) // string, char, int 
            {
                case "Alice":
                    Console.Write("Hello Alice");
                    break;
                case "Bob":
                case "Robert":
                    Console.Write("Hello Robert");
                    break;
                default:
                    Console.Write("Hello friend");
                    break;
            }
        }

        void Циклы()
        {
            for (var i = 0; i < 10; i++) {
                if (i % 2 == 0)
                    continue;
                if (i == 8)
                    break;
            }
            //
            var a = 0;
            while (a < 10) { a++; }
            //
            do
            {
                a++;
            }
            while (a < 10);
            //
            int[] array = new int[10];
            foreach (var i in array)
            {
                a += i;
            }
        }
    }
}
