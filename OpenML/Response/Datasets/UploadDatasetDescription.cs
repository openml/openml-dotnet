using System.Text;

namespace OpenML.Response.Datasets
{
    public class UploadDatasetDescription
    {
        public string DatasetDescription { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }

        //TODO: add optional fields

        public UploadDatasetDescription(string name, string datasetDescription, string format = "ARFF")
        {
            DatasetDescription = datasetDescription;
            Name = name;
            Format = format;
        }

        public string ToXml()
        {
            var sb = new StringBuilder();
            sb.Append("<oml:data_set_description xmlns:oml=\"http://openml.org/openml\">");
            sb.Append(
                $"<oml:name>{Name}</oml:name><oml:description>{DatasetDescription}</oml:description><oml:format>{Format}</oml:format >");
            sb.Append("</oml:data_set_description>");
            return sb.ToString();
        }
    }
}
