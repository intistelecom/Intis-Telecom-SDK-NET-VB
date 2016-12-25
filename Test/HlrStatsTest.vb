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
    Public Class HlrStatsTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestGetHlrStats()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim hlrStatItem = client.GetHlrStats("2014-07-01", "2014-10-01")
            For Each one In hlrStatItem
                Dim messageId = one.MessageId
                Dim requestId = one.RequestId
                Dim requestTime = one.RequestTime
                Dim totalPrice = one.TotalPrice
                Dim id = one.Id
                Dim imsi = one.Imsi
                Dim destination = one.Destination
                Dim mcc = one.Mcc
                Dim mnc = one.Mnc
                Dim originalCountryCode = one.OriginalCountryCode
                Dim originalCountryName = one.OriginalCountryName
                Dim originalNetworkName = one.OriginalNetworkName
                Dim originalNetworkPrefix = one.OriginalNetworkPrefix
                Dim portedCountryName = one.PortedCountryName
                Dim portedCountryPrefix = one.PortedCountryPrefix
                Dim portedNetworkName = one.PortedNetworkName
                Dim portedNetworkPrefix = one.PortedNetworkPrefix
                Dim pricePerMessage = one.PricePerMessage
                Dim roamingCountryName = one.RoamingCountryName
                Dim roamingCountryPrefix = one.RoamingCountryPrefix
                Dim roamingNetworkName = one.RoamingNetworkName
                Dim roamingNetworkPrefix = one.RoamingNetworkPrefix
                Dim status = one.Status
                Dim isPorted = one.IsPorted
                Dim isInRoaming = one.IsInRoaming
            Next

            Assert.IsNotNull(hlrStatItem)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(HlrStatItemException))>
        Public Sub TestGetHlrStatsException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.GetHlrStats("2014-07-01", "2014-10-01")
        End Sub

        Private Function getData() As String
            Return "{""442073238000"":{""id"":""4133004490987800000001"",""destination"":""442073238000"",""message_id"":""x6ikubibd4y5ljdnttxt"",""IMSI"":""250017224827276"",""stat"":""DELIVRD"",""error"":""0"",""orn"":""Landline"",""pon"":""Landline"",""ron"":""Landline"",""mccmnc"":""25001"",""rcn"":""United Kingdom"",""ppm"":""932"",""onp"":""91788"",""ocn"":""United Kingdom"",""ocp"":""7"",""is_ported"":""false"",""rnp"":""917"",""rcp"":""7"",""is_roaming"":""false"",""pnp"":""442073238000"",""pcn"":""United Kingdom"",""pcp"":""7"",""total_price"":""0.2"",""request_id"":""607a199fb7dc99e68af1196f659c23cf"",""request_time"":""2014-10-14 19:27:29""}," & """442073238001"":{""id"":""4115440762085900000001"",""destination"":""442073238001"",""message_id"":""l9likizqtxau2e5gbbho"",""IMSI"":""250017145699048"",""stat"":""DELIVRD"",""error"":""0"",""orn"":""Landline"",""pon"":""Landline"",""ron"":""Landline"",""mccmnc"":""25001"",""rcn"":""United Kingdom"",""ppm"":""932"",""onp"":""93718"",""ocn"":""United Kingdom"",""ocp"":""7"",""is_ported"":""true"",""rnp"":""91701"",""rcp"":""7"",""is_roaming"":""false"",""pnp"":""442073238001"",""pcn"":""United Kingdom"",""pcp"":""7"",""total_price"":""0.2"",""request_id"":""79cdde57cea85f1cc2728f7c0d48f0bd"",""request_time"":""2014-09-24 11:34:36""}}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
