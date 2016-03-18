using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenML.Tests
{
    [TestClass]
    public class MiscApiTests: BaseApiConnectorTest
    {
        [TestMethod]
        public void TestExecuteFreeQuery()
        {
            var result = Connector.ExecuteFreeQuery("SELECT name,did FROM dataset");
            Assert.IsTrue(result.Columns.Length == 2);
            Assert.IsTrue(result.Columns[0].Title == "name");
            Assert.IsTrue(result.Columns[1].Title == "did");
            Assert.IsTrue(result.Data.Length > 0);
        }

        [TestMethod]
        public void TestListEstimationProcedures()
        {
            var estimationProcs = Connector.ListEstimationProcedures();
            Assert.IsTrue(estimationProcs.Count>0);
            var estimationProc = estimationProcs.First();
            Assert.IsTrue(!string.IsNullOrEmpty(estimationProc.Name));
        }

        [TestMethod]
        public void TestListEvaluationMeasures()
        {
            var measures = Connector.ListEvaluationMeasures();
            Assert.IsTrue(measures.Count > 0);
            var measure = measures.First();
            Assert.IsTrue(!string.IsNullOrEmpty(measure.Name));
        }
    }
}
