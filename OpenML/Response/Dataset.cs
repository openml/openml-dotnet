using System.Collections.Generic;
using RestSharp.Deserializers;

namespace OpenML.Response
{
    public class Dataset
    {
        public string Name { get; set; }

        public string Status { get; set; }

        [DeserializeAs(Name = "did")]
        public int Id { get; set; }

        public List<Quality> Qualities { get; set; }
    }
}
