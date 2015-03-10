namespace OpenML.Response
{
    public class DatasetDescription
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Version { get; set; }

        public string Description { get; set; }

        public string Format { get; set; }

        public string UploadDate { get; set; }

        public string Licence { get; set; }

        public string Url { get; set; }
        public string Md5CheckSum { get; set; }

        public string VersionLabel { get; set; }

        public string Tag { get; set; }

        public string Visibility { get; set; }

        public string DefaultTargetAttribute { get; set; }

        public string Status { get; set; }

        public string OriginalDataUrl { get; set; }
    }
}