using System;
using RestSharp.Deserializers;

namespace OpenML.Response.Tasks.Templates
{
    public class EvaluationMeasure
    {
        [DeserializeAs(Name = "Value")]
        public String Name { get; set; }
    }
}
