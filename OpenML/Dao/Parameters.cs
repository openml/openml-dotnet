using RestSharp;
using System;
using System.Collections.Generic;

namespace OpenML.Dao
{
    public class Parameters : List<Parameter>
    {
        public void AddParameter(string name, Object value)
        {
            Add(new Parameter() { Name = name, Value = value, Type = ParameterType.GetOrPost});
        }
    }
}
