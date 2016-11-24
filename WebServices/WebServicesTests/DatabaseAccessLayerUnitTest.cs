using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared;
using WebServices.DAL;

namespace WebServicesTests
{
    [TestClass]
    public class DatabaseAccessLayerUnitTest
    {
        [TestMethod]
        public void GetNodesBidirectional_OneDirection_BothDirectionLink()
        {
            var databaseAccessLayer = new DatabaseAccessLayer();
            var firstNode = new Node() {id = 1, adjacentNodes = new byte[1] {2}};
            var secondNode = new Node() {id = 2 };
            var nodesList = new List<Node> { firstNode, secondNode };
            databaseAccessLayer.GetNodesBidirectional(nodesList);

            Assert.AreEqual(firstNode.adjacentNodes.First(), secondNode.id);
            Assert.AreEqual(secondNode.adjacentNodes.First(), firstNode.id);
        }

        [TestMethod]
        public void GetNodesBidirectional_BothDirection_NoChange()
        {
            var databaseAccessLayer = new DatabaseAccessLayer();
            var firstNode = new Node() { id = 1, adjacentNodes = new byte[1] { 2 } };
            var secondNode = new Node() { id = 2, adjacentNodes = new byte[1] { 1 } };
            var nodesList = new List<Node> { firstNode, secondNode };
            databaseAccessLayer.GetNodesBidirectional(nodesList);

            Assert.AreEqual(firstNode.adjacentNodes.First(), secondNode.id);
            Assert.AreEqual(secondNode.adjacentNodes.First(), firstNode.id);
        }

        [TestMethod]
        public void GetNodesBidirectional_ThirdNodeHaveOneDirection_FirstAndSecondHaveLinkToThird()
        {
            var databaseAccessLayer = new DatabaseAccessLayer();
            var firstNode = new Node() { id = 1, adjacentNodes = new byte[1] { 2 } };
            var secondNode = new Node() { id = 2, adjacentNodes = new byte[1] { 1 } };
            var thirdNode = new Node() { id = 3, adjacentNodes = new byte[2] { 1,2 } };
            var nodesList = new List<Node> { firstNode, secondNode, thirdNode };
            databaseAccessLayer.GetNodesBidirectional(nodesList);

            Assert.AreEqual(firstNode.adjacentNodes.Last(), thirdNode.id);
            Assert.AreEqual(secondNode.adjacentNodes.Last(), thirdNode.id);
        }

    }
}
