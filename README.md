<img align="right" width="80" height="80" data-rmimg src="https://endev.at/content/projects/Atlas-API-Wrapper/EndevLibs_Logo_128.png">

# ATLAS API-Wrapper

[![GitHub](https://img.shields.io/github/license/TobiHatti/Albatross-Atlas-API-Wrapper)](https://opensource.org/licenses/MIT)
[![GitHub Release Date](https://img.shields.io/github/release-date/TobiHatti/Albatross-Atlas-API-Wrapper)](https://github.com/TobiHatti/Albatross-Atlas-API-Wrapper/releases)
[![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/TobiHatti/Albatross-Atlas-API-Wrapper?include_prereleases)](https://github.com/TobiHatti/Albatross-Atlas-API-Wrapper/releases)
[![GitHub last commit](https://img.shields.io/github/last-commit/TobiHatti/Albatross-Atlas-API-Wrapper)](https://github.com/TobiHatti/Albatross-Atlas-API-Wrapper/commits/master)
[![GitHub issues](https://img.shields.io/github/issues-raw/TobiHatti/Albatross-Atlas-API-Wrapper)](https://github.com/TobiHatti/Albatross-Atlas-API-Wrapper/issues)
[![GitHub language count](https://img.shields.io/github/languages/count/TobiHatti/Albatross-Atlas-API-Wrapper)](https://github.com/TobiHatti/Albatross-Atlas-API-Wrapper)

![image](https://endev.at/content/projects/Atlas-API-Wrapper/AtlasAPIWrapper_Banner_1080.png)

A Simple wrapper-class for the Atlas-API. Compatible for C# and VB.Net

__NOTE: You might have to install the Newtonsoft.Json NuGet-Package__

### Usage (VB.Net)
```vbnet
' Create a connection to the Server
Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper("https://sample.serviceprovider.com/atlas", "samplePassword")

' Get Response
' Gets the response from https://sample.serviceprovider.com/atlas/myCall/myCustomParameters
Dim reply = fetcher.GetResponse("myCall/myCustomParameters")

' Custom API-Request
Dim customA = fetcher.CustomRequest("https://sample.serviceprovider.com/atlas/sampleUser/tasks")
Dim customB = AtlasWrapper.AtlasWrapper.CustomRequest("https://sample.serviceprovider.com/atlas/sampleUser/tasks", "samplePassword")
```

### Usage (C#)
```cs
// Create a connection to the Server
AtlasWrapper.AtlasWrapper fetcher = new AtlasWrapper.AtlasWrapper("https://sample.serviceprovider.com/atlas", "samplePassword");

// Get Response
// Gets the response from https://sample.serviceprovider.com/atlas/myCall/myCustomParameters
dynamic reply = fetcher.GetResponse("myCall/myCustomParameters");

// Custom API-Request
dynamic customA = fetcher.CustomRequest("https://sample.serviceprovider.com/atlas/sampleUser/tasks");
dynamic customB = AtlasWrapper.AtlasWrapper.CustomRequest("https://sample.serviceprovider.com/atlas/sampleUser/tasks", "samplePassword");
```
