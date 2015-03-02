using System.Security.Cryptography;
using System.Text;
using RestSharp;

namespace OpenML
{
    public class OpenMlConnector
    {
        private string _user = "";
        private string _password = "";

        public OpenMlConnector()
        {
            var client = new RestClient("http://openml.org/api/");
            var request = new RestRequest("?f=openml.authenticate", Method.POST);
            request.AddParameter("username", _user); // replaces matching token in request.Resource
            request.AddParameter("password", CalculateMD5Hash(_password)); // replaces matching token in request.Resource
            IRestResponse<AuthenticationResponse> response = client.Execute<AuthenticationResponse>(request);
            var content = response.Content;

            var request2=new RestRequest("?f=openml.data", Method.POST);
            request2.AddParameter("session_hash", response.Data.Hash);
            IRestResponse response2 = client.Execute(request2);
            var content2 = response2.Content;
        }


        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }


}
