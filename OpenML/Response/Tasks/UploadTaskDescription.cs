using System.Collections.Generic;
using System.Text;

namespace OpenML.Response.Tasks
{
    public class InputDescription
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public InputDescription(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }

    public class UploadTaskDescription
    {
        public int TaskTypeId { get; set; }
        public List<InputDescription> Inputs { get; set; }
        
        public UploadTaskDescription(int taskTypeId, List<InputDescription> inputs)
        {
            TaskTypeId = taskTypeId;
            Inputs = inputs;
        }

        public string ToXml()
        {
            var sb = new StringBuilder();
            sb.Append("<oml:task_new xmlns:oml=\"http://openml.org/openml\">");
            sb.Append($"<oml:task_type_id>{TaskTypeId}</oml:task_type_id>");
            foreach (var inputDescription in Inputs)
            {
                sb.Append($"<oml:input name=\"{inputDescription.Name}\">{inputDescription.Value}</oml:input>");
            }
            sb.Append("</oml:task_new>");
            return sb.ToString();
        }
    }
}
