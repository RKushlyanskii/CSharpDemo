// Классы, объекты и методы.
namespace ConsoleAppDemo
{
    internal class Chapter_6
    {
    }

    class Модификаторы_доступа
    {
        public int a;
        protected int b;
        private int c;
        internal int d;
        static private int e;
        readonly private int f;
        static readonly private int g;
        const int h = 10;
    }

    class Конструкторы
    {
        int a;
        int b;

        public Конструкторы() { } // Конструктор без параметров

        public Конструкторы(int a) // Конструктор с параметром
        {
            this.a = a;
        }

        public Конструкторы(int a, int b) : this(a) // Вызов одним конструктором другого
        {
            this.b = b;
        }

        ~Конструкторы() // Деструктор (отсутствует возвращаемый тип и параметры)
        {
            // ...
        }
    }

    class Методы
    {
        public int DoSomething(int a, float f) // Параметры
        {
            return 5;
        }

        public int Модификаторы_парметров(ref int a, out int b)
        {
            b = 5; // Значение обязательно нужно присвоить
            return 10;
        }

        public void Переменное_число_аргументов(params int[] arg)
        {

        }

        public void Test()
        {
            var foo = new Методы();
            var foo_2 = new Методы();
            foo.DoSomething(5, 3.14f); // Аргументы

            int x = 5; // значение обязательно должно быть
            int y;
            foo.Модификаторы_парметров(ref x, out y);

            int[] array = { 3, 4, 5 };

            Переменное_число_аргументов();
            Переменное_число_аргументов(5);
            Переменное_число_аргументов(5,7);
            Переменное_число_аргументов(array);
        }
    }

    class Инициализаторы_объектов
    {
        public int A { get; set; }
        public string B { get; set; }

        public void Test()
        {
            Инициализаторы_объектов x = new Инициализаторы_объектов 
            { 
                A = 5, 
                B = "foo" 
            };
        }
    }
}
