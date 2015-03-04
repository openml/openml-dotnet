using OpenML.Authentication;
using OpenML.Response;
using RestSharp;

namespace OpenML
{
    public class OpenMlConnector
    {
        private string _user = "";
        private string _password = "";
        private string _urlEndpoint = "http://openml.org/api/";
        private RestClient _client;

        public OpenMlConnector()
        {
            _client = new RestClient(_urlEndpoint);

            var authenticate = Connect(_user, _password);
            var request2=new RestRequest("?f=openml.data", Method.POST);
            request2.AddParameter("session_hash", authenticate .Hash);
            IRestResponse<Data> response2 = _client.Execute<Data>(request2);
            var content2 = response2.Content;
        }

        public Authenticate Connect(string user, string password)
        {
            var request = new RestRequest("?f=openml.authenticate", Method.POST);
            request.AddParameter("username", user);
            request.AddParameter("password", Utilities.CalculateMd5Hash(password));
            IRestResponse<Authenticate> response = _client.Execute<Authenticate>(request);
            return response.Data;
        }

        
    }


}
