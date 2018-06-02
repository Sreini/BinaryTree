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
        private Node<T> Root { get; set; }
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

        public void Add(T key) 
        {
            if (Root.AddNode(key))
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
            var result = Root.DeleteNode(key);
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
            var subtree = this.Root.GetNodeByKey(key);
            if (!(subtree is null))
            {
                return new BinarySearchTree<T> {Root = subtree, Count = subtree.NumberOfChildren() + 1};
            }
            
            return null;
        }

        //test this
        public  BinarySearchTree<T> GetLeftSubtree()
        {
            var leftSubtree = this.Root.LeftChildNode;
            if (!(leftSubtree is null))
            {
               return new BinarySearchTree<T> { Root = leftSubtree, Count = leftSubtree.NumberOfChildren() + 1 };
            }
            return null;
        }

        //test this
        public BinarySearchTree<T> GetRightSubtree()
        {
            var rightSubtree = this.Root.RightChildNode;
            if (!(rightSubtree is null))
            {

                return new BinarySearchTree<T> { Root = rightSubtree, Count = rightSubtree.NumberOfChildren() + 1 };
            }
            return null;
        }

        public T GetMaximalKey()
        {
            return Root.MaximalNode().Key;
        }

        public T GetMinimalKey()
        {
            return Root.MinimalNode().Key;
        }

        public void Clear()
        {
            this.Root = null;
            Count = 0;
        }

        public bool Contains(T key)
        {
            var tree = this.Root.GetNodeByKey(key);
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
                array[arrayIndex] = Root.Key;
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
