using System;
namespace PracticeCSharp
{
    public class AVLTree //класс, реализующий АВЛ-дерево
    {
        //вложенный класс, отвечающий за узлы и операции допустимы для АВЛ-дерева
        private class Node
        {
            public object inf; //информационное поле
            public int height; //разница высот узла
            public Node left; //ссылка на левое поддерево
            public Node rigth; //ссылка на правое поддерево

            //конструктор вложенного класса, создает узел дерева
            public Node(object nodeInf)
            {
                inf = nodeInf;
                height = 1;
                left = null;
                rigth = null;
            }

            //возвращает высоту узла, в том числе и пустого
            public int Height
            {
                get
                {
                    return (this != null) ? this.height : 0;
                }
            }//возвращает разницу высот правого и левого поддерева для заданного узла
            public int BalanceFactor
            {
                get
                {
                    int rh = (this.rigth != null) ? this.rigth.Height : 0;
                    int lh = (this.left != null) ? this.left.Height : 0;
                    return rh - lh;
                }
            }
            //пересчитывает высоту узла
            public void NewHeight()
            {
                int rh = (this.rigth != null) ? this.rigth.Height : 0;
                int lh = (this.left != null) ? this.left.Height : 0;
                this.height = ((rh > lh) ? rh : lh) + 1;
            }
            //правый поворот
            public static void RotationRigth(ref Node t)
            {
                Node x = t.left;
                t.left = x.rigth;
                x.rigth = t;
                t.NewHeight();
                x.NewHeight();
                t = x;
            }
            //левый поворот
            public static void RotationLeft(ref Node t)
            {
                Node x = t.rigth;
                t.rigth = x.left;
                x.left = t;
                t.NewHeight();
                x.NewHeight();
                t = x;
            }
            //балансировка
            public static void Rotation(ref Node t)
            {
                t.NewHeight();
                if (t.BalanceFactor == 2)
                {
                    if (t.rigth.BalanceFactor < 0)
                    {
                        RotationRigth(ref t.rigth);
                    }
                    RotationLeft(ref t);
                }
                if (t.BalanceFactor == -2)
                {
                    if (t.left.BalanceFactor > 0)
                    {
                        RotationLeft(ref t.left);
                    }
                    RotationRigth(ref t);
                }
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
                Rotation(ref r);
            }
            public static void Preorder(Node r) //прямой обход дерева
            {
                if (r != null)
                {
                    Console.Write("({0} {1}) ", r.inf, r.height);
                    Preorder(r.left);
                    Preorder(r.rigth);
                }
            }
            public static void Inorder(Node r) //симметричный обход дерева
            {
                if (r != null)
                {
                    Inorder(r.left);
                    Console.Write("({0} {1}) ", r.inf, r.height);
                    Inorder(r.rigth);
                }
            }
            public static void Postorder(Node r) //обратный обход дерева
            {
                if (r != null)
                {
                    Postorder(r.left);
                    Postorder(r.rigth);
                    Console.Write("({0} {1}) ", r.inf, r.height);
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
            //оставалось АВЛ-деревом
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
                    Console.WriteLine("Данное значение в дереве отсутствует");
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
                    Rotation(ref t);
                }
            }
        } //конец вложенного класса
        Node tree; //ссылка на корень дерева
                   //свойство позволяет получить доступ к значению информационного поля корня дерева
        public object Inf
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }
        public AVLTree() //открытый конструктор
        {
            tree = null;
        }
        private AVLTree(Node r) //закрытый конструктор
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
        public void Postorder()
        {
            Node.Postorder(tree);
        }
        //поиск ключевого узла в дереве
        public AVLTree Search(object key)
        {
            Node r;
            Node.Search(tree, key, out r);
            AVLTree t = new AVLTree(r);
            return t;
        }
        //удаление ключевого узла в дереве
        public void Delete(object key)
        {
            Node.Delete(ref tree, key);
        }
    }
}
