﻿Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class CheckStopListTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestCheckStopList()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim list = client.CheckStopList(442073238000L)
            Dim id = list.Id
            Dim timeAddedAt = list.TimeAddedAt
            Dim description = list.Description
            Assert.IsNotNull(list)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(StopListException))>
        Public Sub TestCheckStopListException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.CheckStopList(442073238000L)
        End Sub

        Private Function getData() As String
            Return "{""4494794"":{""time_in"":""2015-07-31 22:55:00"",""description"":""test""}}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
