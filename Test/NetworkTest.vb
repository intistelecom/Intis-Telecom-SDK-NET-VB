Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class NetworkTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestGetNetworkByPhone()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim network = client.GetNetworkByPhone(442073238000L)
            Dim title = network.Title
            Assert.IsNotNull(network)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(NetworkException))>
        Public Sub TestGetNetworkByPhoneException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.GetNetworkByPhone(442073238000L)
        End Sub

        Private Function getData() As String
            Return "{""operator"" : ""AT&T""}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
