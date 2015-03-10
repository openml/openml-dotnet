using RestSharp.Deserializers;

namespace OpenML.Response
{
    /// <summary>
    /// Authenticate response of the OpenMl API
    /// </summary>
    public class Authenticate
    {

        [DeserializeAs(Name = "session_hash")]
        public string Hash { get; set; }
        
        public string Timezone { get; set; }
    }
}
