using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using OpenML.Response.FreeQuery;
using RestSharp;


namespace OpenML.Dao
{
    public class OpenMlDao
    {        
        private string _urlEndpoint = "http://openml.org/rest_api/";
        private string _freeApiEndpoint = "http://openml.org/api_query/";
        private const string QueryPrefix = "?f=";
        private RestClient _client;

        public OpenMlDao()
        {
            _client = new RestClient(_urlEndpoint);            
        }

        public OpenMlDao(string endpointUrl)
        {
            _client = new RestClient(endpointUrl);
        }

        public T ExecuteRequest<T>(string url,List<Parameter> parameters=null) where T : class, new()
        {
            var request = new RestRequest(QueryPrefix+url, Method.POST);
            if (parameters!=null)
            {
                request.Parameters.AddRange(parameters);
            }
            IRestResponse<T> response = _client.Execute<T>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                //TODO: log error
                return null;
            }
            return response.Data;
        }

        public T ExecuteAuthenticatedRequest<T>(string url,string hash, List<Parameter> parameters = null) where T : class, new()
        {
            var paramsWithHash = parameters ?? new List<Parameter>();            
            paramsWithHash.Add(new Parameter { Name="session_hash",Value= hash,Type = ParameterType.GetOrPost});            
            return ExecuteRequest<T>(url, paramsWithHash);
        }

        public FreeQueryResult ExecuteFreeQuery(string freeQuery)
        {
            var freeQueryClient = new RestClient(_freeApiEndpoint);
            var request = new RestRequest("?q="+freeQuery, Method.POST);
            var response = freeQueryClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                //TODO: log error
                return null;
            }
            var result = JsonConvert.DeserializeObject<FreeQueryResult>(response.Content);
            return result;
        }
    }
}
