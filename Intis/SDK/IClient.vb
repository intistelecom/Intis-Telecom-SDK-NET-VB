Imports Intis.SDK.Entity

Namespace Intis.SDK

    Interface IClient

        Function GetBalance() As Balance

        Function GetPhoneBases() As List(Of PhoneBase)

        Function GetOriginators() As List(Of Originator)

        Function GetPhoneBaseItems(ByVal baseId As Integer, ByVal Optional page As Integer = 1) As List(Of PhoneBaseItem)

        Function GetDeliveryStatus(ByVal messageId As String()) As List(Of DeliveryStatus)

        Function SendMessage(ByVal phone As Int64(), ByVal originator As String, ByVal text As String, ByVal Optional sendingTime As String = Nothing) As List(Of MessageSendingResult)

        Function CheckStopList(ByVal phone As Int64) As StopList

        Function AddToStopList(ByVal phone As Int64) As Int64

        Function GetTemplates() As List(Of Template)

        Function AddTemplate(ByVal title As String, ByVal template As String) As Int64

        Function EditTemplate(ByVal title As String, ByVal template As String) As Int64

        Function RemoveTemplate(ByVal name As String) As RemoveTemplateResponse

        Function GetDailyStatsByMonth(ByVal year As Integer, ByVal month As Integer) As List(Of DailyStats)

        Function MakeHlrRequest(ByVal phone As Int64()) As List(Of HlrResponse)

        Function GetHlrStats(ByVal from As String, ByVal [to] As String) As List(Of HlrStatItem)

        Function GetNetworkByPhone(ByVal phone As Int64) As Network

        Function GetIncomingMessages(ByVal dt As String) As List(Of IncomingMessage)

        Function GetIncomingMessages(ByVal from As String, ByVal [to] As String) As List(Of IncomingMessage)

    End Interface
End Namespace
