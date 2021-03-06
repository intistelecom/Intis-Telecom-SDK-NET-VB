﻿' MIT License

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

Imports System.Collections.Specialized
Imports System.Net
Imports System.Text
Imports System.Web

Namespace Intis.SDK

    ''' <summary>
    ''' Class HttpApiConnector
    ''' HTTP API data connector implementation API data connector
    ''' </summary>
    Public Class HttpApiConnector
        Implements IApiConnector

        ''' <summary>
        ''' Getting data from API
        ''' </summary>
        ''' <param name="url">API address</param>
        ''' <param name="allParameters">parameters</param>
        ''' <returns>data as an string</returns>
        Public Function GetContentFromApi(url As String, allParameters As NameValueCollection) As String Implements IApiConnector.GetContentFromApi
            Dim encodeParameters = New NameValueCollection()
            For i = 0 To allParameters.Count - 1
                Dim param = HttpUtility.UrlEncode(allParameters.[Get](i))
                If param IsNot Nothing Then encodeParameters.Add(allParameters.GetKey(i), param)
            Next

            Dim client = New WebClient With {.QueryString = encodeParameters, .Encoding = Encoding.UTF8}
            Dim result = client.DownloadString(url)
            Return result
        End Function

        ''' <summary>
        ''' Getting timestamp from API
        ''' </summary>
        ''' <param name="url">API address</param>
        ''' <returns>timestamp as an string</returns>
        Public Function GetTimestampFromApi(url As String) As String Implements IApiConnector.GetTimestampFromApi
            Dim client = New WebClient With {.Encoding = Encoding.UTF8}
            Dim result = client.DownloadString(url)
            Return result
        End Function
    End Class
End Namespace
