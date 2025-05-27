// Стек на основе массива
// https://metanit.com/sharp/algoritm/2.3.php

namespace C_Demo.DataStructures
{
    internal class StackDemo
    {
        public void Show()
        {
            var stack = new Stack<string>();

            stack.Push("Alice");
            stack.Push("Bob");
            stack.Push("Eva");

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
        }
    }

    public class Stack<T>
    {
        private const int DefaultSize = 8;

        private T[] _items;
        private int _count;

        public Stack()
        {
            _items = new T[DefaultSize];
        }

        public void Push(T data)
        {
            if (_count == _items.Length)
                Resize(_items.Length * 2);

            _items[_count++] = data;
        }

        public T Pop()
        {
            if (_count == 0)
                new InvalidOperationException("Стек пуст.");

            var data = _items[--_count];
            _items[_count] = default;

            if (_items.Length > 8 && _count < _items.Length / 2)
                Resize(_items.Length / 2);
            return data;
        }

        public T Peek()
        {
            if (_count == 0)
                new InvalidOperationException("Стек пуст.");

            return _items[_count - 1];
        }

        private void Resize(int n)
        {
            var temp = new T[n];

            for (int i = 0; i < _count; i++)
            {
                temp[i] = _items[i];
            }

            _items = temp;
        }

        public bool IsEmpty
        {
            get
            {
                return _count == 0;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }
    }
}
