Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class RemoteTemplateTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestRemoveTemplate()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim respomse = client.RemoveTemplate("test1")
            Dim result = respomse.Result
            Assert.IsNotNull(respomse)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(RemoveTemplateException))>
        Public Sub TestRemoveTemplateException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.RemoveTemplate("test1")
        End Sub

        Private Function getData() As String
            Return "{""result"" : ""deleted""}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
