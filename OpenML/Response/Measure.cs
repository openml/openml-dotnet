using System;
using RestSharp.Deserializers;

namespace OpenML.Response
{
    public class Measure
    {
        [DeserializeAs(Name = "Value")]
        public String Name { get; set; }
    }
}
