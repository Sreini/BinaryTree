using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeTests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void TestAdd()
        {
            //Arrange
            var tree = new BinarySearchTree<int>(10);

            //Act
            tree.Add(15);
            tree.Add(23);
            tree.Add(21);
            tree.Add(56);

            //Assert
            Assert.AreEqual(tree.Count, 5);
            Assert.AreEqual(tree.GetMaximalKey(), 56);
            Assert.AreEqual(tree.GetMinimalKey(), 10);
        }

        [TestMethod]
        public void TestRemove()
        {
            //Arrange
            var tree = new BinarySearchTree<int>(10);

            //Act
            tree.Add(21);
            tree.Add(45);
            tree.Add(9);
            tree.Add(3);
            tree.Add(-10);
            tree.Remove(-10);
            tree.Remove(45);

            //Assert
            Assert.AreEqual(tree.Count, 4);
            Assert.AreEqual(tree.GetMaximalKey(), 21);
            Assert.AreEqual(tree.GetMinimalKey(), 3);

        }

        [TestMethod]
        public void TestCollectionConstructor()
        {
            //Arrange
            var list = new List<int>
            {
                10,
                7,
                56, 
                45, 
                23,
                5
            };

            //Act
            var tree = new BinarySearchTree<int>(list);

            //Assert
            Assert.AreEqual(tree.Count, 6);
            Assert.AreEqual(tree.GetMaximalKey(), 56);
            Assert.AreEqual(tree.GetMinimalKey(), 5);
            
        }

        [TestMethod]
        public void TestCopyTo()
        {
            //Arrange
            var tree = new BinarySearchTree<int>(25);
            tree.Add(10);
            tree.Add(90);
            tree.Add(54);
            tree.Add(94);
            tree.Add(12);
            tree.Add(7);
            var array = new int[10];

            //Act
            tree.CopyTo(array, 0);
            var testArray = new int[] { 25, 10, 90, 54, 94, 12, 7 };

            //Assert
            for(int index = 0; index < 7 ; index++)
            {
                Assert.IsTrue(array.Contains(testArray[index]));
                Assert.AreEqual(array[7], 0);
                Assert.AreEqual(array[8], 0);
                Assert.AreEqual(array[9], 0);
            }
        }

        [TestMethod]
        public void TestRightLeftTree()
        {
            //Arrange
            var tree = new BinarySearchTree<int>(new List<int>{4, 5, 6, 7, 8, 1, 10, -8, 27});
            

            //Act
            var leftTree = tree.GetLeftSubtree();
            var rightTree = tree.GetRightSubtree(); 

            //Assert
            Assert.AreEqual(leftTree.Count, 2);
            Assert.AreEqual(leftTree.GetMaximalKey(), 1);
            Assert.AreEqual(leftTree.GetMinimalKey(), -8);
            Assert.AreEqual(rightTree.Count, 6);
            Assert.AreEqual(rightTree.GetMaximalKey(), 27);
            Assert.AreEqual(rightTree.GetMinimalKey(), 5);
        }
    }

}
