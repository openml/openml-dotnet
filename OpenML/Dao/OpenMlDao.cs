﻿using RestSharp;
using System.Collections.Generic;

namespace OpenML
{
    public class OpenMlDao
    {        
        private string _urlEndpoint = "http://openml.org/api/";
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

        public T ExecuteRequest<T>(string url,List<Parameter> parameters=null) where T : new()
        {
            var request = new RestRequest(QueryPrefix+url, Method.POST);
            if (parameters!=null)
            {
                request.Parameters.AddRange(parameters);
            }
            IRestResponse<T> response = _client.Execute<T>(request);
            return response.Data;
        }

        public T ExecuteAuthenticatedRequest<T>(string url,string hash, List<Parameter> parameters = null) where T : new()
        {
            var paramsWithHash = parameters != null ? parameters : new List<Parameter>();            
            paramsWithHash.Add(new Parameter() { Name="session_hash",Value= hash });            
            return ExecuteRequest<T>(url, paramsWithHash);
        }
    }
}
