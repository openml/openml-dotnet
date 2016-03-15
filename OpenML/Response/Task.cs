using System.Collections.Generic;

namespace OpenML.Response
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskType { get; set; }
        public int Did { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Format { get; set; }
        public List<Tag> Tags { get; set; } 
        public List<Quality> Qualities { get; set; } 
        public List<Input> Inputs { get; set; } 
    }

    public class Input
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
