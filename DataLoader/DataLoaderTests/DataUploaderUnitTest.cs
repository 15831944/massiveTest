using System.Linq;
using DataLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataLoaderTests
{
    [TestClass]
    public class DataUploaderUnitTest
    {
        [TestMethod]
        public void DataUploader_NoFilesInFolder_ZeroNodesSendToServer()
        {
            var fileHelperMock = new FileHelperMock(false,false, new string[0]);
            var serviceAccessLayerMock = new ServiceAccessLayerMock();
            var dataUploader = new DataUploader(10, fileHelperMock, serviceAccessLayerMock);
            var newFilesSendCount = dataUploader.LoadAndSendData("");
            Assert.IsFalse(serviceAccessLayerMock.NodesListCount.Any());
        }

        [TestMethod]
        public void DataUploader_TwoInFolder_TwoNewFilesSendCount()
        {
            var fileList = new string[2] {"..//..//file1.xml", "..//..//file2.xml"};
            var fileHelperMock = new FileHelperMock(true, true, fileList);
            ServiceAccessLayerMock serviceAccessLayerMock = new ServiceAccessLayerMock();
            DataUploader dataUploader = new DataUploader(10, fileHelperMock, serviceAccessLayerMock);
            var newFilesSendCount = dataUploader.LoadAndSendData("");
            Assert.AreEqual(newFilesSendCount, serviceAccessLayerMock.NodesListCount.First());
        }

        [TestMethod]
        public void DataUploader_SixInFolder_SixNewFilesSendContinuously()
        {
            var fileList = new string[6] { "..//..//file1.xml", "..//..//file2.xml", "..//..//file2.xml", "..//..//file2.xml", "..//..//file2.xml", "..//..//file2.xml" };
            var fileHelperMock = new FileHelperMock(true, true, fileList);
            ServiceAccessLayerMock serviceAccessLayerMock = new ServiceAccessLayerMock();
            DataUploader dataUploader = new DataUploader(4, fileHelperMock, serviceAccessLayerMock);
            var newFilesSendCount = dataUploader.LoadAndSendData("");
            Assert.AreEqual(4, serviceAccessLayerMock.NodesListCount.First());
            Assert.AreEqual(2, serviceAccessLayerMock.NodesListCount.Last());
        }

    }
}
