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

#### RawData object

```C#
public class RawData
{
    public string Ip { get; set; }

    public string CountryCode { get; set; }

    public string CountryName { get; set; }

    public string RegionCode { get; set; }

    public string RegionName { get; set; }

    public string City { get; set; }

    public string ZipCode { get; set; }

    public string Latitude { get; set; }

    public string Longitude { get; set; }

    public string MetroCode { get; set; }

    public string AreaCode { get; set; }
}
```

#### How to transform a RawData object to a normalized Response object

```C#
var response = nGeoClient.MapResponse(rawData);
```

#### Response object

```C#
public class Response
{
    public string IP { get; set; }

    public Domain.Address Address { get; set; }
}

public class Address
{
    public Country Country { get; set; }

    public Region Region { get; set; }

    public City City { get; set; }

    public string Zipcode { get; set; }

    public string Latitude { get; set; }

    public string Longitude { get; set; }

    public string MetroCode { get; set; }

    public string AreaCode { get; set; }
}

public class Country
{
    public string Code { get; set; }

    public string Name { get; set; }
}

public class Region
{
    public string Code { get; set; }

    public string Name { get; set; }
}

public class City
{
    public string Name { get; set; }
}
```

###OSS Libraries used

* [RestSharp](https://github.com/restsharp/RestSharp)
* [AutoMapper] (https://github.com/AutoMapper/AutoMapper/)

###Limits

Freegeoip.net API usage is limited to 10,000 queries per hour. After reaching this limit, all requests will result in HTTP 403 (Forbidden) until the roll over.

If the usage limit is a problem, please consider running your own instance of this system. It's open source and freely available at GitHub.

Download the [source code] (https://github.com/fiorix/freegeoip)
