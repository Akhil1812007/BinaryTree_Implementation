using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_Implementation
{
    public  class BinaryTreeNode<T>
    {
        internal T data;
        internal BinaryTreeNode<T> left;
        internal BinaryTreeNode<T> right;

        public BinaryTreeNode(T data)
        {
            this.data = data;
        }
    }
}
