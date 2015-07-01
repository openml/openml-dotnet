# dotnet
.NET API

Connector to the openML api for the .Net platform.
Currently the entries in the OpenMl database can be obtained, the upload of own results is planned.
Feedback, issue reporting and feature request are much appreciated.

Easily installable via Nuget:
PM> Install-Package openMl

Usage is as follows:
var connector = new OpenMlConnector("username", "password");
var data = connector.ListDatasets();
var dataSetDetail = connector.GetDatasetDescription(1);
var run = connector.GetRun(1);
var licences = connector.ListDataLicences();
var measures = connector.ListEvaluationMeasures();
var estimationProcs = connector.GetEstimationProcedure(1);
var licences2 = connector.ListImplementationLicences();
var dataQualities = connector.ListDataQualities();
var taskTypes = connector.ListTaskTypes();
var taskType = connector.GetTaskType(1);
var datasetDescription = connector.GetDatasetDescription(1);
