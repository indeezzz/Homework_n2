using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    public class TreeNode : ITree
    {
        public int? Value { get; set; }
        public TreeNode LeftChildNode { get; set; }
        public TreeNode RightChildNode { get; set; }
        public TreeNode ParentNode { get; set; }

        public void AddItem(int value)
        {
            if (Value == null || Value == value)
            {
                Value = value;
                return;
            }
            if (Value > value)
            {
                if (LeftChildNode == null)
                {
                    LeftChildNode = new TreeNode();
                }
                AddItem(value, LeftChildNode, this);
            }
            else
            {
                if (RightChildNode == null)
                {
                    RightChildNode = new TreeNode();
                }
                AddItem(value, RightChildNode, this);
            }
        }
        public void AddItem(int value, TreeNode node, TreeNode parent)
        {
            if (node.Value == null || node.Value == value)
            {
                node.Value = value;
                node.ParentNode = parent;
                return;
            }
            if (node.Value > value)
            {
                if (node.LeftChildNode == null) node.LeftChildNode = new TreeNode();
                AddItem(value, node.LeftChildNode, node);
            }
            else
            {
                if (node.RightChildNode == null) node.RightChildNode = new TreeNode();
                AddItem(value, node.RightChildNode, node);
            }
        }
        public TreeNode GetNodeByValue(int value)
        {
            if (Value == value) return this;
            if (Value > value)
            {
                return GetNodeByValue(value, LeftChildNode);
            }
            return GetNodeByValue(value, RightChildNode);
        }
        public TreeNode GetNodeByValue(int value, TreeNode parent)
        {
            if (parent == null || value == parent.Value)
            {
                return parent;
            }                
            else if (parent.Value < value)
            {
                return GetNodeByValue(value, parent.RightChildNode);
                
            }                
            else
            {
                return GetNodeByValue(value, parent.LeftChildNode);
            }

        }
        public void PrintTree(TreeNode parent, string s = "")
        {
            if (parent != null )
            {
                Console.Write(parent.Value);
                if (parent.LeftChildNode != null || parent.RightChildNode != null)
                {
                    Console.Write("(");
                    if (parent.LeftChildNode != null) PrintTree(parent.LeftChildNode);
                    else Console.Write("NIL");
                    Console.Write(",");
                    if (parent.RightChildNode != null) PrintTree(parent.RightChildNode);
                    else Console.Write("NIL");
                    Console.Write(")");
                }
            }
        }

        public bool RemoveItem(int value)
        {
            TreeNode tree = GetNodeByValue(value);
            if (tree == null)
            {
                //Если узла не существует, вернем false
                return false;
            }
            TreeNode currentTree;

            //Если удаляем корень
            if (tree == this)
            {
                if (tree.LeftChildNode != null)
                {
                    currentTree = tree.LeftChildNode;                   
                }
                else
                {
                    currentTree = tree.RightChildNode;
                }

                while (currentTree.LeftChildNode != null)
                {
                    currentTree = currentTree.LeftChildNode;
                }
                int temp = (int)currentTree.Value;
                this.RemoveItem(temp);
                tree.Value = temp;

                return true;
            }

            //Удаление листьев
            if (tree.LeftChildNode == null && tree.RightChildNode == null && tree.ParentNode != null)
            {
                if (tree == tree.ParentNode.LeftChildNode)
                {
                    tree.ParentNode.LeftChildNode = null;
                }
                else
                {
                    tree.ParentNode.RightChildNode = null;
                }
                return true;
            }

            //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            if (tree.LeftChildNode != null && tree.RightChildNode == null)
            {
                //Меняем родителя
                tree.LeftChildNode.ParentNode = tree.ParentNode;
                if (tree == tree.ParentNode.LeftChildNode)
                {
                    tree.ParentNode.LeftChildNode = tree.LeftChildNode;
                }
                else if (tree == tree.ParentNode.RightChildNode)
                {
                    tree.ParentNode.RightChildNode = tree.LeftChildNode;
                }
                return true;
            }

            //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if (tree.LeftChildNode == null && tree.RightChildNode != null)
            {
                //Меняем родителя
                tree.RightChildNode.ParentNode = tree.ParentNode;
                if (tree == tree.ParentNode.LeftChildNode)
                {
                    tree.ParentNode.LeftChildNode = tree.RightChildNode;
                }
                else if (tree == tree.ParentNode.RightChildNode)
                {
                    tree.ParentNode.RightChildNode = tree.RightChildNode;
                }
                return true;
            }

            //Удаляем узел, имеющий поддеревья с обеих сторон
            if (tree.RightChildNode != null && tree.LeftChildNode != null)
            {
                currentTree = tree.RightChildNode;

                while (currentTree.LeftChildNode != null)
                {
                    currentTree = currentTree.LeftChildNode;
                }

                //Если самый левый элемент является первым потомком
                if (currentTree.ParentNode == tree)
                {
                    currentTree.LeftChildNode = tree.LeftChildNode;
                    tree.LeftChildNode.ParentNode = currentTree;
                    currentTree.ParentNode = tree.ParentNode;
                    if (tree == tree.ParentNode.LeftChildNode)
                    {
                        tree.ParentNode.LeftChildNode = currentTree;
                    }
                    else if (tree == tree.ParentNode.RightChildNode)
                    {
                        tree.ParentNode.RightChildNode = currentTree;
                    }
                    return true;
                }
                //Если самый левый элемент НЕ является первым потомком
                else
                {
                    if (currentTree.RightChildNode != null)
                    {
                        currentTree.RightChildNode.ParentNode = currentTree.ParentNode;
                    }
                    currentTree.ParentNode.LeftChildNode = currentTree.RightChildNode;
                    currentTree.RightChildNode = tree.RightChildNode;
                    currentTree.LeftChildNode = tree.LeftChildNode;
                    tree.LeftChildNode.ParentNode = currentTree;
                    tree.RightChildNode.ParentNode = currentTree;
                    currentTree.ParentNode = tree.ParentNode;
                    if (tree == tree.ParentNode.LeftChildNode)
                    {
                        tree.ParentNode.LeftChildNode = currentTree;
                    }
                    else if (tree == tree.ParentNode.RightChildNode)
                    {
                        tree.ParentNode.RightChildNode = currentTree;
                    }

                    return true;
                }
            }
            return false;
        }
    }

    public interface ITree
    {
        void AddItem(int value); // добавить узел
        void AddItem(int value, TreeNode node, TreeNode parent); // добавить узел
        bool RemoveItem(int value); // удалить узел по значению

        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        TreeNode GetNodeByValue(int value, TreeNode parent); //получить узел дерева по значению
        void PrintTree(TreeNode parent, string s = ""); //вывести дерево в консоль
    }
}
