# ALBATROSS-ATLAS API-Wrapper

![GitHub](https://img.shields.io/github/license/TobiHatti/Albatross-Atlas-API-Wrapper)
![GitHub Release Date](https://img.shields.io/github/release-date/TobiHatti/Albatross-Atlas-API-Wrapper)
![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/TobiHatti/Albatross-Atlas-API-Wrapper?include_prereleases)
![GitHub last commit](https://img.shields.io/github/last-commit/TobiHatti/Albatross-Atlas-API-Wrapper)
![GitHub issues](https://img.shields.io/github/issues-raw/TobiHatti/Albatross-Atlas-API-Wrapper)
![GitHub language count](https://img.shields.io/github/languages/count/TobiHatti/Albatross-Atlas-API-Wrapper)

A Simple wrapper-class for the Albatross-Atlas API. Compatible for C# and VB.Net

__NOTE: You might have to install the Newtonsoft.Json NuGet-Package__

### Usage (VB.Net)
```vbnet
' Create a connection to the Server
Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper("https://sample.serviceprovider.com/atlas", "sampleUser", "samplePassword")

' Sets the Fetch-Timespan for requests that utilize the pLastReceivedTS-Parameter
fetcher.FetchSpan = New TimeSpan(3, 0, 0)

' Get registered devices
Dim devices = fetcher.Devices()

' Get device-ignitions
Dim ignitionsA = fetcher.Ignitions(Date.Now.AddHours(-4), Date.Now) ' Does not utilize FetchSpan
Dim ignitionsB = fetcher.Ignitions(Date.Now.AddHours(-4))           ' Does utilize FetchSpan

' Get the current positions of all devices (standard and extended versions)
Dim positionsA = fetcher.Positions()
Dim positionsB = fetcher.PositionsExtended()

' Get the location-history of a device (standard and extended versions)
Dim historyA1 = fetcher.History(8618762024422020, Date.Now.AddHours(-4), Date.Now)  ' Does not utilize FetchSpan
Dim historyA2 = fetcher.History(8618762024422020, Date.Now.AddHours(-4))            ' Does utilize FetchSpan

Dim historyB1 = fetcher.HistoryExtended(8618762024422020, Date.Now.AddHours(-4), Date.Now)  ' Does not utilize FetchSpan
Dim historyB2 = fetcher.HistoryExtended(8618762024422020, Date.Now.AddHours(-4))            ' Does utilize FetchSpan

' Get the location-history of all devices (standard and extended versions)
Dim totHistoryA = fetcher.TotalHistory(Date.Now.AddHours(-4))
Dim totHistoryB = fetcher.TotalHistoryExtended(Date.Now.AddHours(-4))

' Get list of all registered drivers
Dim drivers = fetcher.Drivers()

' Get the list of refuelings
Dim refuelingsA = fetcher.Refueling(Date.Now.AddHours(-4), Date.Now)    ' Does not utilize FetchSpan
Dim refuelingsB = fetcher.Refueling(Date.Now.AddHours(-4))              ' Does utilize FetchSpan

' Custom API-Request
Dim customA = fetcher.CustomRequest("https://sample.serviceprovider.com/atlas/sampleUser/tasks")
Dim customB = AtlasWrapper.AtlasWrapper.CustomRequest("https://sample.serviceprovider.com/atlas/sampleUser/tasks", "samplePassword")
```

### Usage (C#)
```cs
// Create a connection to the Server
AtlasWrapper.AtlasWrapper fetcher = new AtlasWrapper.AtlasWrapper("https://sample.serviceprovider.com/atlas", "sampleUser", "samplePassword");

// Sets the Fetch-Timespan for requests that utilize the pLastReceivedTS-Parameter
fetcher.FetchSpan = new TimeSpan(3, 0, 0);

// Get registered devices
dynamic devices = fetcher.Devices();

// Get device-ignitions
dynamic ignitionsA = fetcher.Ignitions(DateTime.Now.AddHours(-4), DateTime.Now);// Does not utilize FetchSpan
dynamic ignitionsB = fetcher.Ignitions(DateTime.Now.AddHours(-4));              // Does utilize FetchSpan

// Get the current positions of all devices (standard and extended versions)
dynamic positionsA = fetcher.Positions();
dynamic positionsB = fetcher.PositionsExtended();

// Get the location-history of a device (standard and extended versions)
dynamic historyA1 = fetcher.History(8618762024422020, DateTime.Now.AddHours(-4), DateTime.Now); // Does not utilize FetchSpan
dynamic historyA2 = fetcher.History(8618762024422020, DateTime.Now.AddHours(-4));               // Does utilize FetchSpan

dynamic historyB1 = fetcher.HistoryExtended(8618762024422020, DateTime.Now.AddHours(-4), DateTime.Now); // Does not utilize FetchSpan
dynamic historyB2 = fetcher.HistoryExtended(8618762024422020, DateTime.Now.AddHours(-4));               // Does utilize FetchSpan

// Get the location-history of all devices (standard and extended versions)
dynamic totHistoryA = fetcher.TotalHistory(DateTime.Now.AddHours(-4));
dynamic totHistoryB = fetcher.TotalHistoryExtended(DateTime.Now.AddHours(-4));

// Get list of all registered drivers
dynamic drivers = fetcher.Drivers();

// Get the list of refuelings
dynamic refuelingsA = fetcher.Refueling(DateTime.Now.AddHours(-4), DateTime.Now);   // Does not utilize FetchSpan
dynamic refuelingsB = fetcher.Refueling(DateTime.Now.AddHours(-4));                 // Does utilize FetchSpan

// Custom API-Request
dynamic customA = fetcher.CustomRequest("https://sample.serviceprovider.com/atlas/sampleUser/tasks");
dynamic customB = AtlasWrapper.AtlasWrapper.CustomRequest("https://sample.serviceprovider.com/atlas/sampleUser/tasks", "samplePassword");
```
