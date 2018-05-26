using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinarySearchTree<T> where T: IComparable<T>
    {
        private Node<T> root { get; set; }
        private int count { get; set; }

        public BinarySearchTree()
        {
            root = new Node<T>();
            count = 1;
        }

        public BinarySearchTree(T key)
        {
            root = new Node<T>(key);
            count = 1;
        }

        public BinarySearchTree(ICollection<T> keyList)
        {
            root = new Node<T>(keyList.FirstOrDefault());
            
            foreach (var key in keyList)
            {
                root.AddNode(key);
            }

            count = keyList.Count;
        }

        public void AddNode(T key)
        {
            root.AddNode(key);
            count++;
        }

        public void AddNodeCollection(ICollection<T> keyList)
        {
            foreach (var key in keyList)
            {
                AddNode(key);
            }
        }

        public void DeleteNode(T key)
        {
            root.DeleteNode(key);
            count--;
        }

        public void DeleteNodeCollection(ICollection<T> keyList)
        {
            foreach (var key in keyList)
            {
                DeleteNode(key);
            }
        }

        public BinarySearchTree<T> GetSubtree(T key)
        {
            var subtree = new BinarySearchTree<T>(key);
            subtree.root = this.root.GetNodeByKey(key);
            subtree.count = subtree.root.NumberOfChildren() + 1;
            return subtree;
        }

        public T GetMaximalKey()
        {
            return root.MaximalNode().Key;
        }

        public T GetMinimalKey()
        {
            return root.MinimalNode().Key;
        }

        public int GetCount()
        {
            return count;
        }
    }
}
