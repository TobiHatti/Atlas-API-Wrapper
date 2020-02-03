Imports System
Imports System.Text
Imports AtlasWrapper
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class AtlasWrapperUTest

    Private ReadOnly GPSHost As String = "https://sample.serviceprovider.com/atlas"
    Private ReadOnly GPSUser As String = "sampleUsername"
    Private ReadOnly GPSPass As String = "samplePassword"

    Private ReadOnly ValidIMEI As Long = 211101987654321
    Private ReadOnly InvalidIMEI As Long = 123456789101112

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
#Region "[TEST-METHOD : Positions]"
    <TestMethod()> Public Sub Positions_OVRLD1_DefaultUseCase_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.Positions()
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub PositionsExtended_OVRLD1_DefaultUseCase_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.PositionsExtended()
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
#End Region
#Region "[TEST-METHOD : History]"
    <TestMethod()> Public Sub History_OVRLD1_DefaultUseCase_DateRange0H_ValidIMEI_ExpectNull()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.History(ValidIMEI, DateTime.Now, DateTime.Now)
        Assert.IsNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub History_OVRLD1_DefaultUseCase_DateRange3H_ValidIMEI_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.History(ValidIMEI, DateTime.Now.AddHours(-3), DateTime.Now)
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub History_OVRLD1_DefaultUseCase_DateRange24H_ValidIMEI_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.History(ValidIMEI, DateTime.Now.AddHours(-24), DateTime.Now)
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub History_OVRLD2_DefaultUseCase_AllPast_ValidIMEI_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.History(ValidIMEI, DateTime.Now.AddHours(-5))
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub History_OVRLD2_DefaultUseCase_AllFuture_ValidIMEI_ExpectNull()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.History(ValidIMEI, DateTime.Now.AddHours(5))
        Assert.IsNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub History_OVRLD2_DefaultUseCase_PastAndFuture_ValidIMEI_ExpectResult()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        fetcher.FetchSpan = New TimeSpan(10, 0, 0)
        Dim result = fetcher.History(ValidIMEI, DateTime.Now.AddHours(-5))
        Assert.IsNotNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub History_OVRLD1_DefaultUseCase_DateRange0H_InvalidIMEI_ExpectNull()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.History(InvalidIMEI, DateTime.Now, DateTime.Now)
        Assert.IsNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub History_OVRLD1_DefaultUseCase_DateRange3H_InvalidIMEI_ExpectNull()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.History(InvalidIMEI, DateTime.Now.AddHours(-3), DateTime.Now)
        Assert.IsNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub History_OVRLD1_DefaultUseCase_DateRange24H_InvalidIMEI_ExpectNull()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.History(InvalidIMEI, DateTime.Now.AddHours(-24), DateTime.Now)
        Assert.IsNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub History_OVRLD2_DefaultUseCase_AllPast_InvalidIMEI_ExpectNull()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.History(InvalidIMEI, DateTime.Now.AddHours(-5))
        Assert.IsNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub History_OVRLD2_DefaultUseCase_AllFuture_InvalidIMEI_ExpectNull()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        Dim result = fetcher.History(InvalidIMEI, DateTime.Now.AddHours(5))
        Assert.IsNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
    <TestMethod()> Public Sub History_OVRLD2_DefaultUseCase_PastAndFuture_InvalidIMEI_ExpectNull()
        Dim fetcher As AtlasWrapper.AtlasWrapper = New AtlasWrapper.AtlasWrapper(GPSHost, GPSUser, GPSPass)
        fetcher.FetchSpan = New TimeSpan(10, 0, 0)
        Dim result = fetcher.History(InvalidIMEI, DateTime.Now.AddHours(-5))
        Assert.IsNull(result)
        Assert.AreNotEqual(result, -1)
        If Not result Is Nothing Then Assert.IsFalse(result.ToString().ToLower().StartsWith("e-"))
    End Sub
#End Region
End Class