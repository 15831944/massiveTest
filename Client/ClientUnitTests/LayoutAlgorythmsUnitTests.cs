using System.Collections.Generic;
using System.Windows.Controls;
using Client.Entities;
using Client.Layouts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClientUnitTests
{
    [TestClass]
    public class LayoutAlgorythmsUnitTests
    {
        [TestMethod]
        public void CreateGridlikeLayout_InputNodes_NodesInRightCoordinates()
        {
            var layoutAlgorythms = new LayoutAlgorythms();
            var firstNode = new NodeWithVisuals() { id = 1, adjacentNodes = new byte[1] { 2 } };
            var secondNode = new NodeWithVisuals() { id = 2, adjacentNodes = new byte[1] { 3 } };
            var thirdNode = new NodeWithVisuals() { id = 3, adjacentNodes = new byte[2] { 1, 2 } };
            var nodesList = new List<NodeWithVisuals> { firstNode, secondNode, thirdNode };

           var nodesWithCoordinates = layoutAlgorythms.CreateGridlikeLayout(nodesList, new Canvas());
            var first = nodesWithCoordinates[firstNode.id];
            Assert.AreEqual(first.X,0);
            Assert.AreEqual(first.Y, 0);

            var second = nodesWithCoordinates[secondNode.id];
            Assert.AreEqual(second.X, 90);
            Assert.AreEqual(second.Y, 0);

            var third = nodesWithCoordinates[thirdNode.id];
            Assert.AreEqual(third.X, 90);
            Assert.AreEqual(third.Y, 90);
        }
    }
}
