# .NET API connector for the OpenMl platform

Connector to the openML api for the .Net platform.
Currently the entries in the OpenMl database can be obtained, the upload of own results is planned.
Feedback, issue reporting and feature request are much appreciated.

Easily installable via Nuget:
PM> Install-Package openMl

Usage is as follows:
var connector = new OpenMlConnector("username", "password");</br>
var data = connector.ListDatasets();</br>
var dataSetDetail = connector.GetDatasetDescription(1);</br>
var run = connector.GetRun(1);</br>
var licences = connector.ListDataLicences();</br>
var measures = connector.ListEvaluationMeasures();</br>
var estimationProcs = connector.GetEstimationProcedure(1);</br>
var licences2 = connector.ListImplementationLicences();</br>
var dataQualities = connector.ListDataQualities();</br>
var taskTypes = connector.ListTaskTypes();</br>
var taskType = connector.GetTaskType(1);</br>
var datasetDescription = connector.GetDatasetDescription(1);</br>
