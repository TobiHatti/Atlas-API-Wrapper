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

    Public Function Devices(Optional pRegistrationAsName As Integer = 0) As Object
        Return GetApiResponse($"{hostname}/{username}/devices?registrationAsName={pRegistrationAsName}")
    End Function
End Class
