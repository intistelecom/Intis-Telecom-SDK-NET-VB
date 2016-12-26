' MIT License

' Copyright (c) 2016 Intis Telecom

' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:

' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.

' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.

Imports System.Security.Cryptography
Imports System.Text
Imports System.Collections.Specialized
Imports System.Web.Script.Serialization
Imports System.IO
Imports Intis.SDK.Exceptions

Namespace Intis.SDK

    Public MustInherit Class AClient

        Protected Login As String

        Protected ApiKey As String

        Protected ApiHost As String

        Private ApiConnector As IApiConnector

        Protected Sub New(ByVal apiConnector As IApiConnector)
            MyClass.ApiConnector = If(apiConnector, New HttpApiConnector())
        End Sub

        Protected Function GetStreamContent(ByVal scriptName As String, ByVal parameters As NameValueCollection) As MemoryStream
            Dim result = GetContent(scriptName, parameters)
            Dim byteArray = Encoding.UTF8.GetBytes(result)
            Dim stream = New MemoryStream(byteArray)
            Return stream
        End Function

        Protected Function GetContent(ByVal scriptName As String, ByVal parameters As NameValueCollection) As String
            Dim allParameters = GetParameters(parameters)
            Dim url = ApiHost & scriptName & ".php"
            Dim result = ApiConnector.GetContentFromApi(url, allParameters)
            checkException(result)
            Return result
        End Function

        Private Function GetTimestamp() As String
            Dim unixTimestamp = CInt((System.DateTime.UtcNow.Subtract(New System.DateTime(1970, 1, 1))).TotalSeconds)
            Dim timestamp = unixTimestamp.ToString()
            Return timestamp
        End Function

        Private Function GetBaseParameters() As NameValueCollection
            Dim parameters = New NameValueCollection From {{"login", Login}, {"timestamp", GetTimestamp()}, {"return", "json"}}
            Return parameters
        End Function

        Private Function GetParameters(ByVal more As NameValueCollection) As NameValueCollection
            Dim parameters = GetBaseParameters()
            If more.Count > 0 Then
                For Each key In more.AllKeys
                    parameters.Add(key, more(key))
                Next
            End If

            Dim sig = GetSignature(parameters)
            parameters.Add("signature", sig)
            Return parameters
        End Function

        Private Function GetSignature(ByVal parameters As NameValueCollection) As String
            Dim str = parameters.AllKeys.OrderBy(Function(k) k).Aggregate(String.Empty, Function(current, item) current & parameters(item))
            str = str & ApiKey
            Return GetMd5Hash(str)
        End Function

        Private Shared Function GetMd5Hash(ByVal str As String) As String
            Dim md5Hasher = MD5.Create()
            Dim data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(str))
            Dim sBuilder = New StringBuilder()
            For Each t In data
                sBuilder.Append(t.ToString("x2"))
            Next

            Return sBuilder.ToString()
        End Function

        Private Sub checkException(ByVal result As String)
            If Not result.Any() Then
                Throw New SdkException(0)
            End If

            If result.Substring(0, 8) <> "{""error""" Then Return
            Dim serializer = New JavaScriptSerializer()
            Dim list = serializer.Deserialize(Of Dictionary(Of String, Integer))(result)
            Throw New SdkException(list.First().Value)
        End Sub
    End Class
End Namespace
