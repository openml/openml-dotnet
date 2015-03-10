using System;
using RestSharp.Deserializers;

namespace OpenML.Response
{
    public class Licence
    {
        [DeserializeAs(Name = "Value")]
        public String Name { get; set; }
    }
}
