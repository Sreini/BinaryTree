﻿using System;
using BinaryTree;
using BinaryTree.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeTests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void TestAddNode()
        {
            //Arrange
            var tree = new Node<int>(10);

            //Act
            tree.AddNode(15);
            tree.AddNode(7);
            tree.AddNode(13);

            //Assert
            Assert.AreEqual(tree.RightChildNode.Key, 15);
            Assert.AreEqual(tree.LeftChildNode.Key, 7);
            Assert.AreEqual(tree.RightChildNode.LeftChildNode.Key , 13);
        }

        [TestMethod]
        public void TestDeleteNode()
        {
            //Arrange
            var tree = new Node<int>(10);

            //Act
            tree.AddNode(23);
            tree.AddNode(26);
            tree.AddNode(2);
            tree.AddNode(4);
            tree.AddNode(216);
            tree.AddNode(15);
            tree.AddNode(8);
            tree.AddNode(55);
            tree.DeleteNode(216);

            //Assert
            Assert.AreEqual(tree.MaximalNode().Key, 55 );
        }

        [TestMethod]
        public void TestGetNodeByKey()
        {
            //Arrange
            var tree = new Node<int>(10);

            //Act
            tree.AddNode(23);
            tree.AddNode(26);
            tree.AddNode(2);
            tree.AddNode(4);
            tree.AddNode(216);
            tree.AddNode(15);
            tree.AddNode(8);
            tree.AddNode(55);

            //Assert
            Assert.AreEqual(tree.GetNodeByKey(23).RightChildNode.Key, 26);
        }
    }
}
