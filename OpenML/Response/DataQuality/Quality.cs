using RestSharp.Deserializers;

namespace OpenML.Response.DataQuality
{
    /// <summary>
    /// Data quality, aka. metafeature
    /// </summary>
    public class Quality
    {
        /// <summary>
        /// Metafeature name
        /// </summary>
        [DeserializeAs(Name = "Value")]
        public string Name { get; set; }
    }
}
