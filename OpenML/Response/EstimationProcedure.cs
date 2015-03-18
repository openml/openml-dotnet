using RestSharp.Deserializers;

namespace OpenML.Response
{
    public class EstimationProcedure
    {
        [DeserializeAs(Name = "ttid")]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public int Repeats { get; set; }

        public bool StratifiedSampling { get; set; }
    }
}
