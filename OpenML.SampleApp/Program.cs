using System.Linq;

namespace OpenML.SampleApp
{
    /// <summary>
    /// Sample application with examples how to use OpenMl connector to obtain openMl entities
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var connector = new OpenMlConnector("");
            var dataSetDetail = connector.GetDatasetDescription(1);
            dataSetDetail.DownloadDataset("test.arff");
            var taskType = connector.GetTaskType(2);
            var taskTypes = connector.ListTaskTypes();
            var estimationProc = connector.GetEstimationProcedure(1);
            var estimationProcs = connector.ListEstimationProcedures();
            var run = connector.GetRun(3588);
            var measures = connector.ListEvaluationMeasures().Measures.Select(x=>x.Name);
            //connector.UploadFile();
            var tasks = connector.ListTasks();
            //var task = connector.GetTask(2);
            var uknownDataset = connector.GetDatasetDescription(int.MaxValue);
            var data = connector.ListDatasets();
            var dataQualities = connector.ListDataQualities();
            var datasetDescription = connector.GetDatasetDescription(1);
            var result=connector.ExecuteFreeQuery("SELECT name,did FROM dataset");
            string a = "";

        }
    }
}
