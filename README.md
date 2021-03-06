# nibTechChallenge

This application sends a POST to endpoint `/api/v1/warehouse/fulfilment` with order ID data. For each order ID sent, items in the order are compared against products available on hand. If there are not enough products on hand, the order will be unfulfillable. The endpoint may be accessed via a API tester such as Postman or Talend API tester chrome plugin, or tested below.

## Notes:

* C# 
* .NET Framework 4.5.2
* NancyFx is used for API purposes.
* Newtonsoft.Json (JSON.NET) is used for JSON parsing purposes.
* To access the endpoint, ensure the console application is running.
* Allow the Network Command Shell to run to enable self hosting
* Test project added with small sample unit tests

## Run app

To run the application, download files in the bin/debug folder onto a windows machine and run the executable file `nib.techChallenge.BillThomas.exe`
