using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenML.Response.DataQuality
{
    public class DataQualitiesList
    {
        public List<Quality> Qualities { get; set; }

        public List<String> QualitiesNames
        {
            get { return Qualities.Select(q => q.Name).ToList(); }
        }
    }
}
