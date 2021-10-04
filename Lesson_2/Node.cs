using System;

namespace Lesson_2
{
    public class Node : ILinkedList
    {
        public int Data { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        Node startNode = null;
        Node lastNode = null;
        public void AddNode(int value)
        {
            var newNode = new Node { Data = value };

            if (startNode == null)
            {
                startNode = newNode;
                startNode.NextNode = startNode;
                startNode.PrevNode = null;
            }
            else
            {
                if (lastNode == null)
                {
                    lastNode = newNode;
                    lastNode.PrevNode = startNode;
                    startNode.NextNode = lastNode;
                }
                else
                {
                    lastNode.NextNode = newNode;
                    newNode.PrevNode = lastNode;
                    lastNode = newNode;
                }
            }
        }
        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Data = value };

            newNode.NextNode = node.NextNode;
            node.NextNode.PrevNode = newNode;
            node.NextNode = newNode;
            newNode.PrevNode = node;
        }

        public Node FindNode(Node node, int searchValue)
        {
            var currentnode = node.startNode;

            while (currentnode != null)
            {
                if (currentnode.Data == searchValue)
                {
                    return currentnode;
                }
                else
                {
                    currentnode = currentnode.NextNode;
                }
            }
            return null;
        }

        public int GetCount(Node node)
        {
            int count = 0;

            var currentnode = node.startNode;

            while (currentnode != null)
            {
                count++;
                currentnode = currentnode.NextNode;
            }
            Print(count.ToString());
            Console.WriteLine();
            return count;
        }
        public Node RemoveNodebyIndex(Node node, int index)
        {
            if (index == 0) 
            {
                var newStartNode = startNode.NextNode;
                startNode.NextNode = null;
                return newStartNode;
            }

            int currentIndex = 0;
            var currentNode = startNode;
            while (currentNode != null)
            {
                if (currentIndex == index - 1)
                {
                    RemoveNode(currentNode);
                    return startNode;
                }

                currentNode = currentNode.NextNode;
                currentIndex++;
            }
            return startNode;
        }

        public void RemoveNode(Node node)
        {


            if(node.NextNode != null && node.PrevNode != null)
            {
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }            
            else
            {
                if(node.PrevNode != null)
                {
                    lastNode = node.PrevNode;
                    node.PrevNode.NextNode = null;                   
                }
                else
                {
                    startNode = node.NextNode;
                    node.NextNode.PrevNode = null;
                    node.NextNode = null;                   
                }                                                 
            }
        }
        public static  void Print<T> (T str)
        {
            if (str != null)
            {
                Console.Write(str);
            }
        }

        public static void PrintNode(Node node)
        {
            if (node.startNode == null)
            {
                Print("Node is empty");
            }
            else
            {
                var currentnode = node.startNode;

                while (currentnode != null)
                {
                    Print(currentnode.Data.ToString());
                    currentnode = currentnode.NextNode;
                }
                Console.WriteLine();

                currentnode = node.lastNode;

                while (currentnode != null)
                {
                    Print(currentnode.Data.ToString());
                    currentnode = currentnode.PrevNode;
                }
                Console.WriteLine();
            }
        }
    }


    public interface ILinkedList
    {
        int GetCount(Node node); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        Node RemoveNodebyIndex(Node node,int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(Node node, int searchValue); // ищет элемент по его значению
    }

}
