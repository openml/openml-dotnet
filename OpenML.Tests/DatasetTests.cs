using System;
using System.IO;
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
        public void TestGetDatasetQualities()
        {
            var dataQualities = Connector.GetDatasetQualities(1);
            Assert.IsTrue(dataQualities.Count > 0);
            var dataQuality = dataQualities.First();
            Assert.IsTrue(!string.IsNullOrEmpty(dataQuality.Name));
        }

        //GetDatasetQualities

        [TestMethod]
        public void TestListDatasetsWithTag()
        {
            var datasets = Connector.ListDatasetsWithTag("test");
            Assert.IsTrue(datasets.Any(dataSetDetail => !string.IsNullOrEmpty(dataSetDetail.Name)
                                                    && !string.IsNullOrEmpty(dataSetDetail.Status)
                                                    && dataSetDetail.Qualities.Count > 0));
        }

        [TestMethod]
        public void TestDownloadDataset_Ok()
        {
            string destination = "test.arff";
            try
            {
                var dataSetDetail = Connector.GetDatasetDescription(1);
                dataSetDetail.DownloadDataset(destination);
                Assert.IsTrue(File.Exists(destination));
            }
            finally 
            {
                File.Delete(destination);
            }
        }

        [TestMethod]
        public void TestDownloadDataset_Ko()
        {
            string destination = "test.arff";
            try
            {
                var dataSetDetail = Connector.GetDatasetDescription(1);
                dataSetDetail.Md5CheckSum = "falseMd5";
                dataSetDetail.DownloadDataset(destination);
                Assert.Fail("Should raised an exception");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Md5 hash did not match. Source Corrupted?", e.Message);
            }
            finally
            {
                File.Delete(destination);
            }
        }
    }
}
