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
using FileParameter = OpenML.Dao.FileParameter;
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

        /// <summary>
        /// List all datasets in the OpenMl repository
        /// </summary>
        /// <returns>List of datasets</returns>
        public List<Response.Dataset> ListDatasets()
        {
            return _dao.ExecuteAuthenticatedRequest<Data>("/data/list/", ApiKey).Datasets;
        }

        public List<Response.Dataset> ListDatasetsWithTag(string tag)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("tag", tag);
            return _dao.ExecuteAuthenticatedRequest<Data>("/data/list/tag/{tag}", ApiKey).Datasets;
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
        /// List all data qualities (metafeatures) names
        /// </summary>
        /// <returns>List of names</returns>
        public List<string> ListDataQualities()
        {
            return _dao.ExecuteAuthenticatedRequest<DataQualitiesList>("/data/qualities/list", ApiKey).QualitiesNames;
        }

        public UploadDataSet UploadDataSet(string datasetPath, UploadDatasetDescription datasetDescription)
        {
            var parameters = new Parameters();
            parameters.AddPostParameter("description", datasetDescription.ToXml());
            var fileParameters = new List<FileParameter>
            {
                new FileParameter
                {
                    ParameterName = "dataset",
                    Content = System.IO.File.ReadAllBytes(datasetPath),
                    FileName = System.IO.Path.GetFileName(datasetPath)
                }
            };
            return _dao.ExecuteAuthenticatedRequest<UploadDataSet>("/data", ApiKey, parameters, Method.POST, fileParameters);
        }

        public DataTag TagDataSet(int datasetId, string tag)
        {
            var parameters = new Parameters();
            parameters.AddPostParameter("data_id", datasetId);
            parameters.AddPostParameter("tag", tag);
            return _dao.ExecuteAuthenticatedRequest<DataTag>("/data/tag", ApiKey, parameters, Method.POST);
        }

        public DataUntag UntagDataSet(int datasetId, string tag)
        {
            var parameters = new Parameters();
            parameters.AddPostParameter("data_id", datasetId);
            parameters.AddPostParameter("tag", tag);
            return _dao.ExecuteAuthenticatedRequest<DataUntag>("/data/untag", ApiKey, parameters, Method.POST);
        }

        public DataDelete DeleteDataset(int datasetId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("id", datasetId);
            return _dao.ExecuteAuthenticatedRequest<DataDelete>("/data/{id}", ApiKey, parameters, Method.DELETE);
        }

        //************************************ Task Section
        public TaskDetail GetTask(int taskId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("id", taskId);
            return _dao.ExecuteAuthenticatedRequest<TaskDetail>("/task/{id}", ApiKey, parameters);
        }

        public List<Task> ListTasks()
        {
            return _dao.ExecuteAuthenticatedRequest<List<Task>>("/task/list", ApiKey);
        }

        public List<Task> ListTasksOfType(int taskTypeId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("id", taskTypeId);
            return _dao.ExecuteAuthenticatedRequest<List<Task>>("/task/list/type/{id}", ApiKey, parameters);
        }

        public List<Task> ListTasksOfTag(string tag)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("tag", tag);
            return _dao.ExecuteAuthenticatedRequest<List<Task>>("/task/list/tag/{tag}", ApiKey, parameters);
        }

        public UploadTask UploadTask(UploadTaskDescription datasetDescription)
        {
            var parameters = new Parameters();
            var fileParameters = new List<FileParameter>
            {
                new FileParameter
                {
                    ParameterName = "description",
                    Content =  System.Text.Encoding.UTF8.GetBytes(datasetDescription.ToXml()),
                    FileName = "newtask.xml"
                }
            };
            return _dao.ExecuteAuthenticatedRequest<UploadTask>("/task", ApiKey, parameters, Method.POST, fileParameters);
        }

        public TagTask TagTask(int flowId, string tag)
        {
            var parameters = new Parameters();
            parameters.AddPostParameter("task_id", flowId);
            parameters.AddPostParameter("tag", tag);
            return _dao.ExecuteAuthenticatedRequest<TagTask>("/task/tag", ApiKey, parameters, Method.POST);
        }

        public UntagTask UntagTask(int taskId, string tag)
        {
            var parameters = new Parameters();
            parameters.AddPostParameter("task_id", taskId);
            parameters.AddPostParameter("tag", tag);
            return _dao.ExecuteAuthenticatedRequest<UntagTask>("/task/untag", ApiKey, parameters, Method.POST);
        }

        public DeleteTask DeleteTask(int taskId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("id", taskId);
            return _dao.ExecuteAuthenticatedRequest<DeleteTask>("/task/{id} ", ApiKey, parameters, Method.DELETE);
        }

        //************************************ TaskType
        /// <summary>
        /// Get task type by id
        /// </summary>
        /// <param name="taskTypeId">Id of the task type</param>
        /// <returns>Task type with the specified id</returns>
        public TaskTypeDetail GetTaskType(int taskTypeId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("id", taskTypeId);
            return _dao.ExecuteAuthenticatedRequest<TaskTypeDetail>("/tasktype/{id}", ApiKey, parameters);
        }

        /// <summary>
        /// List all task types in OpenMl, currently not implemented in the API
        /// </summary>
        /// <returns>List of task types</returns>
        public List<TaskType> ListTaskTypes()
        {
            return _dao.ExecuteAuthenticatedRequest<List<TaskType>>("tasktype/list", ApiKey);
        }

        //***********************************Flows
        public FlowDetail GetFlowDescription(int flowId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("id", flowId);
            return _dao.ExecuteAuthenticatedRequest<FlowDetail>("/flow/{id}", ApiKey, parameters);
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
            return _dao.ExecuteAuthenticatedRequest<FlowExist>("/flow/exists/{name}/{version}", ApiKey, parameters);
        }

        public List<Flow> ListFlows()
        {
            var parameters = new Parameters();
            return _dao.ExecuteAuthenticatedRequest<List<Flow>>("/flow/list", ApiKey, parameters);
        }

        public List<Flow> ListFlowsWithTag(string tag)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("tag", tag);
            return _dao.ExecuteAuthenticatedRequest<List<Flow>>("/run/list/tag/{tag}", ApiKey, parameters);
        }

        public List<int> FlowOwnedByMe()
        {
            var parameters = new Parameters();
            return _dao.ExecuteAuthenticatedRequest<List<int>>("flow/owned", ApiKey, parameters);
        }

        public FlowUpload UploadFlow(UploadFlowDescription datasetDescription, string flowSourcePath)
        {
            var parameters = new Parameters();
            parameters.AddPostParameter("description", datasetDescription.ToXml());
            var fileParameters = new List<FileParameter>
            {
                new FileParameter
                {
                    ParameterName = "flow",
                    Content = System.IO.File.ReadAllBytes(flowSourcePath),
                    FileName = System.IO.Path.GetFileName(flowSourcePath)
                }
            };
            return _dao.ExecuteAuthenticatedRequest<FlowUpload>("/flow", ApiKey, parameters, Method.POST, fileParameters);
        }

        public TagFlow TagFlow(int flowId, string tag)
        {
            var parameters = new Parameters();
            parameters.AddPostParameter("flow_id", flowId);
            parameters.AddPostParameter("tag", tag);
            return _dao.ExecuteAuthenticatedRequest<TagFlow>("/flow/tag", ApiKey, parameters, Method.POST);
        }

        public UntagFlow UntagFlow(int flowId, string tag)
        {
            var parameters = new Parameters();
            parameters.AddPostParameter("flow_id", flowId);
            parameters.AddPostParameter("tag", tag);
            return _dao.ExecuteAuthenticatedRequest<UntagFlow>("/flow/untag", ApiKey, parameters, Method.POST);
        }

        public DeleteFlow DeleteFlow(int flowId)
        {
            var parameters = new Parameters();
            parameters.AddUrlSegment("id", flowId);
            return _dao.ExecuteAuthenticatedRequest<DeleteFlow>("/flow/{id} ", ApiKey, parameters, Method.DELETE);
        }

        //****************************************

        /// <summary>
        /// List all evaluation measures used in OpenMl
        /// </summary>
        /// <returns>List of evaluation measures</returns>
        public EvaluationMeasures ListEvaluationMeasures()
        {
            return _dao.ExecuteAuthenticatedRequest<EvaluationMeasures>("evaluationmeasure/list", ApiKey);
        }

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
    }
}
