using System;
using System.IO;
using System.Collections.Generic;


namespace _1_1
{
    /*
    В файлах input1.txt и input2.txt хранится последовательности целых чисел.По файлу input1.txt построить дерево бинарного поиска А, по файлу input2.txt построить дерево бинарного поиска В.Проверить:
    является ли одно дерево поддеревом другого.
    */

    class Program
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
                        
                        list.Add(Convert.ToInt32(numArr[i]));
                    }
                }
            }
            return list;
        }

        static void Main(string[] args)
        {
            BinaryTree tree1 = new BinaryTree();
            BinaryTree tree2 = new BinaryTree();

            List<int> first, second;

            first = Input("input1.txt");
            second = Input("input2.txt");

            for (int i = 0; i < first.Count; i++)
            {
                tree1.Add(first[i]);
            }
            for (int i = 0; i < second.Count; i++)
            {
                tree2.Add(second[i]);
            }


            BinaryTree tree1_2 = tree1.Search(second[0]);

            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();


            tree1_2.InorderL(ref l1);
            tree2.InorderL(ref l2);


            for (int i = 0; i < l1.Count; i++)
            {
                Console.Write(l1[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < l2.Count; i++)
            {
                Console.Write(l2[i] + " ");
            }
            Console.WriteLine();




            if (l1.Count != l2.Count)
            {
                Console.WriteLine("no_1");
            }
            else
            {
                bool da = true;
                for (int i = 0; i < l1.Count; i++)
                {
                    if (l1[i] != l2[i])
                        da = false;
                }

                if (da)
                    Console.WriteLine("yes");
                else
                    Console.WriteLine("no_2");
            }

            

        }

    }
}
