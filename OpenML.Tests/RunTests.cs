using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenML.Tests
{
    [TestClass]
    public class RunTests: BaseApiConnectorTest
    {
        [TestMethod]
        public void TestGetRun()
        {
            var run = Connector.GetRun(3588);
            Assert.IsTrue(run.InputData.Datasets.Count > 0
               && run.OutputData.Files.Count > 0 
               && run.ParameterSettings.Count > 0
                );
        }
        [TestMethod]
        public void TestGetRunsByIds()
        {
            var ids = new List<int> {1, 2, 3};
            var runs = Connector.GetRunsByIds(ids);
            Assert.AreEqual(runs.Count, ids.Count);
        }

        [TestMethod]
        public void TestGetRunsByTaskIds()
        {
            var ids = new List<int> { 1 };
            var runs = Connector.GetRunsByTaskIds(ids);
            Assert.IsTrue(runs.Count > 0);
        }

        [TestMethod]
        public void TestGetRunsByUploaderIds()
        {
            var ids = new List<int> { 16 };
            var runs = Connector.GetRunsByUploaderIds(ids);
            Assert.IsTrue(runs.Count > 0);
        }

        [TestMethod]
        public void TestGetRunsByFlowIds()
        {
            var ids = new List<int> { 1 };
            var runs = Connector.GetRunsByFlowIds(ids);
            Assert.IsTrue(runs.Count > 0);
        }

        [TestMethod]
        public void TestGetRunsByTag()
        {
            var runs = Connector.GetRunsByTag("test");
            Assert.IsTrue(runs.Count>0);
        }

        [TestMethod]
        public void TestGetRunsWithFilter()
        {
            var runs = Connector.GetRunsWithFilter(
             new List<int> {1}, new List<int> { 68 }, new List<int> { 1 }, new List<int> { 61 },null);
            Assert.IsTrue(runs.Count > 0);
        }
    }
}
