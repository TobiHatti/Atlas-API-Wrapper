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

End Class
