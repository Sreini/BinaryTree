using System;
using BinaryTree;
using BinaryTree.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeTests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void TestAddChild()
        {
            //Arrange
            var Tree = new Node<int>(10);

            //Act
            Tree.AddChild(new Node<int>(15));
            Tree.AddChild(new Node<int>(7));
            Tree.AddChild(new Node<int>(13));

            //Assert
            Assert.AreEqual(Tree.RightChildNode.Key, 15);
            Assert.AreEqual(Tree.LeftChildNode.Key, 7);
            Assert.AreEqual(Tree.RightChildNode.LeftChildNode.Key , 13);
        }
    }
}
