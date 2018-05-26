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
        public Node<T> RightChildNode { get; set; }
        public Node<T> LeftChildNode { get; set; }
        public T Key { get; set; }

        public Node(T key)
        {
            this.Key = key;
            LeftChildNode = null;
            RightChildNode = null;
        }

        

        public void AddNode(T key)
        {
            AddChild(new Node<T>(key));
        }

        public Node<T> GetNodeByKey(T key)
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

        public void DeleteNode(T key)
        {
            var newNode = this.DeleteNodeByKey(key);
            this.LeftChildNode = newNode.LeftChildNode;
            this.RightChildNode = newNode.RightChildNode;
            this.Key = newNode.Key;
        }

        private void AddChild(Node<T> childNode)
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

        private Node<T> DeleteNodeByKey(T key)
        {
           
            if (key.CompareTo(this.Key) == 0 )
            {
                switch (this.NumberOfDirectChilren())
                {
                    case 0 :
                        return null;    
                            
                    case 1 :
                        if (this.LeftChildNode is null)
                        {
                            return this.RightChildNode;
                        }
                        else
                        {
                            return this.LeftChildNode;
                        }

                    case 2 :
                        this.Key = LeftChildNode.MaximalNode().Key;
                        LeftChildNode = LeftChildNode.DeleteNodeByKey(this.Key);
                        break;
                }
            } 
            else if (key.CompareTo(this.Key) > 0)
            {
                RightChildNode = this.RightChildNode.DeleteNodeByKey(key);
            }   
            else if (key.CompareTo(this.Key) < 0)
            {
                LeftChildNode = this.LeftChildNode.DeleteNodeByKey(key);
            }

            return this;
        }

        public Node<T> MaximalNode()
        {
            if (this.RightChildNode is null)
            {
                return this;
            }

            return this.RightChildNode.MaximalNode();
        }

        private int NumberOfDirectChilren()
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
