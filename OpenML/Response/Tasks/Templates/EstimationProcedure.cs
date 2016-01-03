using System.Collections.Generic;

namespace OpenML.Response.Tasks.Templates
{
    //Template
    public class EstimationProcedure
    {
        public string Type { get; set; }
        public string DataSplitsUrl { get; set; }
        public List<Parameter> Parameters { get; set; } 

        //<oml:type>[LOOKUP: estimation_procedure.type]</oml:type>
        //<oml:data_splits_url>[CONSTANT: base_url]api_splits/get/[TASK: id]/Task_[TASK:id] _splits.arff</oml:data_splits_url>
        //<oml:parameter name = "number_repeats" >[LOOKUP: estimation_procedure.repeats] </ oml:parameter>
        //<oml:parameter name = "number_folds" >[LOOKUP: estimation_procedure.folds] </ oml:parameter>
        //<oml:parameter name = "percentage" >[LOOKUP: estimation_procedure.percentage] </ oml:parameter>
        //<oml:parameter name = "stratified_sampling" >[LOOKUP: estimation_procedure.stratified_sampling] </ oml:parameter>
        //</oml:estimation_procedure>
    }
}
