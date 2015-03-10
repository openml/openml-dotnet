using System.Collections.Generic;
using OpenML.Authentication;
using OpenML.Dao;
using OpenML.Response;

namespace OpenML
{
    public class OpenMlConnector
    {
        private readonly OpenMlDao _dao;

        public OpenMlConnector(string username,string password)
        {
            _dao = new OpenMlDao();
            var authenticate = Connect(username, password);
            var taskTypes = ListTaskTypes(authenticate.Hash);
            var datasetDescription = GetDatasetDescription(authenticate.Hash, 1);
            var licences = ListLicences(authenticate.Hash);
            var data = ListData(authenticate.Hash);
            string a = "";
        }

        public Authenticate Connect(string user, string password)
        {
            var parameters = new Parameters();
            parameters.AddPostParameter("username", user);
            parameters.AddPostParameter("password", Utilities.CalculateMd5Hash(password));
            return _dao.ExecuteRequest<Authenticate>("openml.authenticate", parameters);
        }  
        
        public Data ListData(string hash)
        {
            return _dao.ExecuteAuthenticatedRequest<Data>("openml.data", hash);
        }

        public List<Licence> ListLicences(string hash)
        {
            return _dao.ExecuteAuthenticatedRequest<List<Licence>>("openml.data.licences", hash);
        }

        public List<TaskType> ListTaskTypes(string hash)
        {
            return _dao.ExecuteAuthenticatedRequest<List<TaskType>>("openml.task.types", hash);
        }

        public DatasetDescription GetDatasetDescription(string hash, int datasetId)
        {
            var parameters = new Parameters();
            parameters.AddQueryStringParameter("data_id",datasetId);
            return _dao.ExecuteAuthenticatedRequest<DatasetDescription>("openml.data.description", hash, parameters);
        }
    }
}
