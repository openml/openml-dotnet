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

        public OpenMlConnector()
        {
            var client = new RestClient(_urlEndpoint);
            var request = new RestRequest("?f=openml.authenticate", Method.POST);
            request.AddParameter("username", _user); 
            request.AddParameter("password", Utilities.CalculateMd5Hash(_password));
            IRestResponse<Authenticate> response = client.Execute<Authenticate>(request);

            var request2=new RestRequest("?f=openml.data", Method.POST);
            request2.AddParameter("session_hash", response.Data.Hash);
            IRestResponse<Data> response2 = client.Execute<Data>(request2);
            var content2 = response2.Content;
        }


        
    }


}
