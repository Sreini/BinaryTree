using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Interfaces
{
    public interface INode<T> where T : IComparable<T>
    {
        INode<T> LeftChildNode { get; set; }
        INode<T> RightChildNode { get; set; }
        T Key { get; set; }

        /// <summary>
        /// Adds Child Node to this Node
        /// </summary>
        /// <param name="childNode"></param>
        void AddChild(INode<T> childNode);


        /// <summary>
        /// Get Child Node of this Node
        /// </summary>
        /// <param name="key"></param>
        INode<T> GetNodeByKey(T key);

        /// <summary>
        /// Delete a Child of this Node
        /// </summary>
        /// <param name="key"></param>
        void DeleteNodeByKey(T key);

        /// <summary>
        /// Returns the number of direct children of this node
        /// </summary>
        /// <returns></returns>
        int NumberOfDirectChilren();
    }
}
