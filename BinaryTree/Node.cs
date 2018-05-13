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
            if (childNode.Key.CompareTo(this.Key) > 0)
            {
                //child node key is greater than this key
                if (RightChildNode is null)
                {
                    RightChildNode = childNode;
                }

                RightChildNode.AddChild(childNode);

            }else if (childNode.Key.CompareTo(this.Key) < 0)
            {
                //child node key is lesser than this key
                if (LeftChildNode is null)
                {
                    LeftChildNode = childNode;
                }

                LeftChildNode.AddChild(childNode);
            }
            else
            {
                //child node key is equal to this key 
                //do nothing
                return;
            }
        }
    }
}
