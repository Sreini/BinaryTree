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
        public void TestAddNode()
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
        public void TestDeleteNode()
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
    }

    
}
