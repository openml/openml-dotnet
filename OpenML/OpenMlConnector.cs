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
            var licences = ListLicences(authenticate.Hash);
            var data = ListData(authenticate.Hash);
            string a = "";
        }

        public Authenticate Connect(string user, string password)
        {
            var parameters = new Parameters();
            parameters.AddParameter("username", user);
            parameters.AddParameter("password", Utilities.CalculateMd5Hash(password));
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
    }
}
