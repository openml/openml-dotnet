# .NET API connector for the OpenMl platform

Connector to the OpenMl API for the .Net platform. Provides an easy and convinient way for accessing the OpenMl functionality.
It now covers all functionality of the rest API.

Easily installable via Nuget:
PM> Install-Package openMl

Now head to your account settings and obtain API key in the API authentication section.

You are all set!

First, connect to the service:
var connector = new OpenMlConnector("yourapikey");</br>

List all datasets:
var data = connector.ListDatasets();</br>

We are especially interested in dataset with Id 1:
var dataSetDetail = Connector.GetDatasetDescription(1);</br>

Let's download it:
```
dataSetDetail.DownloadDataset("saveItHere");
```

See http://www.openml.org/api_docs/#!/data/get_data_id for the list of methods supported by the API.

Upload new dataset:
var uploadResult = connector.UploadDataSet(@"newDataset.arff",
                new UploadDatasetDescription("Name", "Description"));

You can also make your own queries:
var result = connector.ExecuteFreeQuery("SELECT name,did FROM dataset");

Get Involved:
Contribution to the OpenML package is highly appreciated. 
Please send me an email beforehand so we can coordinate our efforts.


Send us Feedback:
Found a bug? Do you use OpenMl? Let us know! 
