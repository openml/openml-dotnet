using RestSharp.Deserializers;

namespace OpenML.Response.Tasks
{
    public class Input
    {
        public string Name { get; set; }
        [DeserializeAs(Name = "estimation_procedure")]
        public Templates.EstimationProcedure EstimationProcedure { get; set; }
        public Templates.Dataset Dataset { get; set; }
        public string CostMatrix { get; set; }
        public Templates.EvaluationMeasures EvaluationMeasures { get; set; }
    }
}