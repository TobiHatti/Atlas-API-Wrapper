Imports System
Imports System.Text
Imports AtlasWrapper
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class AtlasWrapperUTest

    Private ReadOnly GPSHost As String = "https://sample.serviceprovider.com/atlas"
    Private ReadOnly GPSUser As String = "sampleUsername"
    Private ReadOnly GPSPass As String = "samplePassword"
#Region "[TEST-METHOD : Devices]"
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
#End Region
#Region "[TEST-METHOD : Ignitions]"
    <TestMethod()> Public Sub Ignitions_OVRLD1_DefaultUseCase_DateRange0H_ExpectNull()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.Ignitions(Date.Now, Date.Now)
        Assert.IsNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub Ignitions_OVRLD1_DefaultUseCase_DateRange3H_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.Ignitions(Date.Now.AddHours(-3), Date.Now)
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub Ignitions_OVRLD1_DefaultUseCase_DateRange24H_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.Ignitions(Date.Now.AddHours(-24), Date.Now)
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub Ignitions_OVRLD2_DefaultUseCase_AllPast_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.Ignitions(Date.Now.AddHours(-5))
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub Ignitions_OVRLD2_DefaultUseCase_AllFuture_ExpectNull()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.Ignitions(Date.Now.AddHours(5))
        Assert.IsNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub Ignitions_OVRLD2_DefaultUseCase_PastAndFuture_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.Ignitions(DateTime.Now.AddHours(-1))
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
#End Region
End Class