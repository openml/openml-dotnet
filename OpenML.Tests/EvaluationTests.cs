using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenML.Tests
{
    [TestClass]
    public class EvaluationTests: BaseApiConnectorTest
    {
        [TestMethod]
        public void TestGetEvaluationsByRunIds()
        {
            var evaluations = Connector.GetEvaluationsByRunIds(new List<int>{1});
            Assert.IsTrue(evaluations.Count>0);
        }

        [TestMethod]
        public void TestGetEvaluationsByTag()
        {
            var evaluations = Connector.GetEvaluationsByTag("test");
            Assert.IsTrue(evaluations.Count > 0);
        }

        [TestMethod]
        public void TestGetEvaluationsByTaskIds()
        {
            var evaluations = Connector.GetEvaluationsByTaskIds(new List<int> { 1 });
            Assert.IsTrue(evaluations.Count > 0);
        }

        [TestMethod]
        public void TestGetEvaluationsByUploaderIds()
        {
            var evaluations = Connector.GetEvaluationsByUploaderIds(new List<int> { 16 });
            Assert.IsTrue(evaluations.Count > 0);
        }

        [TestMethod]
        public void TestGetRunsByFlowIds()
        {
            var evaluations = Connector.GetRunsByFlowIds(new List<int> { 1 });
            Assert.IsTrue(evaluations.Count > 0);
        }

        [TestMethod]
        public void TestGetRunsWithFilter()
        {
            var runs = Connector.GetEvaluationsWithFilter(
             new List<int> { 1 }, new List<int> { 68 }, new List<int> { 1 }, new List<int> { 61 }, null);
            Assert.IsTrue(runs.Count > 0);
        }
    }
}
