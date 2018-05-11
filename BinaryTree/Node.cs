using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree.Interfaces;

namespace BinaryTree
{
    internal class Node<T>: INode<T> where T: IComparable<T>
    {
        public INode<T> RightChildNode { get; set; }
        public INode<T> LeftChildNode { get; set; }
        public T Key { get; set; }

        public Node(T key)
        {
            this.Key = key;
        }

        public void AddChild(INode<T> childNode)
        {
            throw new NotImplementedException();
        }
    }
}
