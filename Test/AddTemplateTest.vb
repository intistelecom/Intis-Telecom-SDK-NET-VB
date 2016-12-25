Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class AddTemplateTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestAddTemplate()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim template = client.AddTemplate("test", "this is test")
            Assert.IsNotNull(client)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(AddTemplateException))>
        Public Sub TestAddTemplateException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.AddTemplate("test", "this is test")
        End Sub

        Private Function getData() As String
            Return "{""id"":1}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
