using System.Collections.Generic;
using RestSharp.Deserializers;

namespace OpenML.Response.OpenMlRun
{
    public class Run
    {
        [DeserializeAs(Name = "run_id")]
        public int Id { get; set; }

        public int Uploader { get; set; }

        public int TaskId { get; set; }

        public int ImplementationId { get; set; }

        public int SetupId { get; set; }

        [DeserializeAs(Name = "setup_string")]
        public string Setup { get; set; }

        public List<ParameterSetting> ParameterSettings { get; set; }

        public List<Tag> Tags { get; set; }

        public OutputData OutputData { get; set; }

        public InputData InputData { get; set; }
    }
}
