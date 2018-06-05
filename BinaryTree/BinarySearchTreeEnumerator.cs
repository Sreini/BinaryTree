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
        /// the current tree
        /// </summary>
        private BinarySearchTree<T> _currentTree;

        /// <summary>
        /// the current node
        /// </summary>
        private Node<T> _currentNode => _currentTree.Root;

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
            if (_currentTree is null)
            {
                _currentTree = _parentTree;
                _nodeStack.Push(_currentNode);
                return true;
            }
            var leftSubtree = this._currentTree.LeftSubtree();
            var rightSubtree = this._currentTree.RightSubtree();

            if (!(leftSubtree is null))
            {
                this._currentTree = leftSubtree;
                _nodeStack.Push(_currentNode);
                return true;
            }
            else if (!(rightSubtree is null))
            {
                this._currentTree = rightSubtree;
                _nodeStack.Push(_currentNode);
                return true;
            }
            else
            {
                
            }
            
        }

        public void Reset()
        {
            _currentTree = _parentTree;
            _nodeStack.Clear();
        }
    }
}
