Option Strict On

Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class AtlasWrapper
    Private ReadOnly hostname As String
    Private ReadOnly username As String
    Private ReadOnly password As String

    ''' <summary>
    ''' Sets the Timespan over which period the data should be retrieved
    ''' based of the last saved timestamp.
    ''' </summary>
    Public Property FetchSpan As TimeSpan


    ''' <summary>
    ''' Creates a new instance for fetching vehicle-data from the ATLAS-GPS-API
    ''' </summary>
    ''' <param name="pHostname">Hostname to the root of the API (Server and Port (Optional)): https://www.example.com:5454</param>
    ''' <param name="pUsername">API Username</param>
    ''' <param name="pPassword">API Password</param>
    Public Sub New(pHostname As String, pUsername As String, pPassword As String)
        Me.hostname = pHostname
        Me.username = pUsername
        Me.password = pPassword
    End Sub

#Region "[PRIVATE METHODS]"
    Private Function GetApiResponse(pApiUrl As String) As Object
        Try
            Using webClient As WebClient = New WebClient()
                Return JsonConvert.DeserializeObject(
                    Encoding.UTF8.GetString(
                    webClient.UploadValues(pApiUrl,
                    New Specialized.NameValueCollection From {{"password", password}})))
            End Using
        Catch wex As WebException
            Dim errorCode As HttpStatusCode = CType(wex.Response, HttpWebResponse).StatusCode
            If errorCode = HttpStatusCode.OK OrElse errorCode = HttpStatusCode.NotFound Then
                Return Nothing
            Else
                Return "e-" + CType(errorCode, Integer).ToString()
            End If
        Catch ex As Exception
            Return -1
        End Try
    End Function
    Private Function DatesValid(pFromTS As Date, pToTS As Date) As Boolean
        If New Date(pFromTS.Year, pFromTS.Month, pFromTS.Day, pFromTS.Hour, pFromTS.Minute, pFromTS.Second) = New Date(pToTS.Year, pToTS.Month, pToTS.Day, pToTS.Hour, pToTS.Minute, pToTS.Second) OrElse pFromTS > Date.Now OrElse pFromTS > pToTS Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region

#Region "[PUBLIC METHODS / API CALLS]"
    Public Function Devices(Optional pRegistrationAsName As Integer = 0) As Object
        Return GetApiResponse($"{hostname}/{username}/devices?registrationAsName={pRegistrationAsName}")
    End Function
    Public Function Ignitions(pFromTS As Date, pToTS As Date) As Object
        If Not DatesValid(pFromTS, pToTS) Then Return Nothing
        Return GetApiResponse($"{hostname}/{username}/ignitions/{pFromTS.ToString("yyyy-MM-dd HH:mm:ss")}/{pToTS.ToString("yyyy-MM-dd HH:mm:ss")}/")
    End Function
    Public Function Ignitions(pLastReceivedTS As Date) As Object
        Return Ignitions(pLastReceivedTS, pLastReceivedTS.Add(FetchSpan))
    End Function
    Public Function Positions() As Object
        Return GetApiResponse($"{hostname}/{username}/positions")
    End Function
    Public Function PositionsExtended() As Object
        Return GetApiResponse($"{hostname}/{username}/positionsextended")
    End Function
    Public Function History(pIMEI As Long, pFromTS As Date, pToTS As Date) As Object
        If Not DatesValid(pFromTS, pToTS) Then Return Nothing
        Return GetApiResponse($"{hostname}/{username}/history/{pIMEI}/{CType(pFromTS.Subtract(New DateTime(1970, 1, 1)).TotalSeconds, Integer)}/{CType(pToTS.Subtract(New DateTime(1970, 1, 1)).TotalSeconds, Integer)}")
    End Function
    Public Function History(pIMEI As Long, pLastReceivedTS As Date) As Object
        Return History(pIMEI, pLastReceivedTS, pLastReceivedTS.Add(FetchSpan))
    End Function
    Public Function HistoryExtended(pIMEI As Long, pFromTS As Date, pToTS As Date) As Object
        If Not DatesValid(pFromTS, pToTS) Then Return Nothing
        Return GetApiResponse($"{hostname}/{username}/historyextended/{pIMEI}/{CType(pFromTS.Subtract(New DateTime(1970, 1, 1)).TotalSeconds, Integer)}/{CType(pToTS.Subtract(New DateTime(1970, 1, 1)).TotalSeconds, Integer)}")
    End Function
    Public Function HistoryExtended(pIMEI As Long, pLastReceivedTS As Date) As Object
        Return HistoryExtended(pIMEI, pLastReceivedTS, pLastReceivedTS.Add(FetchSpan))
    End Function
    Public Function TotalHistory(pFromTS As Long, Optional pLimit As Integer = 100) As Object
        Return GetApiResponse($"{hostname}/{username}/totalhistory/{pFromTS}/?limit={pLimit}")
    End Function
    Public Function TotalHistoryExtended(pFromTS As Long, Optional pLimit As Integer = 100) As Object
        Return GetApiResponse($"{hostname}/{username}/totalhistoryextended/{pFromTS}/?limit={pLimit}")
    End Function
    Public Function Drivers() As Object
        Return GetApiResponse($"{hostname}/{username}/drivers")
    End Function
    Public Function Refueling(pFromTS As Date, pToTS As Date) As Object
        Return GetApiResponse($"{hostname}/{username}/refueling/{pFromTS.ToString("yyyy-MM-dd HH:mm:ss")}/{pToTS.ToString("yyyy-MM-dd HH:mm:ss")}")
    End Function
    Public Function Refueling(pLastReceivedTS As Date) As Object
        Return Refueling(pLastReceivedTS, pLastReceivedTS.Add(FetchSpan))
    End Function
#End Region

#Region "[PUBLIC METHODS / CUSTOM API CALLS]"
    Public Function CustomRequest(pHostnameAndRequest As String) As Object
        Return GetApiResponse(pHostnameAndRequest)
    End Function
    Public Shared Function CustomRequest(pHostnameAndRequest As String, pPassword As String) As Object
        Try
            Using webClient As WebClient = New WebClient()
                Return JsonConvert.DeserializeObject(
                    Encoding.UTF8.GetString(
                    webClient.UploadValues(pHostnameAndRequest,
                    New Specialized.NameValueCollection From {{"password", pPassword}})))
            End Using
        Catch wex As WebException
            Dim errorCode As HttpStatusCode = CType(wex.Response, HttpWebResponse).StatusCode
            If errorCode = HttpStatusCode.OK OrElse errorCode = HttpStatusCode.NotFound Then
                Return Nothing
            Else
                Return "e-" + CType(errorCode, Integer).ToString()
            End If
        Catch ex As Exception
            Return -1
        End Try
    End Function
#End Region
End Class
