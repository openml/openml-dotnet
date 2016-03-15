using System.Collections.Generic;
using OpenML.Dao;
using OpenML.Response;
using OpenML.Response.DataQuality;
using OpenML.Response.Datasets;
using OpenML.Response.Flows;
using OpenML.Response.FreeQuery;
using OpenML.Response.OpenMlRun;
using OpenML.Response.Tasks;
using RestSharp;
using Quality = OpenML.Response.Datasets.Quality;

namespace OpenML
{
    /// <summary>
    /// Connector to OpenMl API
    /// </summary>
    public class OpenMlConnector
    {
        private readonly OpenMlDao _dao;

        private string ApiKey { get; set; }

        /// <summary>
        /// Creates OpenMlConnector instance and automatically connect
        /// </summary>
        /// <param name="apiKey">OpenMl apiKey</param>
        public OpenMlConnector(string apiKey)
        {
            _dao = new OpenMlDao();
            ApiKey = apiKey;
        }

        /// <summary>
        /// Gets dataset description by id
        /// </summary>
        /// <param name="datasetId">Id of the dataset</param>
        /// <returns>Dataset desription with the specified id</returns>
        public DatasetDescription GetDatasetDescription(int datasetId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("id", datasetId);
            return _dao.ExecuteAuthenticatedRequest<DatasetDescription>("/data/{id}", ApiKey, parameters);
        }

        public List<Feature> GetDataFeatures(int datasetId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("id", datasetId);
            return _dao.ExecuteAuthenticatedRequest<List<Feature>>("/data/features/{id}", ApiKey, parameters);
        }

        public List<Quality> GetDatasetQualities(int datasetId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("id", datasetId);
            return _dao.ExecuteAuthenticatedRequest<List<Quality>>("/data/qualities/{id}", ApiKey, parameters);
        }

        /// <summary>
        /// List all datasets in the OpenMl repository
        /// </summary>
        /// <returns>List of datasets</returns>
        public List<Response.Dataset> ListDatasets()
        {
            return _dao.ExecuteAuthenticatedRequest<Data>("/data/list/", ApiKey).Datasets;
        }

        /// <summary>
        /// List all data qualities (metafeatures) names
        /// </summary>
        /// <returns>List of names</returns>
        public List<string> ListDataQualities()
        {
            return _dao.ExecuteAuthenticatedRequest<DataQualitiesList>("/data/qualities/list", ApiKey).QualitiesNames;
        }

        //TODO: upload dataset
        //Tag Dataset
        //UnTag Dataset

        public DataDelete DeleteDataset(int datasetId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("id", datasetId);
            return _dao.ExecuteAuthenticatedRequest<DataDelete>("/data/{id}", ApiKey, parameters, Method.DELETE);
        }

        /// <summary>
        /// List all evaluation measures used in OpenMl
        /// </summary>
        /// <returns>List of evaluation measures</returns>
        public EvaluationMeasures ListEvaluationMeasures()
        {
            return _dao.ExecuteAuthenticatedRequest<EvaluationMeasures>("evaluationmeasure/list", ApiKey);
        }

        /// <summary>
        /// List all task types in OpenMl, currently not implemented in the API
        /// </summary>
        /// <returns>List of task types</returns>
        public List<TaskType> ListTaskTypes()
        {
            return _dao.ExecuteAuthenticatedRequest<List<TaskType>>("tasktype/list", ApiKey);
        }

        public List<Task> ListTasks()
        {
            return _dao.ExecuteAuthenticatedRequest<List<Task>>("task/list", ApiKey);
        }

        /// <summary>
        /// Get task type by id
        /// </summary>
        /// <param name="taskTypeId">Id of the task type</param>
        /// <returns>Task type with the specified id</returns>
        public TaskType GetTaskType(int taskTypeId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("task_id", taskTypeId);
            return _dao.ExecuteAuthenticatedRequest<TaskType>("tasktype/{task_id}", ApiKey, parameters);
        }

        //public Task GetTask(int taskId)
        //{
        //    var parameters = new Parameters();
        //    parameters.AddUrlSegment("task_id", taskId);
        //    return _dao.ExecuteAuthenticatedRequest<Task>("task/{task_id}", ApiKey, parameters);
        //}

