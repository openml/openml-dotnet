using System;
using RestSharp.Deserializers;

namespace OpenML.Response
{
    public class Tag
    {
        [DeserializeAs(Name = "Value")]
        public String Name { get; set; }
    }
}
