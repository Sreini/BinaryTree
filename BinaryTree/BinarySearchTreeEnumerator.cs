using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class BinarySearchTreeEnumerator<T> : IEnumerator<T> where T: IComparable<T>
    {
        /// <summary>
        /// field for saving the original tree so the iterator can be reset
        /// </summary>
        private readonly BinarySearchTree<T> _parentTree;

        /// <summary>
        /// a stack with nodes, used so the previous node that was traversed can easily be found
        /// </summary>
        private readonly Stack<Node<T>> _nodeStack;

        /// <summary>
        /// the current node
        /// </summary>
        private Node<T> _currentNode;

        /// <summary>
        /// the current key
        /// </summary>
        private T _currentKey => _currentNode.Key;

        public T Current => _currentKey;

        /// <summary>
        /// generic constructor
        /// </summary>
        /// <param name="tree"></param>
        public BinarySearchTreeEnumerator(BinarySearchTree<T> tree)
        {
            this._parentTree = tree;
            this._nodeStack = new Stack<Node<T>>();
        }

        object IEnumerator.Current => Current;

        void IDisposable.Dispose(){}

        //pls
        public bool MoveNext()
        {
            if (_currentNode is null)
            {
                this._currentNode = _parentTree.Root;
                this._nodeStack.Push(_currentNode);
                return true;
            }
            var leftNode = this._currentNode.LeftChildNode;
            var rightNode = this._currentNode.RightChildNode;

            if (!(leftNode is null))
            {
                this._currentNode = leftNode;
                this._nodeStack.Push(_currentNode);
                return true;
            }
            else if (!(rightNode is null))
            {
                this._currentNode = rightNode;
                this._nodeStack.Push(_currentNode);
                return true;
            }
            else
            {
                //current node does not have children
                var parent = this._nodeStack.Pop();
                do
                {
                    
                    if (parent is null)
                    {
                        return false;
                    }

                } while (!(parent.RightChildNode is null));

                this._currentNode = parent.RightChildNode;
                this._nodeStack.Push(_currentNode);
                return true;
            }
            
        }

        public void Reset()
        {
            _currentNode = _parentTree.Root;
            _nodeStack.Clear();
        }
    }
}
