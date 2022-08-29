using System;
using System.Collections.Generic;

namespace BinaryTree_Implementation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BinaryTreeNode<int> root = takeTreeInputBetter(true, 0, true);
            PrintTree(root);
        }
        public static void PrintTree(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return;
            }
            Console.Write(root.data + ":");
            if (root.left != null)
            {
                Console.Write("L" + root.left.data + ", ");
            }
            if (root.right != null)
            {
                Console.Write("R" + root.right.data);
            }
            Console.WriteLine();
            PrintTree(root.left);
            PrintTree(root.right);

        }
        //NOT A GOOD METHOD AS THE USER WILL BE UNABLE TO TRACE THE PARENT CHILD RELATIONSHIP
        public static BinaryTreeNode<int> takeTreeInput()
        {
            Console.WriteLine("Enter root data");
            int rootData = Convert.ToInt32(Console.ReadLine());

            if (rootData == -1)
            {
                return null;
            }

            BinaryTreeNode<int> root = new BinaryTreeNode<int>(rootData);
            BinaryTreeNode<int> leftChild = takeTreeInput();
            BinaryTreeNode<int> rightChild = takeTreeInput();
            root.left = leftChild;
            root.right = rightChild;
            return root;

        }
        // IMPROVED METHOD TO TAKE INPUT FROM THE USER AS THE USER WILL HAVE TRACE OF RELATIONSHIP BETWEEN PARENT AND CHILD
        public static BinaryTreeNode<int> takeTreeInputBetter(bool isRoot, int parentData, bool isLeft)
        {
            if (isRoot)
            {
                Console.WriteLine("Enter root data");
            }
            else
            {
                if (isLeft)
                {
                    Console.WriteLine("Enter left child of " + parentData);
                }
                else
                {
                    Console.WriteLine("Enter right child of" + parentData);
                }
            }
            Console.WriteLine("Enter root data");
            int rootData = Convert.ToInt32(Console.ReadLine());

            if (rootData == -1)
            {
                return null;
            }

            BinaryTreeNode<int> root = new BinaryTreeNode<int>(rootData);
            BinaryTreeNode<int> leftChild = takeTreeInputBetter(false, rootData, true);//takeTreeInputBetter(ROOT,ROOTDATA,ISLEFT)
            BinaryTreeNode<int> rightChild = takeTreeInputBetter(false, rootData, false);
            root.left = leftChild;
            root.right = rightChild;
            return root;

        }
        //TO FIND NUMBER OF NODES
        public static int numNodes(BinaryTreeNode<int> root)
        {
            if (root == null) return 0;
            int leftNodeCount = numNodes(root.left);
            int rightNodeCount = numNodes(root.right);
            return 1 + leftNodeCount + rightNodeCount;
        }
        //PREORDER TRAVERSAL-- PARENT ROOT-->LEFT CHILD-->RIGHT CHILD
        public static void preOrder(BinaryTreeNode<int> root)
        {
            if (root == null)
            {

                return;
            }
            Console.WriteLine(root.data + " ");
            preOrder(root.left);
            preOrder(root.right);
        }
        //POST ORDER TRAVERSAL--LEFT CHILD-->RIGHT CHILD-->PARENT CHILD
        public static void postOrder(BinaryTreeNode<int> root)
        {
            if (root == null)
            {

                return;
            }

            postOrder(root.left);
            postOrder(root.right);
            Console.WriteLine(root.data + " ");
        }
        //INORDER TRAVERSAL--LEFT CHILD-->PARENT CHILD-->RIGHT CHILD
        public static void Inorder(BinaryTreeNode<int> root)
        {
            if (root == null)
            {

                return;
            }

            postOrder(root.left);
            Console.WriteLine(root.data + " ");

            postOrder(root.right);
        }
        //TO FIND THE HEIGHT OF THE TREE
        public static int height(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            int leftChildHeight = height(root.left);
            int rightChildHeight = height(root.right);
            if (leftChildHeight > rightChildHeight)
            {
                return 1 + leftChildHeight;
            }
            else
            {
                return 1 + rightChildHeight;
            }


        }
        // TRAVELLING FROM THE PARENT IN LEVEL MANNER 
        public static void LevelOrder(BinaryTreeNode<int> root)
        {
            Queue<BinaryTreeNode<int>> pendingNodes = new Queue<BinaryTreeNode<int>>();
            pendingNodes.Enqueue(root);
            pendingNodes.Enqueue(null);
            while(pendingNodes.Count > 0)
            {
                BinaryTreeNode<int> frontNode = pendingNodes.Dequeue();
                if(frontNode == null)
                {
                    Console.WriteLine();
                    if(pendingNodes.Count > 0)
                    {
                        pendingNodes.Enqueue(null);
                    }
                }
                else
                {
                    Console.WriteLine(frontNode.data+" ");
                    if(frontNode.left != null)
                    {
                        pendingNodes.Enqueue(frontNode.left);
                    }
                    if(frontNode.right != null)
                    {
                        pendingNodes.Enqueue(frontNode.right);
                    }
                }
            }
        }
    
    }
}
