using RestSharp.Deserializers;

namespace OpenML.Response
{
    public class EstimationProcedure
    {
        public int Id { get; set; }
        public int Ttid { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public int Repeats { get; set; }
        public int Folds { get; set; }

        public bool StratifiedSampling { get; set; }
    }
}
