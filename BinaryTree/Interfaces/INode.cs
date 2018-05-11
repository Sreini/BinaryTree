using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Interfaces
{
    interface INode<T>: IComparable<T>
    {
        INode<T> LeftChildNode { get; set; }
        INode<T> RightChildNode { get; set; }
        T Key { get; set; }
    }
}
