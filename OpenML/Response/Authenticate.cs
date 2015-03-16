using System;
using RestSharp.Deserializers;

namespace OpenML.Response
{
    /// <summary>
    /// Authenticate response of the OpenMl API
    /// </summary>
    public class Authenticate
    {
        /// <summary>
        /// Session hash of the validation response
        /// </summary>
        [DeserializeAs(Name = "session_hash")]
        public string Hash { get; set; }
        
        /// <summary>
        /// Timezone where the authentication response was issued
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// End of validaty of the hash
        /// </summary>
        public DateTime ValidUntil { get; set; }
    }
}