        /// <summary>
        /// Get estimation procedure by id
        /// </summary>
        /// <param name="estimationprocedureId">Id of the estimation procedure</param>
        /// <returns>Estimation procedure with specified Id</returns>
        public EstimationProcedure GetEstimationProcedure(int estimationprocedureId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("proc_id", estimationprocedureId);
            return _dao.ExecuteAuthenticatedRequest<EstimationProcedure>("estimationprocedure/{proc_id}", ApiKey, parameters);
        }

        public List<EstimationProcedure> ListEstimationProcedures()
        {
            return _dao.ExecuteAuthenticatedRequest<List<EstimationProcedure>>("estimationprocedure/list", ApiKey);
        } 

        /// <summary>
        /// Get details of the selected run
        /// </summary>
        /// <param name="runId">Id of the run in question</param>
        /// <returns>Run details</returns>
        public Run GetRun(int runId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("run_id", runId);
            return _dao.ExecuteAuthenticatedRequest<Run>("run/{run_id}", ApiKey, parameters);
        }

        public List<Flow> GetFlows()
        {
            var parameters = new Parameters();
            return _dao.ExecuteAuthenticatedRequest<List<Flow>>("/flow/list", ApiKey, parameters);
        }

        public FlowDetail GetFlow(int flowId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("flow_id", flowId);
            return _dao.ExecuteAuthenticatedRequest<FlowDetail>("flow/{flow_id}", ApiKey, parameters);
        }

        /// <summary>
        /// Checks whether a flow with the given name and (external) version exists.
        /// </summary>
        /// <returns></returns>
        public FlowExist FlowExist(string name, string externalVersion)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("version", externalVersion);
            parameters.AddUrlSegment("name", name);
            return _dao.ExecuteAuthenticatedRequest<FlowExist>("flow/exists/{name}/{version}", ApiKey, parameters);
        }

        public List<int> FlowOwnedByMe()
        {
            var parameters = new Parameters();
            return _dao.ExecuteAuthenticatedRequest<List<int>>("flow/owned", ApiKey, parameters);
        } 

        /// <summary>
        /// Executes free query on the openMl database
        /// </summary>
        /// <param name="freeQuery">Sql query to execute</param>
        /// <returns>Query result with data, columns and status</returns>
        public FreeQueryResult ExecuteFreeQuery(string freeQuery)
        {
            var result= _dao.ExecuteFreeQuery(freeQuery);
            return result;
        }

        public void UploadFile()
        {
            string filePath = "dataset_61_iris.arff";
            var parameters = new Parameters();
            var content = System.IO.File.ReadAllText(filePath);
            string description = @"
<oml:data_set_description xmlns:oml=""http://openml.org/openml"">
    <oml:name>irisTestUpload</oml:name>
  <oml:version>1</oml:version>
  <oml:description>Test of .Net upload</oml:description>
  <oml:format>ARFF</oml:format>
  <oml:creator>R.A. Fisher</oml:creator>		
<oml:collection_date>1936</oml:collection_date>	
<oml:upload_date>2014-04-06 23:23:39</oml:upload_date>
    <oml:licence>Public</oml:licence>  
  <oml:default_target_attribute>class</oml:default_target_attribute>   
<oml:version_label>1</oml:version_label>   
<oml:tag>uci</oml:tag>
<oml:visibility>public</oml:visibility> 
<oml:original_data_url>https://archive.ics.uci.edu/ml/datasets/Iris</oml:original_data_url> 
<oml:paper_url>http://digital.library.adelaide.edu.au/dspace/handle/2440/15227</oml:paper_url>
<oml:status>active</oml:status>
  <oml:md5_checksum>3a212cce13fc6f9b94f4793285813d95</oml:md5_checksum>
</oml:data_set_description>";
            parameters.AddPostParameter("description",description);
            parameters.AddContentParameter("dataset",content );
            _dao.ExecuteAuthenticatedRequest<Run>("openml.data.upload", ApiKey, parameters);
        }

    }
}
