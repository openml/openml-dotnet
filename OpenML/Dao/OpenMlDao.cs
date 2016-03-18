using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using OpenML.Response.FreeQuery;
using RestSharp;

namespace OpenML.Dao
{
    public class OpenMlDao
    {   
        public string OpenMlHost { get; }

        private string UrlEndpoint => OpenMlHost + "api_new/v1/";

        private string FreeApiEndpoint => OpenMlHost + "api_query/";

        private readonly RestClient _client;

        public OpenMlDao(string endpointUrl)
        {
            OpenMlHost = endpointUrl;
            _client = new RestClient(UrlEndpoint) {Timeout = int.MaxValue};
        }

        public T ExecuteRequest<T>(string url, List<Parameter> parameters = null, Method method = Method.GET, List<FileParameter> files = null) where T : class, new()
        {
            var request = new RestRequest(url, method)
            {
                DateFormat = "yyyy-MM-dd HH:mm:ss"
            };
            if (parameters!=null)
            {
                request.Parameters.AddRange(parameters);
            }
            if (files != null)
            {
                foreach (var fileParameter in files)
                {
                    request.AddFile(fileParameter.ParameterName, fileParameter.Content, fileParameter.FileName);
                }
            }
            IRestResponse<T> response = _client.Execute<T>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                //TODO: log error
                return null;
            }
            return response.Data;
        }

        public T ExecuteAuthenticatedRequest<T>(string url,string apiKey, List<Parameter> parameters = null, Method method = Method.GET, List<FileParameter> files = null) where T : class, new()
        {
            var paramsWithApiKey = parameters ?? new List<Parameter>();            
            paramsWithApiKey.Add(new Parameter { Name="api_key",Value= apiKey, Type = ParameterType.QueryString});            
            return ExecuteRequest<T>(url, paramsWithApiKey, method, files);
        }

        public FreeQueryResult ExecuteFreeQuery(string freeQuery)
        {
            var freeQueryClient = new RestClient(FreeApiEndpoint);
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
