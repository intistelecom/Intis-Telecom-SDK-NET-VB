Imports System.Collections.Specialized
Imports System.Net
Imports System.Text
Imports System.Web

Namespace Intis.SDK

    Public Class HttpApiConnector
        Implements IApiConnector

        Public Function GetContentFromApi(ByVal url As String, ByVal allParameters As NameValueCollection) As String Implements IApiConnector.GetContentFromApi
            Dim encodeParameters = New NameValueCollection()
            For i = 0 To allParameters.Count - 1
                Dim param = HttpUtility.UrlEncode(allParameters.[Get](i))
                If param IsNot Nothing Then encodeParameters.Add(allParameters.GetKey(i), param)
            Next

            Dim client = New WebClient With {.QueryString = encodeParameters, .Encoding = Encoding.UTF8}
            Dim result = client.DownloadString(url)
            Return result
        End Function

        Public Function GetTimestampFromApi(ByVal url As String) As String Implements IApiConnector.GetTimestampFromApi
            Dim client = New WebClient With {.Encoding = Encoding.UTF8}
            Dim result = client.DownloadString(url)
            Return result
        End Function
    End Class
End Namespace
