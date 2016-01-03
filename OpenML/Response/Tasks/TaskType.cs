using System;
using System.Collections.Generic;
using OpenML.Response.Tasks.Templates;

namespace OpenML.Response.Tasks
{
    public class Output
    {
        public string Name { get; set; }
        public Predictions Predictions { get; set; }
    }

    public class TaskType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Contributor> Contributors { get; set; }
        public DateTime Date { get; set; }
        public List<Input> Inputs { get; set; }
        public List<Output> Outputs { get; set; }
    }
}

