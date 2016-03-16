using RestSharp.Deserializers;

namespace OpenML.Response.OpenMlRun
{
    public class Run
    { 
        [DeserializeAs(Name = "run_id")]
        public int Id { get; set; }

        public int TaskId { get; set; }

        public int SetupId { get; set; }

        public int FlowId { get; set; }

        public int Uploader { get; set; }

        public string ErrorMessage { get; set; }
    }
}
