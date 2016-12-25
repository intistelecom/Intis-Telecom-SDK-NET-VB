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
