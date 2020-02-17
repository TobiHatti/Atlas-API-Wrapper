Option Strict On

Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class AtlasWrapper
    Private ReadOnly hostname As String
    Private ReadOnly password As String

    Public Property PasswordPostKey As String = "password"

    ''' <summary>
    ''' Creates a new instance for fetching vehicle-data from the ATLAS-GPS-API
    ''' </summary>
    ''' <param name="pHostname">Hostname to the root of the API (Server and Port (Optional)): https://www.example.com:5454/api </param>
    ''' <param name="pPassword">API Password (If required)</param>
    Public Sub New(pHostname As String, Optional pPassword As String = Nothing)
        Me.hostname = pHostname
        Me.password = pPassword
    End Sub

#Region "[PRIVATE METHODS]"
    Private Function GetApiResponse(pApiUrl As String) As Object
        Try
            Using webClient As WebClient = New WebClient()
                If password IsNot Nothing Then
                    Return JsonConvert.DeserializeObject(
                    Encoding.UTF8.GetString(
                    webClient.UploadValues(hostname,
                    New Specialized.NameValueCollection From {{PasswordPostKey, password}})))
                Else
                    Return JsonConvert.DeserializeObject(
                    Encoding.UTF8.GetString(
                    webClient.UploadValues(hostname,
                    New Specialized.NameValueCollection())))
                End If
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

#Region "[PUBLIC METHODS / API CALLS]"
    Public Function GetResponse(pRequestCall As String) As Object
        Return GetApiResponse($"{hostname}/{pRequestCall}")
    End Function
#End Region

#Region "[PUBLIC METHODS / CUSTOM API CALLS]"
    ''' <summary>
    ''' Retrieves data from a custom request
    ''' </summary>
    ''' <param name="pHostnameAndRequest">Hostname and Request for the API, also includes the username</param>
    ''' <returns>Dynamic object of the requested data</returns>
    Public Function CustomRequest(pHostnameAndRequest As String) As Object
        Return GetApiResponse(pHostnameAndRequest)
    End Function
    ''' <summary>
    ''' Retrieves data from a custom request
    ''' </summary>
    ''' <param name="pHostnameAndRequest">Hostname and Request for the API, also includes the username</param>
    ''' <param name="pPassword">API Password</param>
    ''' <returns>Dynamic object of the requested data</returns>
    Public Shared Function CustomRequest(pHostnameAndRequest As String, Optional pPassword As String = Nothing, Optional pPasswordPostKey As String = "password") As Object
        Try
            Using webClient As WebClient = New WebClient()
                If pPassword IsNot Nothing Then
                    Return JsonConvert.DeserializeObject(
                    Encoding.UTF8.GetString(
                    webClient.UploadValues(pHostnameAndRequest,
                    New Specialized.NameValueCollection From {{pPasswordPostKey, pPassword}})))
                Else
                    Return JsonConvert.DeserializeObject(
                    Encoding.UTF8.GetString(
                    webClient.UploadValues(pHostnameAndRequest,
                    New Specialized.NameValueCollection())))
                End If
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
