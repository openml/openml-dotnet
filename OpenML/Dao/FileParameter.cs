namespace OpenML.Dao
{
    public class FileParameter
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ParameterName { get; set; }

        public FileParameter() { }

        public FileParameter(string parameterName, string path)
        {
            ParameterName = parameterName;
            Content = System.IO.File.ReadAllBytes(path);
            FileName = System.IO.Path.GetFileName(path);
        }
    }
}
