using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeCSharp
{
    public class BinaryTree
    {
        private class Node {
            public object inf;
            public Node left;
            public Node rigth;
            public int height;

            public Node() {
                inf = null;
                left = null;
                rigth = null;
                height = 0;
            } //Пустой конструктор узла
            public Node(object NodeInf) {
                inf = NodeInf;
                left = null;
                rigth = null;
                height = 0;
            } //Конструктор дерева

            public static void Add(ref Node r, object NodeInf) {
                if (r == null) {
                    r = new Node(NodeInf);
                }
                else {
                    if (((IComparable)(r.inf)).CompareTo(NodeInf) > 0) {
                        Add(ref r.left, NodeInf);
                    }
                    else {
                        Add(ref r.rigth, NodeInf);
                    }
                }
            } //Добавить узел
            public static void Preorder(Node r) {
                if (r != null) {
                    Console.WriteLine("{0} ... {1}", r.inf, r.height);
                    Preorder(r.left);
                    Preorder(r.rigth);
                }
            } //Прямой обход дерева
            public static void Inorder(Node r)
            {
                if (r != null)
                {
                    Inorder(r.left);
                    Console.Write("{0} ", r.inf);
                    Inorder(r.rigth);
                }
            } //Симметричный обход дерева
            public static void Postorder(Node r)
            {
                if (r != null)
                {
                    Inorder(r.left);
                    Inorder(r.rigth);
                    Console.Write("{0} ", r.inf);
                }
            } //Обратный обход дерева
            public static void Search(Node r, object key, out Node item)
            {
                if (r == null)
                {
                    item = null;
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(key) == 0)
                    {
                        item = r;
                    }
                    else
                    {
                        if (((IComparable)(r.inf)).CompareTo(key) > 0)
                        {
                            Search(r.left, key, out item);
                        }
                        else
                        {
                            Search(r.rigth, key, out item);
                        }
                    }
                }

            } //Поиск узла в дереве
            private static void Del(Node t, ref Node tree) {
                if (tree.rigth != null) {
                    Del(t, ref tree.rigth);
                }
                else {
                    t.inf = tree.inf;
                    tree = tree.left;
                }
            } //Удаление листа
            public static void Delete(ref Node t, object key)
            {
                if (t == null) {
                    throw new Exception("Данное значение в дереве отсутствует");
                }
                else {
                    if (((IComparable)(t.inf)).CompareTo(key) > 0) {
                        Delete(ref t.left, key);
                    }
                    else {
                        if (((IComparable)(t.inf)).CompareTo(key) < 0) {
                            Delete(ref t.rigth, key);
                        }
                        else {
                            if (t.left == null) {
                                t = t.rigth;
                            }
                            else {
                                if (t.rigth == null) {
                                    t = t.left;
                                }
                                else {
                                    Del(t, ref t.left);
                                }
                            }
                        }
                    }
                }
            } //Подготовка к удалению
            public static void Set_height(Node r) {
                 if (r.left != null && r.rigth != null) {
                     Set_height(r.left);
                     Set_height(r.rigth);
                     
                     if (r.left.height > r.rigth.height)
                         r.height = r.left.height + 1;
                     else
                         r.height = r.rigth.height + 1;
                 }
                 else if (r.left == null && r.rigth == null) { }
                 else if (r.left == null) {
                     Set_height(r.rigth);
                     r.height = r.rigth.height + 1;
                 }
                 else if (r.rigth == null) {
                     Set_height(r.left);
                     r.height = r.left.height + 1;
                 }
            } //Определение высоты для каждого узла
            public static void GetCount(Node t, ref int count)
            {
                if (t != null)
                {
                    GetCount(t.left, ref count);
                    GetCount(t.rigth, ref count);
                    count++;
                }
            }
            public static void IsBalanced(Node t, ref bool isBalanced)
            {
                if (t != null)
                {
                    int count1 = 0;
                    GetCount(t.left, ref count1);
                    int count2 = 0;
                    GetCount(t.rigth, ref count2);
                    if (Math.Abs(count1 - count2) > 1)
                    {
                        isBalanced = false;
                    }
                    else
                    {
                        IsBalanced(t.left, ref isBalanced);
                        IsBalanced(t.rigth, ref isBalanced);
                    }
                }
            }
            public static object Search_largest(Node r) {
                if (r != null) {
                    if (r.left != null && r.rigth != null) {
                        if (r.left.height >= r.rigth.height)
                            return Search_largest(r.left);
                        else
                            return Search_largest(r.rigth);
                    }
                    else if (r.left == null && r.rigth == null)
                        return r.inf;
                    else if (r.left == null)
                        return Search_largest(r.rigth);
                    else
                        return Search_largest(r.left);
                }
                else return 0;
            } //Вспомогательная функция для поиска узла с наибольшей высотой
            public static void Search_double_errors(Node r, ref int errors, ref object inf) {
                if (r != null)
                {
                    Search_double_errors(r.left, ref errors, ref inf);
                    Search_double_errors(r.rigth, ref errors, ref inf);

                    if (r.left != null && r.rigth != null)
                        if (Math.Abs(r.left.height - r.rigth.height) > 1)
                            errors++;

                    if (errors == 1) 
                        inf = Search_largest(r);
                }
            } //Вспомогательная функция для обнаружения одной или более ошибок

            public static void Func(Node r, ref bool check, ref object inf_check, ref int n) {
                bool balance = true;
                IsBalanced(r, ref balance);
                int errors;
                if (balance == true) 
                {
                    check = false;
                } //Дерево сбалансированное изначально
                else
                {
                    int z = 0;
                    for (int i = 0; i < n; i++)
                    {
                        errors = 0;
                        balance = true;
                        Search_double_errors(r, ref errors, ref inf_check);
                        Delete(ref r, inf_check);
                        Set_height(r);
                        IsBalanced(r, ref balance);
                        if (balance)
                        {
                            z = i;
                            break;
                        }
                    }
                    n = z + 1;
                    balance = true;
                    IsBalanced(r, ref balance);

                    if (balance == true)
                    {
                        check = true;
                    }

                }
            } //Наша основная функция

        }

        Node Tree;
        

        public object Inf
        {
            set { Tree.inf = value; }
            get { return Tree.inf; }
        } //Доступ к значению корня

        public BinaryTree()
        {
            Tree = null;
        } //Пользовательский конструктор
        private BinaryTree(Node r)
        {
            Tree = r;
        } //Админский конструктор
        public void Add(object nodeInf)
        {
            Node.Add(ref Tree, nodeInf);
        } //Добавление узла в дерево
        public void Preorder() {
            Node.Preorder(Tree);
        } //Прямой обход дерева
        public void Inorder()
        {
            Node.Inorder(Tree);
        } //Симметричный обход дерева
        public void Postorder()
        {
            Node.Postorder(Tree);
        } //Обратный обход дерева
        public BinaryTree Search(object key)
        {
            Node r;
            Node.Search(Tree, key, out r);
            BinaryTree t = new BinaryTree(r);
            return t;
        } //Поиск узла в дереве
        public void Delete(object key) {
            Node.Delete(ref Tree, key);
        } //Удаление узла из дерева
        public void Set_height() {
            Node.Set_height(Tree);
        } //Определение высоты для каждого узла
        public void Func(int n) {
            bool check = false;
            object inf = 0;
            int z = n;
            Set_height();
            Node.Preorder(Tree);
            Node.Func(Tree, ref check, ref inf,  ref n);
            Console.WriteLine();
            Node.Preorder(Tree);
            if (check == true)
                Console.WriteLine("Удаление вoзможно.\nНужно удалить от " + n + " до " + z);
            else
                Console.WriteLine("Удаление невозможно или бессмысленно");
        } //Наша основная функция
        public bool IsBalanced()
        {
            bool isBalanced = true;
            Node.IsBalanced(Tree, ref isBalanced);
            return isBalanced;
        }
        public int GetCount()
        {
            int count = 0;
            Node.GetCount(Tree, ref count);
            return count;
        }
    }
}
