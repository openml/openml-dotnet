using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenML.Tests
{
    [TestClass]
    public class FlowTests: BaseApiConnectorTest
    {
        [TestMethod]
        public void TestFlowExist()
        {
            var flowExist = Connector.FlowExist("a", "a");
            Assert.AreEqual(-1, flowExist.Id);
            Assert.AreEqual(false, flowExist.Exists);
            flowExist = Connector.FlowExist("weka.REPTree", "Weka_3.7.10_9378");
            Assert.AreEqual(61, flowExist.Id);
            Assert.AreEqual(true, flowExist.Exists);
        }

        [TestMethod]
        public void TestListFlows()
        {
            var flows = Connector.ListFlows();
            Assert.AreNotSame(0, flows.Count);
            Assert.IsTrue(flows.Any(flow=>!string.IsNullOrEmpty(flow.ExternalVersion) &&
            !string.IsNullOrEmpty(flow.Name)
            && !string.IsNullOrEmpty(flow.FullName)
            && flow.Id>1 && flow.Version>1 && flow.Uploader>1));
        }

        [TestMethod]
        public void TestGetFlowDescription()
        {
            var flowDetail = Connector.GetFlowDescription(56);
            Assert.IsTrue(!string.IsNullOrEmpty(flowDetail.Name)
                && !string.IsNullOrEmpty(flowDetail.Description)
                && !string.IsNullOrEmpty(flowDetail.Language)
                && !string.IsNullOrEmpty(flowDetail.ExternalVersion)
                && flowDetail.Parameters.Count>0
                );
            Assert.IsTrue(!string.IsNullOrEmpty(flowDetail.Tag));
        }

        [TestMethod]
        public void TestListFlowsWithTag()
        {
            var flows = Connector.ListFlowsWithTag("study_7");
            Assert.IsTrue(flows.Count>0);
            Assert.IsTrue(!string.IsNullOrEmpty(flows[0].Name));
        }
    }
}
