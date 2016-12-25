Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class HlrResponseTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestMakeHlrRequest()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim phones = {442073238000L, 442073238001L}
            Dim hlrResponse = client.MakeHlrRequest(phones)
            For Each one In hlrResponse
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

            Assert.IsNotNull(hlrResponse)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(HlrResponseException))>
        Public Sub TestMakeHlrRequestException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim phones = {442073238000L, 442073238001L}
            client.MakeHlrRequest(phones)
        End Sub

        Private Function getData() As String
            Return "[{""id"":""4133004490987800000001"",""destination"":""442073238000"",""message_id"":""x6ikubibd4y5ljdnttxt"",""IMSI"":""250017224827276"",""stat"":""DELIVRD"",""error"":""0"",""orn"":""Landline"",""pon"":""Landline"",""ron"":""Landline"",""mccmnc"":""25001"",""rcn"":""United Kingdom"",""ppm"":""932"",""onp"":""91788"",""ocn"":""United Kingdom"",""ocp"":""7"",""is_ported"":""false"",""rnp"":""917"",""rcp"":""7"",""is_roaming"":""false"",""pnp"":""442073238000"",""pcn"":""United Kingdom"",""pcp"":""7"",""total_price"":""0.2"",""request_id"":""607a199fb7dc99e68af1196f659c23cf"",""request_time"":""2014-10-14 19:27:29""}," & "{""id"":""4115440762085900000001"",""destination"":""442073238001"",""message_id"":""l9likizqtxau2e5gbbho"",""IMSI"":""250017145699048"",""stat"":""DELIVRD"",""error"":""0"",""orn"":""Landline"",""pon"":""Landline"",""ron"":""Landline"",""mccmnc"":""25001"",""rcn"":""United Kingdom"",""ppm"":""932"",""onp"":""93718"",""ocn"":""United Kingdom"",""ocp"":""7"",""is_ported"":""true"",""rnp"":""91701"",""rcp"":""7"",""is_roaming"":""false"",""pnp"":""442073238001"",""pcn"":""United Kingdom"",""pcp"":""7"",""total_price"":""0.2"",""request_id"":""79cdde57cea85f1cc2728f7c0d48f0bd"",""request_time"":""2014-09-24 11:34:36""}]"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
