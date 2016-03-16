using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenML.Tests
{
    [TestClass]
    public class TaskTypeTests: BaseApiConnectorTest
    {
        [TestMethod]
        public void TestGetTaskType()
        {
            var taskType = Connector.GetTaskType(2);
            Assert.IsTrue(!string.IsNullOrEmpty(taskType.Name)
                && !string.IsNullOrEmpty(taskType.Description)
                && taskType.Output!=null
                && taskType.Inputs.Count > 0 
                && taskType.Contributors.Count >0
                );
        }

        [TestMethod]
        public void TestTaskTypes()
        {
            var taskTypes = Connector.ListTaskTypes();
            Assert.IsTrue(taskTypes.Any(taskType => !string.IsNullOrEmpty(taskType.Name)
                && !string.IsNullOrEmpty(taskType.Description)
                && !string.IsNullOrEmpty(taskType.Creator)
                ));
        }
    }
}
