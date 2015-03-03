using RestSharp.Deserializers;

namespace OpenML.Response
{
    public class Authenticate
    {

        [DeserializeAs(Name = "session_hash")]
        public string Hash { get; set; }
        
        public string Timezone { get; set; }
    }
}
