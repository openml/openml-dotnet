using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenML.Tests
{
    [TestClass]
    public class DatasetTests: BaseApiConnectorTest
    {
        [TestMethod]
        public void TestGetDatasetDescription()
        {
            var dataSetDetail = Connector.GetDatasetDescription(1);
            Assert.IsTrue(!string.IsNullOrEmpty(dataSetDetail.Name)
                && !string.IsNullOrEmpty(dataSetDetail.Description)
                && !string.IsNullOrEmpty(dataSetDetail.Format)
                && !string.IsNullOrEmpty(dataSetDetail.Md5CheckSum)
                && !string.IsNullOrEmpty(dataSetDetail.Url)
                );
        }

        [TestMethod]
        public void TestListDatasets()
        {
            var data = Connector.ListDatasets();
            Assert.IsTrue(data.Any(dataSetDetail => !string.IsNullOrEmpty(dataSetDetail.Name)
                                                    && !string.IsNullOrEmpty(dataSetDetail.Status)
                                                    && dataSetDetail.Qualities.Count > 0));
        }

        [TestMethod]
        public void TestGetDataFeatures()
        {
            var dataFeatures = Connector.GetDataFeatures(1);
            Assert.IsTrue(dataFeatures.Count>0);
        }

        [TestMethod]
        public void TestListDataQualities()
        {
            var dataQualities = Connector.ListDataQualities();
            Assert.IsTrue(dataQualities.Count > 0);
        }

        [TestMethod]
        public void TestListDatasetsWithTag()
        {
            var datasets = Connector.ListDatasetsWithTag("test");
            Assert.IsTrue(datasets.Any(dataSetDetail => !string.IsNullOrEmpty(dataSetDetail.Name)
                                                    && !string.IsNullOrEmpty(dataSetDetail.Status)
                                                    && dataSetDetail.Qualities.Count > 0));
        }
    }
}
