// Связный список.
// See https://metanit.com/sharp/algoritm/2.1.php for more information

using System.Collections;

namespace C_Demo.DataStructures
{
    internal class Demo
    {
        public void Show()
        {
            LinkedList<string> linkedList = new LinkedList<string>
            {
                // добавление элементов
                "Tom",
                "Alice",
                "Bob",
                "Sam"
            };

            // выводим элементы
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            // удаляем элемент
            linkedList.Remove("Alice");
            Console.WriteLine("\nПосле удаления Alice");
            foreach (var item in linkedList) Console.WriteLine(item);

            // проверяем наличие элемента
            bool isPresent = linkedList.Contains("Sam");
            Console.WriteLine(isPresent ? "Sam присутствует" : "Sam отсутствует");

            // добавляем элемент в начало            
            linkedList.AppendFirst("Bill");
            Console.WriteLine("\nПосле добавления Billa");
            foreach (var item in linkedList) Console.WriteLine(item);
        }
    }

    class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Node<T>? Next { get; set; }
    }

    class LinkedList<T> : IEnumerable<T>
    {
        Node<T> _head; // головной (первый) элемент
        Node<T> _tail; // хвостовой (последний) элемент

        int _count = 0; // количество элементов в списке

        /// <summary>
        /// Добавление элемента
        /// </summary>
        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (_head == null)
                _head = node;
            else
                _tail!.Next = node;
            _tail = node;

            _count++;
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        public bool Remove(T data)
        {
            Node<T>? current = _head;
            Node<T>? previous = null;

            while (current != null && current.Data != null)
            {
                if (current.Data.Equals(data))
                {
                    // Eсли узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную _tail
                        if (current.Next == null)
                            _tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение _head
                        _head = current?.Next;

                        // если после удаления список пуст, сбрасываем _tail
                        if (_head == null)
                            _tail = null;
                    }

                    _count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Добавить данные в начало списка
        /// </summary>
        public void AppendFirst(T data)
        {
            var node = new Node<T>(data);

            node.Next = _head;
            _head = node;
        }

        /// <summary>
        /// Проверка наличия данных
        /// </summary>
        public bool Contains(T data)
        {
            var current = _head;

            while (current != null && current.Data != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
            }

            return false;
        }

        // Очистка списка
        public void Clean()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public int Count { get { return _count; } }

        public bool IsEmpty
        {
            get { return _head == null; }
        }

        #region Implement if IEnumerable

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Data;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        #endregion Implement if IEnumerable
    }
}
