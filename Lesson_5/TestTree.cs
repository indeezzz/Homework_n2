using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    class TestTree
    {
        public static void TestTreeNode()
        {
            Stopwatch sw = new Stopwatch();
            TreeNode parent = new TreeNode();
            //Добавляем  элементs в дерево
            parent.AddItem(6);
            parent.AddItem(2);
            parent.AddItem(3);
            parent.AddItem(11);
            parent.AddItem(9);
            parent.AddItem(30);
            parent.AddItem(45);
            parent.AddItem(50);
            parent.AddItem(100);
            parent.AddItem(64);
            parent.AddItem(32);
            parent.AddItem(55);

            parent.PrintTree(parent);
            
            Console.WriteLine();

            //Поиск элемента дерева по значению
            sw.Start();
            TreeNode searchValueDFS = parent.DFS_Search(64, parent);
            parent.PrintTree(searchValueDFS);
            Console.WriteLine();
            sw.Stop();
            Console.WriteLine("Застраченное время: {0}", sw.Elapsed);
            sw.Start();
            TreeNode searchValueBFS = parent.BFS_Search(64, parent);
            parent.PrintTree(searchValueBFS);
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Застраченное время: {0}", sw.Elapsed);
        }
    }
}
