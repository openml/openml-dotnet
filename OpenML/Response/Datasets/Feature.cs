namespace OpenML.Response.Datasets
{
    public class Feature
    {
        public int Index { get; set; }
        public string DataType { get; set; }
        public string Name { get; set; }
        public bool IsTarget { get; set; }
        public bool IsIgnore { get; set; }
        public bool IsRowIdentifier { get; set; }
    }
}
