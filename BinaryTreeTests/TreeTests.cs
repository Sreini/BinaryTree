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
            tree.AddNode(15);
            tree.AddNode(23);
            tree.AddNode(21);
            tree.AddNode(56);

            //Assert
            Assert.AreEqual(tree.GetCount(), 5);
            Assert.AreEqual(tree.GetMaximalKey(), 56);
            Assert.AreEqual(tree.GetMinimalKey(), 10);
        }

        [TestMethod]
        public void TestDeleteNode()
        {
            //Arrange
            var tree = new BinarySearchTree<int>(10);

            //Act
            tree.AddNode(21);
            tree.AddNode(45);
            tree.AddNode(9);
            tree.AddNode(3);
            tree.AddNode(-10);
            tree.DeleteNode(-10);
            tree.DeleteNode(45);

            //Assert
            Assert.AreEqual(tree.GetCount(), 4);
            Assert.AreEqual(tree.GetMaximalKey(), 21);
            Assert.AreEqual(tree.GetMinimalKey(), 3);

        }
    }

    
}
