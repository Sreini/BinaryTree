using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinarySearchTree<T>: ICollection<T> where T: IComparable<T>
    {
        internal Node<T> Root { get; set; }
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        private BinarySearchTree()
        {
            Root = new Node<T>();
            Count = 1;
        }

        /// <summary>
        /// individual key constructor
        /// </summary>
        /// <param name="key"></param>
        public BinarySearchTree(T key)
        {
            Root = new Node<T>(key);
            Count = 1;
        }

        /// <summary>
        /// collection constructor
        /// </summary>
        /// <param name="keyList"></param>
        public BinarySearchTree(ICollection<T> keyList)
        {
            Root = new Node<T>(keyList.FirstOrDefault());
            Count=1;
            
            foreach (var key in keyList)
            {
                if (Root.AddNode(key))
                {
                    Count++;
                }

            }
        }

        /// <summary>
        /// adds single key to tree
        /// </summary>
        /// <param name="key"></param>
        public void Add(T key) 
        {
            if (Root.AddNode(key))
            {
                Count++;
            }
            
        }

        /// <summary>
        /// adds collection of keys to tree
        /// </summary>
        /// <param name="keyCollection"></param>
        public void Add(ICollection<T> keyCollection)
        {
            foreach (var key in keyCollection)
            {
                this.Add(key);
            }
        }


        /// <summary>
        /// removes a key from the tree
        /// </summary>
        /// <param name="key"></param>
        /// <returns>
        /// returns true if the key was removed, returns false if the key was not found
        /// </returns>
        public bool Remove(T key)
        {
            var result = Root.DeleteNode(key);
            if (result)
            {
                Count--;
            }
            return result;
        }

        /// <summary>
        /// removes a collection of keys from the tree
        /// </summary>
        /// <param name="keyList"></param>
        /// <returns>
        /// returns true if all the keys were removed, returns false if one or more keys were not found
        /// </returns>
        public bool Remove(ICollection<T> keyList)
        {
            var result = true;
            foreach (var key in keyList)
            {
                if (!this.Remove(key))
                {
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// gets the subtree who's parent node starts with the Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>
        /// returns the BinarySearchTree that was retrieved
        /// </returns>
        public BinarySearchTree<T> GetSubtree(T key)
        {
            var subtree = this.Root.GetNodeByKey(key);
            if (!(subtree is null))
            {
                return new BinarySearchTree<T> {Root = subtree, Count = subtree.NumberOfChildren() + 1};
            }
            
            return null;
        }

        /// <summary>
        /// gets the left subtree of the parent node of this object
        /// </summary>
        public  BinarySearchTree<T> LeftSubtree()
        {
            var leftSubtree = this.Root.LeftChildNode;
            if (!(leftSubtree is null))
            {
               return new BinarySearchTree<T> { Root = leftSubtree, Count = leftSubtree.NumberOfChildren() + 1 };
            }
            return null;
        }

        /// <summary>
        /// gets the right subtree of the parent node of this object
        /// </summary>
        public BinarySearchTree<T> RightSubtree()
        {
            var rightSubtree = this.Root.RightChildNode;
            if (!(rightSubtree is null))
            {

                return new BinarySearchTree<T> { Root = rightSubtree, Count = rightSubtree.NumberOfChildren() + 1 };
            }
            return null;
        }

        /// <summary>
        /// gets the maximal key in the BinarySearchTree
        /// </summary>
        /// <returns></returns>
        public T MaximalKey()
        {
            return this.Root.MaximalNode().Key;
        }

        /// <summary>
        /// gets the minimal key in the BinarySearchTree
        /// </summary>
        /// <returns></returns>
        public T GetMinimalKey()
        {
            return this.Root.MinimalNode().Key;
        }

        /// <summary>
        /// removes all the nodes from this object
        /// </summary>
        public void Clear()
        {
            this.Root = null;
            this.Count = 0;
        }

        /// <summary>
        /// searches for the node that corresponds to the key parameter
        /// </summary>
        /// <param name="key"></param>
        /// <returns>
        /// returns true if the key was found, returns false if it wasn't found
        /// </returns>
        public bool Contains(T key)
        {
            var tree = this.Root.GetNodeByKey(key);
            return !(tree is null);
        }

        /// <summary>
        /// copies this BInarySearchTree to the array given in the parameters, starting from the
        /// arrayIndex parameter. If the BST does not fit in the array, the exception is handled and rethrown.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            CopyTo(array, ref arrayIndex);
        }

        private void CopyTo(T[] array, ref int arrayIndex)
        {
            try
            {
                array[arrayIndex] = Root.Key;
                arrayIndex++;

                var leftTree = LeftSubtree();
                var rightTree = RightSubtree();

                //calls copyTo on both trees if they are not null
                leftTree?.CopyTo(array, ref arrayIndex);
                rightTree?.CopyTo(array, ref arrayIndex);
            }
            catch (IndexOutOfRangeException indexOutOfRangeException)
            {
                Console.WriteLine(indexOutOfRangeException.Message);
                throw;
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            return enumerate(Root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return enumerate(Root).GetEnumerator();
        }

        IEnumerable<T> enumerate(Node<T> root)
        {
            if (root == null)
                yield break;

            yield return root.Key;

            foreach (var value in enumerate(root.LeftChildNode))
                yield return value;

            foreach (var value in enumerate(root.RightChildNode))
                yield return value;
        }
    }
}
