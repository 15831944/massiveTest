using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared;
using WebServices.Utilities;

namespace WebServicesTests
{
    [TestClass]
    public class BreathSearchFirstTest
    {
        [TestMethod]
        public void FindShortestPath_PathExists_PathFound()
        {
            var firstNode = new Node() { id = 1, adjacentNodes = new byte[1] { 2 } };
            var secondNode = new Node() { id = 2, adjacentNodes = new byte[1] { 3 } };
            var thirdNode = new Node() { id = 3, adjacentNodes = new byte[2] { 1, 2 } };
            var nodesList = new List<Node> { firstNode, secondNode, thirdNode };

            var breathSearchFirst = new BreathSearchFirst();
            var resultNodes = breathSearchFirst.FindShortestPath(nodesList, firstNode.id, thirdNode.id);
            Assert.AreEqual(resultNodes[0].id, thirdNode.id);
            Assert.AreEqual(resultNodes[1].id, secondNode.id);
            Assert.AreEqual(resultNodes[2].id, firstNode.id);
        }
    }
}
