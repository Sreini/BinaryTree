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
        private BinarySearchTree<T> _tree;
        private T _currentKey;

        public T Current => _currentKey;

        /// <summary>
        /// generic constructor
        /// </summary>
        /// <param name="tree"></param>
        public BinarySearchTreeEnumerator(BinarySearchTree<T> tree)
        {
            this._tree = tree;
            this._currentKey = tree.Root.Key;
        }

        object IEnumerator.Current => Current;

        void IDisposable.Dispose(){}

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            _currentKey = _tree.Root.Key;
        }
    }
}
