using AtlasWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasWrapperSampleCS
{
    class AtlasWrapperSampleCS
    {
        static void Main()
        {
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
        }
    }
}
