# nibTechChallenge

This application sends a POST to endpoint `/api/v1/warehouse/fulfilment` with order ID data. For each order ID sent, items in the order are compared against products available on hand. If there are not enough products on hand, the order will be unfulfillable. The endpoint may be accessed via a API tester such as Postman or Talend API tester chrome plugin, or tested below.

## Notes:

* NancyFx is used for API purposes.
* Newtonsoft.Json (JSON.NET) is used for JSON parsing purposes.
* To access the endpoint, ensure the console application is running.
* Allow the Network Command Shell to run to enable self hosting
