Imports System
Imports System.Text
Imports AtlasWrapper
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class AtlasWrapperUTest

    Private ReadOnly GPSHost As String = "https://sample.serviceprovider.com/atlas"
    Private ReadOnly GPSUser As String = "sampleUsername"
    Private ReadOnly GPSPass As String = "samplePassword"

    <TestMethod()> Public Sub Devices_OVRLD1_DefaultUseCase_NoParams_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.Devices()
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub Devices_OVRLD1_DefaultUseCase_Params1_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.Devices(0)
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub Devices_OVRLD1_DefaultUseCase_Params2_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.Devices(1)
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
End Class