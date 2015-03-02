using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace OpenML
{
    [DeserializeAs(Name = "authenticate")]
    public class AuthenticationResponse
    {

        [DeserializeAs(Name = "session_hash")]
        public string Hash { get; set; }

        [DeserializeAs(Name = "timezone")]
        public string Timezone { get; set; }
    }
}
