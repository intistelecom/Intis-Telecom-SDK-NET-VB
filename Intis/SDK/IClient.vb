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

    ''' <summary>
    ''' Interface IClient
    ''' SDK methods
    ''' </summary>
    Interface IClient

        ''' <summary>
        ''' Get balance
        ''' </summary>
        ''' <returns>Balance</returns>
        Function GetBalance() As Balance

        ''' <summary>
        ''' Getting all user lists
        ''' </summary>
        ''' <returns>list of phone base</returns>
        Function GetPhoneBases() As List(Of PhoneBase)

        ''' <summary>
        ''' Getting all user sender names
        ''' </summary>
        ''' <returns>List of senders with its statuses</returns>
        Function GetOriginators() As List(Of Originator)

        ''' <summary>
        ''' Getting subscribers of list
        ''' </summary>
        ''' <param name="baseId">List ID</param>
        ''' <param name="page">Page of list</param>
        ''' <returns>List subscribers</returns>
        Function GetPhoneBaseItems(baseId As Integer, ByVal Optional page As Integer = 1) As List(Of PhoneBaseItem)

        ''' <summary>
        ''' Getting message status
        ''' </summary>
        ''' <param name="messageId">Message ID</param>
        ''' <returns>List of message status</returns>
        Function GetDeliveryStatus(messageId As String()) As List(Of DeliveryStatus)

        ''' <summary>
        ''' SMS sending
        ''' </summary>
        ''' <param name="phone">Phone number</param>
        ''' <param name="originator">Sender name (one of the approved in your account)</param>
        ''' <param name="text">SMS text</param>
        ''' <param name="sendingTime">An optional parameter, it is used when it is necessary to schedule SMS messages. Format YYYY-MM-DD HH:ii</param>
        ''' <returns>Results list</returns>
        Function SendMessage(phone As Int64(), originator As String, text As String, ByVal Optional sendingTime As String = Nothing) As List(Of MessageSendingResult)

        ''' <summary>
        ''' Testing phone number for stop list
        ''' </summary>
        ''' <param name="phone">Phone number</param>
        ''' <returns>Stop list</returns>
        Function CheckStopList(phone As Int64) As StopList

        ''' <summary>
        ''' Adding number to stop list
        ''' </summary>
        ''' <param name="phone">Phone number</param>
        ''' <returns>ID in stop list</returns>
        Function AddToStopList(phone As Int64) As Int64

        ''' <summary>
        ''' Getting user templates
        ''' </summary>
        ''' <returns>List of templates</returns>
        Function GetTemplates() As List(Of Template)

        ''' <summary>
        ''' Adding user template
        ''' </summary>
        ''' <param name="title">Template name</param>
        ''' <param name="template">Text of template</param>
        ''' <returns>ID in the template list</returns>
        Function AddTemplate(title As String, template As String) As Int64

        ''' <summary>
        ''' Edit user template
        ''' </summary>
        ''' <param name="title">Template name</param>
        ''' <param name="template">Text of template</param>
        ''' <returns>ID in the template list</returns>
        Function EditTemplate(title As String, template As String) As Int64

        ''' <summary>
        ''' Remove user template
        ''' </summary>
        ''' <param name="name">Template name</param>
        ''' <returns>Result</returns>
        Function RemoveTemplate(name As String) As RemoveTemplateResponse

        ''' <summary>
        ''' Getting statistics for the certain month
        ''' </summary>
        ''' <param name="year">Year</param>
        ''' <param name="month">Month</param>
        ''' <returns>Statistics</returns>
        Function GetDailyStatsByMonth(year As Integer, month As Integer) As List(Of DailyStats)

        ''' <summary>
        ''' Sending HLR request for number
        ''' </summary>
        ''' <param name="phone">Phone number</param>
        ''' <returns>Results list</returns>
        Function MakeHlrRequest(phone As Int64()) As List(Of HlrResponse)

        ''' <summary>
        ''' Getting statuses of HLR request
        ''' </summary>
        ''' <param name="from">Initial date in the format YYYY-MM-DD</param>
        ''' <param name="to">Final date in the format YYYY-MM-DD</param>
        ''' <returns>statuses</returns>
        Function GetHlrStats(from As String, [to] As String) As List(Of HlrStatItem)

        ''' <summary>
        ''' Getting the operator of subscriber phone number
        ''' </summary>
        ''' <param name="phone">Phone number</param>
        ''' <returns>Operator</returns>
        Function GetNetworkByPhone(phone As Int64) As Network

        ''' <summary>
        ''' Getting incoming messages of certain date
        ''' </summary>
        ''' <param name="dt">Date in the format YYYY-MM-DD</param>
        ''' <returns>List of incoming messages</returns>
        Function GetIncomingMessages(dt As String) As List(Of IncomingMessage)

        ''' <summary>
        ''' Getting incoming messages for the period
        ''' </summary>
        ''' <param name="from">Initial date in the format YYYY-MM-DD HH:II:SS</param>
        ''' <param name="to">Finel date in the format YYYY-MM-DD HH:II:SS</param>
        ''' <returns>List of incoming messages</returns>
        Function GetIncomingMessages(from As String, [to] As String) As List(Of IncomingMessage)

    End Interface
End Namespace
