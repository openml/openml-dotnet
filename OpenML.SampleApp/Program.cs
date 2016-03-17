using System.Collections.Generic;
using System.Linq;
using OpenML.Response.Datasets;
using OpenML.Response.Flows;
using OpenML.Response.Tasks;

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
            var result=connector.ExecuteFreeQuery("SELECT name,did FROM dataset");
            var dataSetDetail = connector.GetDatasetDescription(1);
            //var uploadedFlow = connector.UploadFlow(new UploadFlowDescription("testFlowKuba","kubakuba")
            //{

            //}, @"C:\Users\Kuba\Downloads\weather.arff"
            //);

            var uploadedTask = connector.UploadTask(new UploadTaskDescription(1, new List<InputDescription>
            {
                new InputDescription("estimation_procedure", "7"),
                new InputDescription("source_data", "844"),
                new InputDescription("target_feature", "class")
            }));
          

            

            var task = connector.GetTask(59);
            var tasksOfType = connector.ListTasksOfType(1);
            var tasks = connector.ListTasks();

            var uploaded = connector.UploadDataSet(@"C:\Users\Kuba\Downloads\weather.arff",
                new UploadDatasetDescription("KubaDataset", "KubaTestTestTest"));
            var tagged = connector.UntagDataSet(uploaded.Id, "testtag");
            var untagged = connector.UntagDataSet(uploaded.Id, "testtag");
            var deletedDataset = connector.DeleteDataset(uploaded.Id);
            var dataQualities = connector.ListDataQualities();
            var dataFeatures = connector.GetDataFeatures(1);
            var flowsOwnedByMe = connector.FlowOwnedByMe();
            dataSetDetail.DownloadDataset("test.arff");
            
            var estimationProc = connector.GetEstimationProcedure(1);
            var estimationProcs = connector.ListEstimationProcedures();
            var measures = connector.ListEvaluationMeasures().Measures.Select(x=>x.Name);
            //connector.UploadFile();
            //var task = connector.GetTask(2);
            
            string a = "";

        }
    }
}
