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
        private Node<T> root { get; set; }
        public int Count { get; private set; }
        public bool IsReadOnly { get; set; }

        private BinarySearchTree()
        {
            root = new Node<T>();
            Count = 1;
        }

        /// <summary>
        /// individual key constructor
        /// </summary>
        /// <param name="key"></param>
        public BinarySearchTree(T key)
        {
            root = new Node<T>(key);
            Count = 1;
        }

        /// <summary>
        /// collection constructor
        /// </summary>
        /// <param name="keyList"></param>
        public BinarySearchTree(ICollection<T> keyList)
        {
            root = new Node<T>(keyList.FirstOrDefault());
            Count=1;
            
            foreach (var key in keyList)
            {
                if (root.AddNode(key))
                {
                    Count++;
                }

            }
        }

        public void Add(T key) 
        {
            if (root.AddNode(key))
            {
                Count++;
            }
            
        }

        //TO DO: change to make consistent with individual add
        public void AddNodeCollection(ICollection<T> keyList)
        {
            foreach (var key in keyList)
            {
                this.Add(key);
            }
        }

        public bool Remove(T key)
        {
            var result = root.DeleteNode(key);
            if (result)
            {
                Count--;
            }
            return result;
        }

        //TO DO: change to make consistent with individual add
        public void DeleteNodeCollection(ICollection<T> keyList)
        {
            foreach (var key in keyList)
            {
                Remove(key);
            }
        }

        //test this
        public BinarySearchTree<T> GetSubtree(T key)
        {
            var subtree = this.root.GetNodeByKey(key);
            if (!(subtree is null))
            {
                return new BinarySearchTree<T> {root = subtree, Count = subtree.NumberOfChildren() + 1};
            }
            
            return null;
        }

        //test this
        public  BinarySearchTree<T> GetLeftSubtree()
        {
            var leftSubtree = this.root.LeftChildNode;
            if (!(leftSubtree is null))
            {
               return new BinarySearchTree<T> { root = leftSubtree, Count = leftSubtree.NumberOfChildren() + 1 };
            }
            return null;
        }

        //test this
        public BinarySearchTree<T> GetRightSubtree()
        {
            var rightSubtree = this.root.RightChildNode;
            if (!(rightSubtree is null))
            {

                return new BinarySearchTree<T> { root = rightSubtree, Count = rightSubtree.NumberOfChildren() + 1 };
            }
            return null;
        }

        public T GetMaximalKey()
        {
            return root.MaximalNode().Key;
        }

        public T GetMinimalKey()
        {
            return root.MinimalNode().Key;
        }

        public void Clear()
        {
            this.root = null;
            Count = 0;
        }

        public bool Contains(T key)
        {
            var tree = this.root.GetNodeByKey(key);
            return !(tree is null);
        }

        //test this
        public void CopyTo(T[] array, int arrayIndex)
        {
            CopyTo(array, ref arrayIndex);
        }

        private void CopyTo(T[] array, ref int arrayIndex)
        {
            try
            {
                array[arrayIndex] = root.Key;
                arrayIndex++;

                var leftTree = GetLeftSubtree();
                var rightTree = GetRightSubtree();

                //calls copyTo on both trees if they are not null
                leftTree?.CopyTo(array, ref arrayIndex);
                rightTree?.CopyTo(array, ref arrayIndex);
            }
            catch (IndexOutOfRangeException indexOutOfRangeException)
            {
                Console.WriteLine(indexOutOfRangeException.Message);
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
