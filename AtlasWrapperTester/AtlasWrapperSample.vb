Imports System
Imports AtlasWrapper.AtlasWrapper

Module AtlasWrapperSample
    Sub Main()

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

    End Sub
End Module
