using System;
using RestSharp.Deserializers;

namespace OpenML.Response.Tasks
{
    public class Contributor
    {
        [DeserializeAs(Name = "Value")]
        public String Name { get; set; }
    }
}
