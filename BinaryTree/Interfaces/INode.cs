using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Interfaces
{
    internal interface INode<T> where T : IComparable<T>
    {
        Node<T> LeftChildNode { get; set; }
        Node<T> RightChildNode { get; set; }
        T Key { get; set; }

        /// <summary>
        /// Adds Child Node to this Node
        /// </summary>
        /// <param name="key"></param>
        bool AddNode(T key);


        /// <summary>
        /// Get Child Node of this Node
        /// </summary>
        /// <param name="key"></param>
        Node<T> GetNodeByKey(T key);

        /// <summary>
        /// Deletes the node with this key from the tree
        /// </summary>
        /// <param name="key"></param>
        bool DeleteNode(T key);


       
    }
}
