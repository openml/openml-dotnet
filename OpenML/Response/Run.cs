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
                        <oml:evaluation>
          <oml:name>area_under_roc_curve</oml:name>
          <oml:implementation>4</oml:implementation>
          <oml:value>0.839359</oml:value>          <oml:array_data>[�,0.99113,0.898048,0.874862,0.791282,0.807343,0.820674]</oml:array_data>        </oml:evaluation>
              <oml:evaluation>
          <oml:name>confusion_matrix</oml:name>
          <oml:implementation>10</oml:implementation>
                    <oml:array_data>[[0,0,0,0,0,0,0],[0,0,30,0,0,0,0],[0,0,173,12,29,3,3],[0,0,24,515,87,41,3],[0,0,10,115,353,28,34],[0,0,14,77,77,127,25],[0,0,15,11,88,64,92]]</oml:array_data>        </oml:evaluation>
              <oml:evaluation>
          <oml:name>f_measure</oml:name>
          <oml:implementation>12</oml:implementation>
          <oml:value>0.600026</oml:value>          <oml:array_data>[0,0,0.711934,0.735714,0.601363,0.435678,0.430913]</oml:array_data>        </oml:evaluation>
              <oml:evaluation>
          <oml:name>kappa</oml:name>
          <oml:implementation>13</oml:implementation>
          <oml:value>0.491678</oml:value>                  </oml:evaluation>
              <oml:evaluation>
          <oml:name>kb_relative_information_score</oml:name>
          <oml:implementation>14</oml:implementation>
          <oml:value>1063.298606</oml:value>                  </oml:evaluation>
              <oml:evaluation>
          <oml:name>mean_absolute_error</oml:name>
          <oml:implementation>21</oml:implementation>
          <oml:value>0.127077</oml:value>                  </oml:evaluation>
              <oml:evaluation>
          <oml:name>mean_prior_absolute_error</oml:name>
          <oml:implementation>27</oml:implementation>
          <oml:value>0.220919</oml:value>                  </oml:evaluation>
              <oml:evaluation>
          <oml:name>number_of_instances</oml:name>
          <oml:implementation>34</oml:implementation>
          <oml:value>2050</oml:value>          <oml:array_data>[0,30,220,670,540,320,270]</oml:array_data>        </oml:evaluation>
              <oml:evaluation>
          <oml:name>os_information</oml:name>
          <oml:implementation>53</oml:implementation>
                    <oml:array_data>[ Oracle Corporation, 1.7.0_51, amd64, Linux, 3.7.10-1.28-desktop ]</oml:array_data>        </oml:evaluation>
              <oml:evaluation>
          <oml:name>precision</oml:name>
          <oml:implementation>35</oml:implementation>
          <oml:value>0.599589</oml:value>          <oml:array_data>[0,0,0.650376,0.705479,0.556782,0.48289,0.585987]</oml:array_data>        </oml:evaluation>
              <oml:evaluation>
          <oml:name>predictive_accuracy</oml:name>
          <oml:implementation>36</oml:implementation>
          <oml:value>0.614634</oml:value>                  </oml:evaluation>
              <oml:evaluation>
          <oml:name>prior_entropy</oml:name>
          <oml:implementation>38</oml:implementation>
          <oml:value>2.326811</oml:value>                  </oml:evaluation>
              <oml:evaluation>
          <oml:name>recall</oml:name>
          <oml:implementation>39</oml:implementation>
          <oml:value>0.614634</oml:value>          <oml:array_data>[0,0,0.786364,0.768657,0.653704,0.396875,0.340741]</oml:array_data>        </oml:evaluation>
              <oml:evaluation>
          <oml:name>relative_absolute_error</oml:name>
          <oml:implementation>40</oml:implementation>
          <oml:value>0.575218</oml:value>                  </oml:evaluation>
              <oml:evaluation>
          <oml:name>root_mean_prior_squared_error</oml:name>
          <oml:implementation>41</oml:implementation>
          <oml:value>0.331758</oml:value>                  </oml:evaluation>
              <oml:evaluation>
          <oml:name>root_mean_squared_error</oml:name>
          <oml:implementation>42</oml:implementation>
          <oml:value>0.280656</oml:value>                  </oml:evaluation>
              <oml:evaluation>
          <oml:name>root_relative_squared_error</oml:name>
          <oml:implementation>43</oml:implementation>
          <oml:value>0.845964</oml:value>                  </oml:evaluation>
              <oml:evaluation>
          <oml:name>scimark_benchmark</oml:name>
          <oml:implementation>55</oml:implementation>
          <oml:value>1973.4091512218106</oml:value>          <oml:array_data>[ 1262.1133708514062, 1630.9393838458018, 932.0675956790141, 1719.5408190761134, 4322.384586656718 ]</oml:array_data>        </oml:evaluation>
            </oml:output_data>
  </oml:run>

        */
    }
}
