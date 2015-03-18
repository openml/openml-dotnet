using RestSharp.Deserializers;

namespace OpenML.Response
{
    public class EstimationProcedure
    {
        [DeserializeAs(Name = "ttid")]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public int Repeats { get; set; }

        public bool StratifiedSampling { get; set; }
        //       <oml:estimationprocedure xmlns:oml="http://openml.org/openml">
        // <oml:ttid>1</oml:ttid>
        //<oml:name>10-fold Crossvalidation</oml:name>
        //<oml:type>crossvalidation</oml:type>
        //<oml:repeats>1</oml:repeats> 	<oml:folds>10</oml:folds>
        //<oml:stratified_sampling>true</oml:stratified_sampling></oml:estimationprocedure>
    }
}
