using System.Collections.Generic;
using DataLoader.SAL;
using Shared;

namespace DataLoaderTests
{
    public class ServiceAccessLayerMock : IServiceAccessLayer
    {
        public readonly List<int> NodesListCount = new List<int>();
        public int UploadNewData(List<Node> nodesList)
        {
            NodesListCount.Add(nodesList.Count);
            return nodesList.Count;
        }
    }
}