using System;
using System.Collections.Generic;

namespace OpenML.Response.Flows
{
    public class FlowDetail
    {
        public int Id { get; set; }
        public int Uploader { get; set; }
        public string Name { get; set; }
        public double Version { get; set; }
        public string ExternalVersion { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; } 
        public string Language { get; set; }
        public string Dependencies { get; set; }
        public List<Parameter> Parameters { get; set; }
        public string Tag { get; set; }
    }
}
