' MIT License

' Copyright (c) 2016 Intis Telecom

' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:

' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.

' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.

Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class DailyStatsTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestGetDailyStatsByMonth()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim stats = client.GetDailyStatsByMonth(2014, 10)
            For Each one In stats
                Dim day = one.Day
                Dim s = one.Stats
                For Each i In s
                    Dim cost = i.Cost
                    Dim count = i.Count
                    Dim currency = i.Currency
                    Dim state = i.State
                Next
            Next

            Assert.IsNotNull(stats)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(DailyStatsException))>
        Public Sub TestGetDailyStatsByMonthException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.GetDailyStatsByMonth(2014, 10)
        End Sub

        Private Function getData() As String
            Return "[{""date"":""2014-10-02"",""stats"":[{""status"":""deliver"",""cost"":""1.000"",""parts"":""2""},{""status"":""not_deliver"",""cost"":""0.500"",""parts"":""1""}]}," & "{""date"":""2014-10-13"",""stats"":[{""status"":""deliver"",""cost"":""161.850"",""parts"":""358""},{""status"":""expired"",""cost"":""1.650"",""parts"":""4""},{""status"":""not_deliver"",""cost"":""87.700"",""parts"":""198""}]}," & "{""date"":""2014-10-31"",""stats"":[{""status"":""not_deliver"",""cost"":""211.200"",""parts"":""459""},{""status"":""deliver"",""cost"":""327.950"",""parts"":""712""}]}]"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
