using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenML.Response.Tasks.Templates
{
    public class Predictions
    {
        public List<Feature> Features { get; set; } 
        public string Format { get; set; }
    }
}
