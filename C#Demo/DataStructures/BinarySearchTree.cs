// Бинарное дерево поиска
namespace C_Demo.DataStructures
{
    internal class Demo_BinarySearchTree
    {
        public static void Show()
        {
            var binaryTree = new BinaryTree<int>();

            binaryTree.Add(8);
            binaryTree.Add(3);
            //binaryTree.Add(10);
            binaryTree.Add(1);
            binaryTree.Add(6);
            binaryTree.Add(4);
            binaryTree.Add(7);
            //binaryTree.Add(14);
            //binaryTree.Add(16);

            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(3);
            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(8);
            binaryTree.PrintTree();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// Сторона дочернего узла
    /// </summary>
    internal enum Side
    {
        Left, Right
    }

    /// <summary>
    /// Узел бинарного дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class BinaryTreeNode<T> where T : IComparable
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="data">Хранимые данные</param>
        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public BinaryTreeNode<T> Parent { get; set; }

        public BinaryTreeNode<T> LeftChild { get; set; }

        public BinaryTreeNode<T> RightChild { get; set; }

        public Side? NodeSide
        {
            get
            {
                return Parent == null
                    ? null
                    : Parent.LeftChild == this ? Side.Left : Side.Right;
            }
        }

        public override string? ToString() => Data.ToString();
    }

    /// <summary>
    /// Бинарное дерево поиска
    /// </summary>
    /// <typeparam name="T">Тип данных, хранящихся в узлах</typeparam>
    class BinaryTree<T> where T : IComparable
    {
        /// <summary>
        /// Корень бинарного дерева
        /// </summary>
        public BinaryTreeNode<T> RootNode { get; set; }

        /// <summary>
        /// Добавление нового узла в бинарное дерево
        /// </summary>
        /// <param name="node">Новый узел</param>
        /// <param name="currentNode">Текущий узел</param>
        /// <returns>Узел</returns>
        public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.Parent = null;
                RootNode = node;
                return node;
            }

            currentNode ??= RootNode;
            node.Parent = currentNode;

            var result = currentNode.Data.CompareTo(node.Data);

            if (result == 0)
                return currentNode;

            return (result > 0)
                ? (currentNode.LeftChild == null)
                    ? currentNode.LeftChild = node
                    : Add(node, currentNode.LeftChild)
                : (currentNode.RightChild == null)
                    ? currentNode.RightChild = node
                    : Add(node, currentNode.RightChild);
        }

        /// <summary>
        /// Добавление данных в бинарное дерево
        /// </summary>
        /// <param name="data">Данные</param>
        /// <returns>Узел</returns>
        public BinaryTreeNode<T> Add(T data)
        {
            return Add(new BinaryTreeNode<T>(data));
        }

        /// <summary>
        /// Поиск узла по значению
        /// </summary>
        /// <param name="data">Искомое значение</param>
        /// <param name="startWithNode">Узел начала поиска</param>
        /// <returns></returns>
        public BinaryTreeNode<T>? FindNode(T data, BinaryTreeNode<T> startWithNode = null)
        {
            startWithNode ??= RootNode;

            var result = startWithNode.Data.CompareTo(data);

            if (result == 0)
                return startWithNode;

            return result > 0
                ? startWithNode.LeftChild == null
                    ? null : FindNode(data, startWithNode.LeftChild)
                : startWithNode.RightChild == null
                    ? null : FindNode(data, startWithNode.RightChild);
        }

        /// <summary>
        /// Удаление узла бинарного дерева
        /// </summary>
        /// <param name="node">Узел для удаления</param>
        public void Remove(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;

            var currentNodeSide = node.NodeSide;

            // если у узла нет дочерних узлов, мы его просто удаляем.
            if (node.LeftChild == null && node.RightChild == null)
            {
                switch (node.NodeSide)
                {
                    case Side.Left:
                        node.Parent.LeftChild = null;
                        break;
                    case Side.Right:
                        node.Parent.RightChild = null;
                        break;
                    default:
                        RootNode = null;
                        break;
                }
            }
            // если у узла есть один дочерний, ставим его на место текущего
            if (node.RightChild == null)
            {
                switch (node.NodeSide)
                {
                    case Side.Left:
                        node.Parent.LeftChild = node.LeftChild;
                        node.LeftChild.Parent = node.Parent;
                        break;
                    case Side.Right:
                        node.Parent.RightChild = node.LeftChild;
                        node.LeftChild.Parent = node.Parent;
                        break;
                    default:
                        RootNode = node.LeftChild;
                        RootNode.Parent = null;
                        break;
                }
            }
            if (node.LeftChild == null)
            {
                switch (node.NodeSide)
                {
                    case Side.Left:
                        node.Parent.LeftChild = node.RightChild;
                        node.RightChild.Parent = node.Parent;
                        break;
                    case Side.Right:
                        node.Parent.RightChild = node.RightChild;
                        node.RightChild.Parent = node.Parent;
                        break;
                    default:
                        RootNode = node.RightChild;
                        RootNode.Parent = null;
                        break;
                }
            }
            // если у узла есть два дочерних. Ставим правый на место удаляемого, а левый добавляем в правый.
            switch (currentNodeSide)
            {
                case Side.Left:
                    node.Parent.LeftChild = node.RightChild;
                    node.RightChild.Parent = node.Parent;
                    Add(node.LeftChild, node.RightChild);
                    break;
                case Side.Right:
                    node.Parent.RightChild = node.RightChild;
                    node.RightChild.Parent = node.Parent;
                    Add(node.LeftChild, node.RightChild);
                    break;
                default:
                    //TODO кейсы, пустой левой и(или) правой ветки.
                    RootNode = node.RightChild;
                    RootNode.Parent = null;
                    Add(node.LeftChild, node.RightChild);
                    break;
            }
        }

        /// <summary>
        /// Удаление узла дерева
        /// </summary>
        /// <param name="data">Данные для удаления</param>
        public void Remove(T data)
        {
            var node = FindNode(data);
            Remove(node);
        }

        /// <summary>
        /// Вывод бинарного дерева
        /// </summary>
        public void PrintTree()
        {
            PrintTree(RootNode);
        }

        /// <summary>
        /// Вывод бинарного дерева начиная с указанного узла
        /// </summary>
        /// <param name="startNode">Узел с которого начинается печать</param>
        /// <param name="indent">Отступ</param>
        /// <param name="side">Сторона</param>
        private void PrintTree(BinaryTreeNode<T> startNode, string indent = "", Side? side = null)
        {
            if (startNode == null)
                return;

            var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
            Console.WriteLine($"{indent}[{nodeSide}] - {startNode.Data}");
            indent += new string(' ', 3);
            // рекурсивный вызов для левой и правой ветор
            PrintTree(startNode.LeftChild, indent, Side.Left);
            PrintTree(startNode.RightChild, indent, Side.Right);
        }
    }
}
