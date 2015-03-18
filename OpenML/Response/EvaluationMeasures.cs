using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace OpenML.Response
{
    [DeserializeAs(Name = "evaluation_measures")]
    public class EvaluationMeasures
    {
        public List<Measure> Measures { get; set; } 
    }
}
