Imports System
Imports AtlasWrapper

Module AtlasWrapperSample
    Sub Main()

        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper("", "", "")

        Dim result = fetcher.Devices()

    End Sub
End Module
