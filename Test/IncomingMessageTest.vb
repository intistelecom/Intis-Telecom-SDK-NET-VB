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
    Public Class IncomingMessageTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestGetIncomingMessages()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim messages = client.GetIncomingMessages("2014-10-27")
            For Each one In messages
                Dim messageId = one.MessageId
                Dim originator = one.Originator
                Dim prefix = one.Prefix
                Dim receivedAt = one.ReceivedAt
                Dim text = one.Text
                Dim destination = one.Destination
            Next

            Assert.IsNotNull(messages)
        End Sub

        <TestMethod>
        Public Sub TestGetIncomingMessagesForPeriod()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim messages = client.GetIncomingMessages("2014-10-27", "2014-10-30")
            For Each one In messages
                Dim messageId = one.MessageId
                Dim originator = one.Originator
                Dim prefix = one.Prefix
                Dim receivedAt = one.ReceivedAt
                Dim text = one.Text
                Dim destination = one.Destination
            Next

            Assert.IsNotNull(messages)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(IncomingMessageException))>
        Public Sub TestGetIncomingMessagesException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.GetIncomingMessages("2014-10-27")
        End Sub

        Private Function getData() As String
            Return "{""75396"":{""date"":""2015-04-01 14:01:24"",""sender"":""442073238000"",""prefix"":"""",""text"":""test"",""phone"":""5163251632""},""75397"":{""date"":""2015-04-01 22:31:22"",""sender"":""442073238001"",""prefix"":"""",""text"":""test 1"",""phone"":""5163251632""},""75398"":{""date"":""2015-04-01 22:37:13"",""sender"":""442073238002"",""prefix"":"""",""text"":""test 2"",""phone"":""5163251632""},""75399"":{""date"":""2015-04-01 22:39:33"",""sender"":""442073238003"",""prefix"":"""",""text"":""test 3"",""phone"":""5163251632""}}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
