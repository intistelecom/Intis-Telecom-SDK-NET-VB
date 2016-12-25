Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class TemplatesTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestGetTemplates()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim templates = client.GetTemplates()
            For Each one In templates
                Dim id = one.Id
                Dim title = one.Title
                Dim template = one.template
                Dim createdAt = one.CreatedAt
            Next

            Assert.IsNotNull(templates)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(TemplateException))>
        Public Sub TestGetTemplatesException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.GetTemplates()
        End Sub

        Private Function getData() As String
            Return "{""25583"":{""name"":""newtemplate"",""template"":""Hello! #first-name# #last-name#! Your amount is #note1#"",""up_time"":""2015-03-31 15:22:50""},""25586"":{""name"":""test1"",""template"":""template for test1"",""up_time"":""2015-07-29 15:37:47""},""25582"":{""name"":""vnb cv"",""template"":""test"",""up_time"":""2015-03-30 17:34:39""}}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
