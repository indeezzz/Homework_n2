using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    class  TestNode
    {
        public static void TestListNode ()
        {
            Node node = new Node();
            //Добавляем четыре элемента в список
            node.AddNode(1);
            node.AddNode(2);
            node.AddNode(3);
            node.AddNode(4);
            //Вывод элементов списка с начального по конечный и наоборот
            Node.PrintNode(node);
            //Поиск элемента списка по значению
            Node searchNode = node.FindNode(node, 3);
            //Добавление элемента после найденой ноды
            node.AddNodeAfter(searchNode, 5);
            //Вывод нового сформированного списка
            Node.PrintNode(node);
            //Вывод количества элементов списка
            node.GetCount(node);
            //Нойдем ноду по значению и удалим ее
            searchNode = node.FindNode(node, 5);
            node.RemoveNode(searchNode);
            //Вывод нового сформированного списка
            Node.PrintNode(node);
            //Удаление элемента списка по индексу
            node.RemoveNodebyIndex(node, 2);
            //Вывод нового сформированного списка
            Node.PrintNode(node);
        }        
    }
}
