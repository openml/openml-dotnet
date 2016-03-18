using System.Collections.Generic;
using System.Linq;
using OpenML.Response.Datasets;
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
            var connector = new OpenMlConnector("57e587337295cc384add1de665563e29");
            var uploadedTask = connector.UploadTask(new UploadTaskDescription(1, new List<InputDescription>
            {
                new InputDescription("estimation_procedure", "7"),
                new InputDescription("source_data", "844"),
                new InputDescription("target_feature", "class")
            }));

            var uploaded = connector.UploadDataSet(@"C:\Users\Kuba\Downloads\weather.arff",
                new UploadDatasetDescription("KubaDataset", "KubaTestTestTest"));
            var tagged = connector.UntagDataSet(uploaded.Id, "testtag");
            var untagged = connector.UntagDataSet(uploaded.Id, "testtag");
            var deletedDataset = connector.DeleteDataset(uploaded.Id);
            var flowsOwnedByMe = connector.FlowOwnedByMe();
        }
    }
}
