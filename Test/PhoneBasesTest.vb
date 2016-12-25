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

Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class PhoneBasesTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestGetPhoneBases()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim balance = client.GetPhoneBases()
            For Each one In balance
                Dim baseId = one.BaseId
                Dim title = one.Title
                Dim count = one.Count
                Dim pages = one.Pages
                Dim birthday = one.BirthdayGreetingSettings
                Dim enabled = birthday.Enabled
                Dim originator = birthday.Originator
                Dim daysBefore = birthday.DaysBefore
                Dim timeToSend = birthday.TimeToSend
                Dim useLocalTime = birthday.UseLocalTime
                Dim template = birthday.Template
            Next
        End Sub

        <TestMethod>
        <ExpectedException(GetType(PhoneBasesException))>
        Public Sub TestGetPhoneBasesException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.GetPhoneBases()
        End Sub

        Private Function getData() As String
            Return "{""125480"":{""name"":""989878979"",""time_birth"":""12:00:00"",""day_before"":""0"",""local_time"":""1"",""birth_sender"":"""",""birth_text"":"""",""on_birth"":""0"",""count"":""0"",""pages"":0}," & """125473"":{""name"":""654564"",""time_birth"":""12:00:00"",""day_before"":""0"",""local_time"":""1"",""birth_sender"":"""",""birth_text"":"""",""on_birth"":""0"",""count"":""367"",""pages"":4}}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
