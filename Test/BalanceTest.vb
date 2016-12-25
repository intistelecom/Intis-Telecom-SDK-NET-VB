Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class BalanceTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestGetBalabce()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim balance = client.GetBalance()
            Dim amount = balance.Amount
            Dim currency = balance.Currency
            Assert.IsNotNull(balance)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(BalanceException))>
        Public Sub TestGetBalabceException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.GetBalance()
        End Sub

        Private Function getData() As String
            Return "{""money"":4, ""currency"":""GBP""}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
