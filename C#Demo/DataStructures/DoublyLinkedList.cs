// Двусвязный список.
// See https://metanit.com/sharp/algoritm/2.2.php for more information

using System.Collections;

namespace C_Demo.DataStructures
{
    internal class DoublyLinkedListDemo
    {
        public static void Show()
        {
            DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>
            {
                "Tom",
                "Alice",
                "Bob",
                "Sam"
            };

            // выводим элементы
            foreach (var item in linkedList) Console.WriteLine(item);

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

            // перебор с последнего элемента
            foreach (var item in linkedList.BackEnumerator()) Console.WriteLine(item);
        }
    }

    class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public DoublyNode<T>? Next { get; set; }

        public DoublyNode<T>? Previous { get; set; }
    }

    class DoublyLinkedList<T> : IEnumerable<T>
    {
        DoublyNode<T>? _head; // головной (первый) элемент
        DoublyNode<T>? _tail; // хвостовой (последний) элемент

        int _count = 0; // количество элементов в списке

        #region IEnumerable

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

        #endregion IEnumerable

        public int Count => _count;

        public bool IsEmpty => _head == null;

        /// <summary>
        /// Добавление элемента
        /// </summary>
        public void Add(T data)
        {
            var node = new DoublyNode<T>(data);

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail!.Next = node;
                node.Previous = _tail;
            }
            _tail = node;
            _count++;
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        public bool Remove(T data)
        {
            DoublyNode<T>? current = _head;

            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }

            if (current == null) // Узел не найден
            {
                return false;
            }

            // Eсли узел в середине или в конце
            if (current.Previous != null)
            {
                // убираем узел current, теперь previous ссылается не на current, а на current.Next
                current.Previous.Next = current.Next;
                // Если current.Next не установлен, значит узел последний,
                // изменяем переменную _tail
                if (current.Next == null)
                {
                    _tail = current.Previous;
                }
                else
                {
                    current.Next.Previous = current.Previous;
                }
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

        /// <summary>
        /// Добавить данные в начало списка
        /// </summary>
        public void AppendFirst(T data)
        {
            var node = new DoublyNode<T>(data);

            node.Next = _head;
            if (_head != null)
            {
                _head.Previous = node;
            }
            else
            {
                _tail = node;
            }
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

        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T>? current = _tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}
