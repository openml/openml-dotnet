using RestSharp.Deserializers;

namespace OpenML.Response.Evaluations
{
    public class Evaluation
    {
        public int RunId { get; set; }
        public int TaskId { get; set; }
        public int SetupId { get; set; }
        public int FlowId { get; set; }
        public string Function { get; set; }
        public string ArrayData { get; set; }
        [DeserializeAs(Name = "value",Attribute = true)]
        public double? Value { get; set; }
    }
}
