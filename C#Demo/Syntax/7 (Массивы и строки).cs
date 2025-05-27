using System;

namespace ConsoleAppDemo
{
    internal class Chapter_7
    {
        void ArrayDemo()
        {
            int[] array_1;
            array_1 = new int[10];
            array_1[0] = 1;

            int[] array_2 = new int[10];
            int[] array_3 = new int[3] { 1, 2, 3 };
            int[] array_4 = new int[] { 1, 2, 3 };
            int[] array_5 = { 1, 2, 3 };

            int[,] doubleArray =                // Двумерный массив
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,8 }
            };
            int[,,] array_7 = new int[10, 10, 10];

            int[][] array_8 = new int[3][];     // Ступенчатые массивы (массив массивов)

            array_8[0] = new int[4];
            array_8[1] = new int [] { 1, 2 };

            int[][,] array_9 = new int[3][,];

            var array_10 = new[] { 1, 2, 3 };   // Неявно типизированный массив.

            var length = array_1.Length;        // Длина массива

        }

        void Строки()
        {
            string str_1 = "Hello Dolly";
            string test = string.Empty;

            test = str_1.ToUpper();
            test = str_1.ToLower();
            test = str_1.Substring(6);

            string[] array = { "Alise", "Bob", "Eva" };
            string list = string.Join(", ", array); // Объединение строк
        }
    }
}
