using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1.Classes
{
    class main
    {
        static List<int> Input(string path = @"F:\Programs\ConsoleApp1\input.txt")
        {
            var list = new List<int>();
            char[] sp = { ' ', ',', '!', '.', '?' };
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string numbers = sr.ReadLine();
                    string[] numArr = numbers.Split(sp, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < numArr.Length; i++)
                    {
                        Console.WriteLine(Convert.ToInt32(numArr[i]));
                        list.Add(Convert.ToInt32(numArr[i]));
                    }
                }
            }
            return list;
        }
        static void Main()
        {
            BinaryTree tree = new BinaryTree();
            tree.root1 = new BinaryTree.Node(26);

            tree.root1.rigth = new BinaryTree.Node(3);

            tree.root1.rigth.rigth = new BinaryTree.Node(3);

            tree.root1.left = new BinaryTree.Node(10);

            tree.root1.left.left = new BinaryTree.Node(4);

            tree.root1.left.left.rigth = new BinaryTree.Node(30);

            tree.root1.left.rigth = new BinaryTree.Node(6);
            tree.root2 = new BinaryTree.Node(10);

            tree.root2.rigth = new BinaryTree.Node(6);

            tree.root2.left = new BinaryTree.Node(4);

            tree.root2.left.rigth = new BinaryTree.Node(30);



            if (tree.isSubtree(tree.root1, tree.root2))

                Console.WriteLine("Tree 2 is subtree of Tree 1 ");
            else
                Console.WriteLine("Tree 2 is not a subtree of Tree 1");

            Console.ReadKey();

        }

    }
}
