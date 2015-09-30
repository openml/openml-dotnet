using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using OpenML.Response.FreeQuery;
using RestSharp;


namespace OpenML.Dao
{
    public class OpenMlDao
    {        
        private string _urlEndpoint = "http://www.openml.org/api_new/v1/";
        private string _freeApiEndpoint = "http://www.openml.org/api_query/";
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
            var request = new RestRequest(url, Method.GET);
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

        public T ExecuteAuthenticatedRequest<T>(string url,string apiKey, List<Parameter> parameters = null) where T : class, new()
        {
            var paramsWithApiKey = parameters ?? new List<Parameter>();            
            paramsWithApiKey.Add(new Parameter { Name="api_key",Value= apiKey, Type = ParameterType.QueryString});            
            return ExecuteRequest<T>(url, paramsWithApiKey);
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
