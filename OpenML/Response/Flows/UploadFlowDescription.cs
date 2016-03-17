//using System.Text;

//namespace OpenML.Response.Flows
//{
//    public class UploadFlowDescription
//    {
//        public string Name { get; set; }
//        public string Description { get; set; }

//        public UploadFlowDescription(string name, string description)
//        {
//            Name = name;
//            Description = description;
//        }

//        public string ToXml()
//        {
//            var sb = new StringBuilder();
//            sb.Append("<oml:flow xmlns:oml=\"http://openml.org/openml\">");
//            sb.Append($"<oml:name>{Name}</oml:name>");
//            sb.Append($"<oml:description>{Description}</oml:description>");
//            sb.Append("</oml:flow>");
//            return sb.ToString();
//        }

//    }
//}
