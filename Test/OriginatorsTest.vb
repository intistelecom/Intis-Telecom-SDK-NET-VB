Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class OriginatorsTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestGetOriginators()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim originators = client.GetOriginators()
            For Each one In originators
                Dim name = one.Name
                Dim state = one.State
            Next

            Assert.IsNotNull(originators)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(OriginatorException))>
        Public Sub TestGetOriginatorsException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.GetOriginators()
        End Sub

        Private Function getData() As String
            Return "{""smstest"":""completed"",""Stok&Sekond"":""completed"",""chmvm"":""completed"",""rsoTEST"":""completed""}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
