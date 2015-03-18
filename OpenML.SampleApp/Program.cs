namespace OpenML.SampleApp
{
    /// <summary>
    /// Sample application with examples how to use OpenMl connector to obtain openMl entities
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var connector = new OpenMlConnector("","");
            var dataQualities = connector.ListDataQualities();
            var taskTypes = connector.ListTaskTypes();
            var taskType = connector.GetTaskType(1);
            var datasetDescription = connector.GetDatasetDescription(1);
            var licences = connector.ListLicences();
            var data = connector.ListDatasets();
            string a = "";

        }
    }
}
