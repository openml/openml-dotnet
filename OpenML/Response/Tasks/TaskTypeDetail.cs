using System;
using System.Collections.Generic;

namespace OpenML.Response.Tasks
{
    public class TaskTypeDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Contributor> Contributors { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Input> Inputs { get; set; }
        public Output Output { get; set; }
    }
}

