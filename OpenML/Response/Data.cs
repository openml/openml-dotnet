using System.Collections.Generic;
using RestSharp.Deserializers;

namespace OpenML.Response
{
    [DeserializeAs(Name = "data")]
    public class Data
    {
        public List<Dataset> Datasets { get; set; }
    }
}
