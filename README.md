# .NET API connector for the OpenMl platform

Connector to the OpenMl API for the .Net platform. Provides an easy and convinient way for accessing the OpenMl functionality. </br>
It now covers all functionality of the rest API.

Easily installable via Nuget (via Nuget console or Visual Studio Nuget interface):
```
PM> Install-Package openMl
```
Now head to your account settings and obtain API key in the API authentication section.

You are all set!

First, connect to the service:
```
var connector = new OpenMlConnector("yourapikey");
```
List all datasets:
```
var data = connector.ListDatasets();
```
We are especially interested in dataset with Id 1:
```
var dataSetDetail = Connector.GetDatasetDescription(1);
```
Let's download it:
```
dataSetDetail.DownloadDataset("saveItHere");
```
Upload new dataset:
```
var uploadResult = connector.UploadDataSet(@"newDataset.arff",
                new UploadDatasetDescription("Name", "Description"));
```
You can also make your own queries:
```
var result = connector.ExecuteFreeQuery("SELECT name,did FROM dataset");
```
See http://www.openml.org/api_docs/#!/data/get_data_id for the list of methods supported by the API.

Get Involved:
Contribution to the OpenML package is highly appreciated. 
Please send me an email beforehand so we can coordinate our efforts.


Send us Feedback:
Found a bug? Do you use OpenMl? Let us know! 
