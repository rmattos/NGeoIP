NGeoIP
======

.NET client to [freegeoip.net] (http://freegeoip.net/) for searching geolocation of IP addresses and host names

###How to install via NugGet

To install NGeopIP, run the following command in the Package Manager Console

PM> Install-Package NGeoIP

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

###OSS Libraries used

* [RestSharp](https://github.com/restsharp/RestSharp)
* [AutoMapper] (https://github.com/AutoMapper/AutoMapper/)

###Limits

API usage is limited to 10,000 queries per hour. After reaching this limit, all requests will result in HTTP 403 (Forbidden) until the roll over.
