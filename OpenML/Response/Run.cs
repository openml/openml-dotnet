using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace OpenML.Response
{
    public class Run
    {
        [DeserializeAs(Name = "run_id")]
        public int Id { get; set; }

        public int Uploader { get; set; }

        public int TaskId { get; set; }

        public int ImplementationId { get; set; }

        public int SetupId { get; set; }

        [DeserializeAs(Name = "setup_string")]
        public string Setup { get; set; }

        public List<ParameterSetting> ParameterSettings { get; set; } 

        public List<Tag> Tags { get; set; }

        public OutputData OutputData { get; set; }
        /*               
        <oml:input_data>
          <oml:dataset>
        <oml:did>2</oml:did>
        <oml:name>anneal.ORIG</oml:name>
        <oml:url>http://openml.liacs.nl/data/download/2/dataset_2_anneal.ORIG.arff</oml:url>
      </oml:dataset>
          <oml:dataset>
        <oml:did>9</oml:did>
        <oml:name>autos</oml:name>
        <oml:url>http://openml.liacs.nl/data/download/9/dataset_9_autos.arff</oml:url>
      </oml:dataset>
          <oml:dataset>
        <oml:did>54</oml:did>
        <oml:name>vehicle</oml:name>
        <oml:url>http://openml.liacs.nl/data/download/54/dataset_54_vehicle.arff</oml:url>
      </oml:dataset>
        </oml:input_data>  
        <oml:output_data>
                <oml:file>
        <oml:did>63</oml:did>
        <oml:file_id>63</oml:file_id>
        <oml:name>description</oml:name>
        <oml:url>http://openml.org/data/download/63/weka_generated_run5258986433356798974.xml</oml:url>
      </oml:file>
            <oml:file>
        <oml:did>3987986</oml:did>
        <oml:file_id>313413</oml:file_id>
        <oml:name>model_readable</oml:name>
        <oml:url>http://openml.org/data/download/313413/WekaModel_weka.classifiers.bayes.AveragedNDependenceEstimators.A1DE2474025000319897700.model</oml:url>
      </oml:file>
            <oml:file>
        <oml:did>4296204</oml:did>
        <oml:file_id>622143</oml:file_id>
        <oml:name>model_serialized</oml:name>
        <oml:url>http://openml.org/data/download/622143/WekaSerialized_weka.classifiers.bayes.AveragedNDependenceEstimators.A1DE3739675682024987582.model</oml:url>
      </oml:file>
            <oml:file>
        <oml:did>64</oml:did>
        <oml:file_id>64</oml:file_id>
        <oml:name>predictions</oml:name>
        <oml:url>http://openml.org/data/download/64/weka_generated_predictions5823074444642592781.arff</oml:url>
      </oml:file>                     
        
            </oml:output_data>
  </oml:run>

        */
    }
}
