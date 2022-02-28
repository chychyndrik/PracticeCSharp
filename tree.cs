using System;
using System.IO;
using System.Collections.Generic;
namespace _1_1
{
    public class BinaryTree //класс, реализующий АТД «дерево бинарного поиска»
    {
        //вложенный класс, отвечающий за узлы и операции допустимы для дерева бинарного
        //поиска
        private class Node
        {
            public object inf; //информационное поле
            public Node left; //ссылка на левое поддерево
            public Node rigth; //ссылка на правое поддерево
                               //конструктор вложенного класса, создает узел дерева
            public Node(object nodeInf)
            {
                inf = nodeInf;
                left = null;
                rigth = null;
            }
            //добавляет узел в дерево так, чтобы дерево оставалось деревом бинарного поиска
            public static void Add(ref Node r, object nodeInf)
            {
                if (r == null)
                {
                    r = new Node(nodeInf);
                }
                else
                {
                if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                    {
                        Add(ref r.left, nodeInf);
                    }
                    else
                    {
                        Add(ref r.rigth, nodeInf);
                    }
                }
            }
            public static void Preorder(Node r) //прямой обход дерева
            {
                if (r != null)
                {
                    Console.Write("{0} ", r.inf);
                    Preorder(r.left);
                    Preorder(r.rigth);
                }
            }
            public static void Inorder(Node r) //симметричный обход дерева
            {
                if (r != null)
                {
                    Inorder(r.left);
                    Console.Write("{0} ", r.inf);
                    Inorder(r.rigth);
                }
            }


            //------------------------------------------------------------------------------
            public static void InorderL(Node r, ref List<int> lis) //Запись массива в лист симметричным обходом
            {
                if (r != null)
                {
                    InorderL(r.left, ref lis);

                    lis.Add(Convert.ToInt32(r.inf));

                    InorderL(r.rigth, ref lis);
                }
                
            }
            //------------------------------------------------------------------------------


            public static void Postorder(Node r) //обратный обход дерева
            {
                if (r != null)
                {
                    Postorder(r.left);
                    Postorder(r.rigth);
                    Console.Write("{0} ", r.inf);
                }
            }
            //поиск ключевого узла в дереве
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
            }
            //методы Del и Delete позволяют удалить узел в дереве так, чтобы дерево при этом
            //оставалось деревом бинарного поиска
            private static void Del(Node t, ref Node tr)
            {
                if (tr.rigth != null)
                {
                    Del(t, ref tr.rigth);
                }
                else
                {
                    t.inf = tr.inf;
                    tr = tr.left;
                }
            }
            public static void Delete(ref Node t, object key)
            {
                if (t == null)
                {
                    throw new Exception("Данное значение в дереве отсутствует");
                }
                else
                {
                    if (((IComparable)(t.inf)).CompareTo(key) > 0)
                    {
                        Delete(ref t.left, key);
                    }
                    else
                    {
                        if (((IComparable)(t.inf)).CompareTo(key) < 0)
                        {
                            Delete(ref t.rigth, key);
                        }
                        else
                        {
                            if (t.left == null)
                            {
                                t = t.rigth;
                            }
                            else
                            {
                            if (t.rigth == null)
                                {
                                    t = t.left;
                                }
                                else
                                {
                                    Del(t, ref t.left);
                                }
                            }
                        }
                    }
                }
            }

            /*
            public static bool operator ==(Node N1, Node N2)
            {
                if ((N1.left.inf == N2.left.inf) && (N1.rigth.inf == N2.rigth.inf))
                    return true;
                else
                    return false;
            }
            public static bool operator !=(Node N1, Node N2)
            {
                if (!((N1.left.inf == N2.left.inf) && (N1.rigth.inf == N2.rigth.inf)))
                    return true;
                else
                    return false;
            }
            */

        } //конец вложенного класса
        Node tree; //ссылка на корень дерева
                   //свойство позволяет получить доступ к значению информационного поля корня дерева
        public object Inf
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }
        public BinaryTree() //открытый конструктор
        {
            tree = null;
        }
        private BinaryTree(Node r) //закрытый конструктор
        {
            tree = r;
        }
        public void Add(object nodeInf) //добавление узла в дерево
        {
            Node.Add(ref tree, nodeInf);
        }
        //организация различных способов обхода дерева
        public void Preorder()
        {
            Node.Preorder(tree);
        }
        public void Inorder()
        {
            Node.Inorder(tree);
        }

        //------------------------------------------------------------------------------
        public void InorderL(ref List<int> lis)
        {
            Node.InorderL(tree, ref lis);
        }
        //------------------------------------------------------------------------------

        public void Postorder()
        {
            Node.Postorder(tree);
        }
        //поиск ключевого узла в дереве
        public BinaryTree Search(object key)
        {
            Node r;
            Node.Search(tree, key, out r);
            BinaryTree t = new BinaryTree(r);
            return t;
        }
        //удаление ключевого узла в дереве
        public void Delete(object key)
        {
            Node.Delete(ref tree, key);
        }

    }
}
