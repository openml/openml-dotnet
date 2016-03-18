using RestSharp;
using System.Collections.Generic;

namespace OpenML.Dao
{
    public class Parameters : List<Parameter>
    {
        public void AddPostParameter(string name, object value)
        {
            Add(new Parameter { Name = name, Value = value, Type = ParameterType.GetOrPost });
        }

        public void AddUrlSegment(string name, object value)
        {
            Add(new Parameter { Name = name, Value = value, Type = ParameterType.UrlSegment });
        }
    }
}
