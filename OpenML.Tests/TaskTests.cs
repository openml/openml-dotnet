using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenML.Tests
{
    [TestClass]
    public class TaskTests: BaseApiConnectorTest
    {
        [TestMethod]
        public void TestGetTask()
        {
            var task = Connector.GetTask(59);
            Assert.IsTrue(task.Inputs.Count>0);
            Assert.IsTrue(task.Tags.Count > 0);
            Assert.IsTrue(task.TaskId == 59);
            Assert.IsTrue(task.Output.Predictions.Features.Count > 0);
        }

        [TestMethod]
        public void TestListTasks()
        {
            var tasks = Connector.ListTasks();
            var task = tasks.First(x => x.TaskId == 59);
            Assert.IsTrue(task.Inputs.Count > 0);
            Assert.IsTrue(task.Tags.Count > 0);
        }

        [TestMethod]
        public void TestListTasksOfType()
        {
            var tasks = Connector.ListTasksOfType(1);
            var task = tasks.First();
            Assert.IsTrue(task.Inputs.Count > 0);
            Assert.IsTrue(task.Tags.Count > 0);
        }
    }
}
