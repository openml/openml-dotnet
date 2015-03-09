using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenML.Dao
{
    public class Parameters : List<Parameter>
    {
        public void AddParameter(string name, Object value)
        {
            Add(new Parameter() { Name = name, Value = value });
        }
    }
}
