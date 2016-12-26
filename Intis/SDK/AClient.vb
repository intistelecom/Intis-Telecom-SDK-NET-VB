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

    ''' <summary>
    ''' Class AClient
    ''' The main class for working with API
    ''' </summary>
    Public MustInherit Class AClient

        Protected Login As String

        Protected ApiKey As String

        Protected ApiHost As String

        Private ApiConnector As IApiConnector

        Protected Sub New(apiConnector As IApiConnector)
            MyClass.ApiConnector = If(apiConnector, New HttpApiConnector())
        End Sub

        ''' <summary>
        ''' Getting content using parameters and name of API script
        ''' </summary>
        ''' <param name="scriptName">Name of API script</param>
        ''' <param name="parameters">parameters</param>
        ''' <returns></returns>
        Protected Function GetStreamContent(scriptName As String, parameters As NameValueCollection) As MemoryStream
            Dim result = GetContent(scriptName, parameters)
            Dim byteArray = Encoding.UTF8.GetBytes(result)
            Dim stream = New MemoryStream(byteArray)
            Return stream
        End Function

        ''' <summary>
        ''' Getting content using parameters and name of API script
        ''' </summary>
        ''' <param name="scriptName">Name of API script</param>
        ''' <param name="parameters">parameters</param>
        ''' <returns>returns the data as an string</returns>
        Protected Function GetContent(scriptName As String, parameters As NameValueCollection) As String
            Dim allParameters = GetParameters(parameters)
            Dim url = ApiHost & scriptName & ".php"
            Dim result = ApiConnector.GetContentFromApi(url, allParameters)
            checkException(result)
            Return result
        End Function

        ''' <summary>
        ''' Getting time in UNIX format according api
        ''' </summary>
        ''' <returns>timestamp as an string</returns>
        Private Function GetTimestamp() As String
            Dim unixTimestamp = CInt((System.DateTime.UtcNow.Subtract(New System.DateTime(1970, 1, 1))).TotalSeconds)
            Dim timestamp = unixTimestamp.ToString()
            Return timestamp
        End Function

        Private Function GetBaseParameters() As NameValueCollection
            Dim parameters = New NameValueCollection From {{"login", Login}, {"timestamp", GetTimestamp()}, {"return", "json"}}
            Return parameters
        End Function

        ''' <summary>
        ''' Getting additional parameters for API.
        ''' It creates an array with additional parameters and complements an array with a signature key.
        ''' </summary>
        ''' <param name="more">additional parameters</param>
        ''' <returns>base + additional</returns>
        Private Function GetParameters(more As NameValueCollection) As NameValueCollection
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

        ''' <summary>
        ''' Creating signatures by incoming parameters
        ''' </summary>
        ''' <param name="parameters">all parameters</param>
        ''' <returns>signature</returns>
        Private Function GetSignature(parameters As NameValueCollection) As String
            Dim str = parameters.AllKeys.OrderBy(Function(k) k).Aggregate(String.Empty, Function(current, item) current & parameters(item))
            str = str & ApiKey
            Return GetMd5Hash(str)
        End Function

        ''' <summary>
        ''' Generating Hash from String
        ''' </summary>
        ''' <param name="str">line of parameters</param>
        ''' <returns>hash</returns>
        Private Shared Function GetMd5Hash(str As String) As String
            Dim md5Hasher = MD5.Create()
            Dim data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(str))
            Dim sBuilder = New StringBuilder()
            For Each t In data
                sBuilder.Append(t.ToString("x2"))
            Next

            Return sBuilder.ToString()
        End Function

        ''' <summary>
        ''' Testing for special exceptions and error output
        ''' </summary>
        ''' <param name="result">data as an string</param>
        Private Sub checkException(result As String)
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
