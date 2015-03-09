using OpenML.Authentication;
using OpenML.Dao;
using OpenML.Response;
using RestSharp;

namespace OpenML
{
    public class OpenMlConnector
    {
        private string _user = "";
        private string _password = "";
        private OpenMlDao _dao;

        public OpenMlConnector()
        {
            _dao = new OpenMlDao();

            var authenticate = Connect(_user, _password);
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
    }


}
