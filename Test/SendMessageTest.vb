Imports Intis.SDK
Imports Intis.SDK.Entity
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class SendMessageTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestSendMessage()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim phones = {442073238000L, 442073238001L}
            Dim status = client.SendMessage(phones, "smstest", "test").ToArray()
            For Each one In status
                If one.IsOk Then
                    Dim success = CType(one, MessageSendingSuccess)
                    Dim phone = success.Phone
                    Dim messageId = success.MessageId
                    Dim messagesCount = success.MessagesCount
                    Dim cost = success.Cost
                    Dim currency = success.Currency
                Else
                    Dim err = CType(one, MessageSendingError)
                    Dim phone = one.Phone
                    Dim errorCode = err.Code
                    Dim errorMessage = err.Message
                End If
            Next

            Assert.IsNotNull(status)
        End Sub

        <TestMethod>
        Public Sub TestScheduleSendMessage()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim phones = {442073238000L, 442073238001L}
            Dim status = client.SendMessage(phones, "smstest", "test", "2016-07-07 15:30").ToArray()
            For Each one In status
                If one.IsOk Then
                    Dim success = CType(one, MessageSendingSuccess)
                    Dim phone = success.Phone
                    Dim messageId = success.MessageId
                    Dim messagesCount = success.MessagesCount
                    Dim cost = success.Cost
                    Dim currency = success.Currency
                Else
                    Dim err = CType(one, MessageSendingError)
                    Dim phone = one.Phone
                    Dim errorCode = err.Code
                    Dim errorMessage = err.Message
                End If
            Next

            Assert.IsNotNull(status)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(MessageSendingResultException))>
        Public Sub TestSendMessageException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim phones = {442073238000L, 442073238001L}
            client.SendMessage(phones, "smstest", "test")
        End Sub

        Private Function getData() As String
            Return "{""442073238000"":{""error"":""0"",""id_sms"":""4384607771347164730001"",""cost"":1,""count_sms"":1,""sender"":""smstest"",""network"":""Landline"",""ported"":0},""442073238001"":{""error"":31}}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
