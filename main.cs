using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// проверить, можно ли удалить не более n узлов в дереве так, чтобы дерево осталось
// деревом бинарного поиска и стало идеально сбалансированным (указать допустимые
// значения удаляемых узлов).

namespace PracticeCSharp
{
    internal class main
    {
        static List<int> Input(string path = "input.txt")
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
                        //Console.WriteLine(Convert.ToInt32(numArr[i]));
                        list.Add(Convert.ToInt32(numArr[i]));
                    }
                }
            }
            return list;
        }
        static void Main()
        {
            List<int> inputList = Input(@"D:\Projects\PracticeCSharp\input.txt");
            BinaryTree tree = new BinaryTree();
            for (int i = 0; i < inputList.Count; i++)
            {
                tree.Add(inputList[i]);
            }
            tree.Set_height();
            tree.Preorder();
            Console.Write("\nВведите n:");
            int n = Convert.ToInt32(Console.ReadLine());
            tree.Func(n);
            Console.ReadKey();
        }
    }
}
