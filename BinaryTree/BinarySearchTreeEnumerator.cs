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
        private BinarySearchTree<T> _parentTree;
        private BinarySearchTree<T> _currentTree;
        private Node<T> _currentNode => _currentTree.Root;
        private T _currentKey;

        public T Current => _currentNode.Key;

        /// <summary>
        /// generic constructor
        /// </summary>
        /// <param name="tree"></param>
        public BinarySearchTreeEnumerator(BinarySearchTree<T> tree)
        {
            this._parentTree = tree;
        }

        object IEnumerator.Current => Current;

        void IDisposable.Dispose(){}

        //pls
        public bool MoveNext()
        {
            if (_currentTree is null)
            {
                _currentTree = _parentTree;
            }
            var leftSubtree = this._currentTree.GetLeftSubtree();
            var rightSubtree = this._currentTree.GetRightSubtree();

            if (!(leftSubtree is null))
            {
                this._currentTree = leftSubtree;
                
            }
            else if (!(rightSubtree is null))
            {
                this._currentTree = rightSubtree;
                
            }
            else
            {
                
            }
            
        }

        public void Reset()
        {
            _currentTree = _parentTree;
        }
    }
}
