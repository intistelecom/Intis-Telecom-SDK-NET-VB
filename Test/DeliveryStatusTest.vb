Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class DeliveryStatusTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestGetDeliveryStatus()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim messageId = {"4196226820248326060001"}
            Dim status = client.GetDeliveryStatus(messageId)
            For Each one In status
                Dim meassageId = one.MessageId
                Dim messageStatue = one.MessageStatus
                Dim createdAt = one.CreatedAt
            Next

            Assert.IsNotNull(status)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(DeliveryStatusException))>
        Public Sub TestGetDeliveryStatusException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim messageId = {"4196226820248326060001"}
            client.GetDeliveryStatus(messageId)
        End Sub

        Private Function getData() As String
            Return "{""4385937961543210880001"":{""status"":""deliver"", ""time"":""2014-10-05""},""4385937961543210880002"":{""status"":""not_deliver"", ""time"":""2014-10-01""}}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
