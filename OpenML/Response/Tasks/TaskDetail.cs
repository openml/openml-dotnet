using System.Collections.Generic;

namespace OpenML.Response.Tasks
{
    public class TaskDetail
    {
        public int TaskId { get; set; }
        public string TaskType { get; set; }
        public List<Tag> Tags { get; set; } 
        public List<Input> Inputs { get; set; } 
        public Output Output { get; set; }
    }
}
