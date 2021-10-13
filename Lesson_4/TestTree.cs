using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    class TestTree
    {
        public static void TestTreeNode()
        {
            TreeNode parent = new TreeNode();
            //Добавляем четыре элемента
            parent.AddItem(6);
            parent.AddItem(2); 
            parent.AddItem(3);
            parent.AddItem(11);
            parent.AddItem(9);
            parent.AddItem(30);
            //Вывод дерева           
            parent.PrintTree(parent);
            Console.WriteLine();
            //Поиск элемента дерева по значению
            TreeNode search = parent.GetNodeByValue(2);
            //Вывод элемента дерева
            parent.PrintTree(search);
            Console.WriteLine();
            //Найдем элемент дерева по значению и удалим его
            parent.RemoveItem(6);
            //Вывод нового сформированного списка
            parent.PrintTree(parent);
            Console.WriteLine();
        }
    }
}
