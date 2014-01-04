NGeoIP
======

.NET client to freegeoip.net for searching geolocation of an IP addresses and host names

###Open Source Libraries

* RestSharp
* AutoMapper

###Usage

#### How to make a request to service

```C#
var nGeoRequest = new Request()
{
    Format = Format.Json,
    IP = "[CLIENT IP]"
};

var nGeoClient = new NGeoClient(nGeoRequest);

var rawData = nGeoClient.Execute();
```

#### How to transform a RawData object to a normalized Response object

```C#
var response = nGeoClient.MapResponse(rawData);
```

###Limits

API usage is limited to 10,000 queries per hour. After reaching this limit, all requests will result in HTTP 403 (Forbidden) until the roll over.
