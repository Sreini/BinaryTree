using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree.Interfaces;

namespace BinaryTree
{
     public class Node<T>: INode<T> where T: IComparable<T>
    {
        public INode<T> RightChildNode { get; set; }
        public INode<T> LeftChildNode { get; set; }
        public T Key { get; set; }

        public Node(T key)
        {
            this.Key = key;
            LeftChildNode = null;
            RightChildNode = null;
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

        public INode<T> GetNodeByKey(T key)
        {
                
            if (key.CompareTo(this.Key) > 0 && !(RightChildNode is null))
            {
                //child node is greater than this key
                return RightChildNode.GetNodeByKey(key);
            } 
            else if (key.CompareTo(this.Key) < 0 && !(LeftChildNode is null))
            {
                //child node is smaller than this key
                return LeftChildNode.GetNodeByKey(key);
            }

            return key.CompareTo(this.Key) == 0 ? this : null;
            
        }

        public void DeleteNodeByKey(T key)
        {
            if (key.CompareTo(this.Key) == 0 )
            {
                switch (this.NumberOfDirectChilren())
                {
                        case 0 :
                            
                            break;
                }
            }   
            //switch (childNode.NumberOfDirectChilren())
            //{
            //        case 0:
            //            if (LeftChildNode.Key.CompareTo(childNode.Key) == 0)
            //            {
            //                LeftChildNode = null;
            //            }
            //            break;

            //        case 1:

            //            break;

            //}
        }

        

        public int NumberOfDirectChilren()
        {

            if (!(RightChildNode is null) && !(LeftChildNode is null))
            {
                //has two children
                return 2;
            }

            if (RightChildNode is null || LeftChildNode is null)
            {
                //has one child
                return 1;
            }

            //both child nodes are null so there are no children
            return 0;
        }
    }
}
