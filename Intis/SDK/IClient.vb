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
