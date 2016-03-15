namespace OpenML.Response.Flows
{
    public class Flow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public double Version { get; set; }
        public string ExternalVersion { get; set; }
        public int Uploader { get; set; }
    }
}
