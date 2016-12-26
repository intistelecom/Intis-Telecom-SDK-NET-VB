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
Imports Intis.SDK.Exceptions
Imports System.Collections.Specialized
Imports System.Runtime.Serialization.Json
Imports System.Web.Script.Serialization

Namespace Intis.SDK

    Public Class IntisClient
        Inherits AClient
        Implements IClient

        Public Sub New(ByVal login As String, ByVal apiKey As String, ByVal apiHost As String)
            MyBase.New(Nothing)

            MyClass.Login = login
            MyClass.ApiKey = apiKey
            MyClass.ApiHost = apiHost
        End Sub

        Public Sub New(ByVal login As String, ByVal apiKey As String, ByVal apiHost As String, ByVal apiConnector As IApiConnector)
            MyBase.New(apiConnector)

            MyClass.Login = login
            MyClass.ApiKey = apiKey
            MyClass.ApiHost = apiHost
        End Sub

        Public Function GetBalance() As Balance Implements IClient.GetBalance
            Dim parameters = New NameValueCollection()
            Try
                Dim content = GetStreamContent("balance", parameters)
                Dim serializer = New DataContractJsonSerializer(GetType(Balance))
                Dim balance = TryCast(serializer.ReadObject(content), Balance)
                Return balance
            Catch ex As Exception
                Throw New BalanceException(parameters, ex)
            End Try
        End Function

        Public Function GetPhoneBases() As List(Of PhoneBase) Implements IClient.GetPhoneBases
            Dim parameters = New NameValueCollection()
            Try
                Dim content = GetStreamContent("base", parameters)
                Dim bases = New List(Of PhoneBase)()
                Dim settings = New DataContractJsonSerializerSettings With {.UseSimpleDictionaryFormat = True}
                Dim serializer = New DataContractJsonSerializer(GetType(Dictionary(Of Int64, PhoneBase)), settings)
                Dim phoneBases = TryCast(serializer.ReadObject(content), Dictionary(Of Int64, PhoneBase))
                If phoneBases Is Nothing Then Return bases
                For Each one In phoneBases
                    Dim oneBase = one.Value
                    oneBase.BaseId = one.Key
                    bases.Add(oneBase)
                Next

                Return bases
            Catch ex As Exception
                Throw New PhoneBasesException(parameters, ex)
            End Try
        End Function

        Public Function GetOriginators() As List(Of Originator) Implements IClient.GetOriginators
            Dim parameters = New NameValueCollection()
            Try
                Dim content = GetContent("senders", parameters)
                Dim originators = New List(Of Originator)()
                Dim serializer = New JavaScriptSerializer()
                Dim list = serializer.Deserialize(Of Dictionary(Of String, String))(content)
                originators.AddRange(list.[Select](Function(one) New Originator(one.Key, one.Value)))
                Return originators
            Catch ex As Exception
                Throw New OriginatorException(parameters, ex)
            End Try
        End Function

        Public Function GetPhoneBaseItems(ByVal baseId As Integer, ByVal Optional page As Integer = 1) As List(Of PhoneBaseItem) Implements IClient.GetPhoneBaseItems
            Dim parameters = New NameValueCollection() From {{"base", baseId.ToString()}, {"page", page.ToString()}}
            Try
                Dim content = GetStreamContent("phone", parameters)
                Dim phoneBaseItem = New List(Of PhoneBaseItem)()
                Dim settings = New DataContractJsonSerializerSettings With {.UseSimpleDictionaryFormat = True}
                Dim serializer = New DataContractJsonSerializer(GetType(Dictionary(Of Int64, PhoneBaseItem)), settings)
                Dim items = TryCast(serializer.ReadObject(content), Dictionary(Of Int64, PhoneBaseItem))
                If items Is Nothing Then Return phoneBaseItem
                For Each one In items
                    Dim item = one.Value
                    item.Phone = one.Key
                    phoneBaseItem.Add(item)
                Next

                Return phoneBaseItem
            Catch ex As Exception
                Throw New PhoneBaseItemException(parameters, ex)
            End Try
        End Function

        Public Function GetDeliveryStatus(ByVal messageId As String()) As List(Of DeliveryStatus) Implements IClient.GetDeliveryStatus
            Dim parameters = New NameValueCollection() From {{"state", String.Join(",", messageId)}}
            Try
                Dim content = GetStreamContent("status", parameters)
                Dim deliveryStatus = New List(Of DeliveryStatus)()
                Dim settings = New DataContractJsonSerializerSettings With {.UseSimpleDictionaryFormat = True}
                Dim serializer = New DataContractJsonSerializer(GetType(Dictionary(Of String, DeliveryStatus)), settings)
                Dim items = TryCast(serializer.ReadObject(content), Dictionary(Of String, DeliveryStatus))
                If items Is Nothing Then Return deliveryStatus
                For Each one In items
                    Dim item = one.Value
                    item.MessageId = one.Key
                    deliveryStatus.Add(item)
                Next

                Return deliveryStatus
            Catch ex As Exception
                Throw New DeliveryStatusException(parameters, ex)
            End Try
        End Function

        Public Function SendMessage(ByVal phone As Int64(), ByVal originator As String, ByVal text As String, ByVal Optional sendingTime As String = Nothing) As List(Of MessageSendingResult) Implements IClient.SendMessage
            Dim parameters = New NameValueCollection() From {{"phone", String.Join(",", phone.[Select](Function(p) p.ToString()))}, {"sender", originator}, {"text", text}}
            If sendingTime IsNot Nothing Then
                parameters.Add("sendingTime", sendingTime)
            End If

            Try
                Dim content = GetStreamContent("send", parameters)
                Dim settings = New DataContractJsonSerializerSettings With {.UseSimpleDictionaryFormat = True}
                Dim messages = New List(Of MessageSendingResult)()
                Dim serializer = New DataContractJsonSerializer(GetType(Dictionary(Of Int64, MessageSending)()), settings)
                Dim items = TryCast(serializer.ReadObject(content), Dictionary(Of Int64, MessageSending)())
                If items Is Nothing Then Return messages
                For Each one In items
                    Dim item = one.First().Value
                    item.Phone = one.First().Key
                    If item.[Error] = 0 Then
                        Dim success = New MessageSendingSuccess With {.Phone = item.Phone, .MessageId = item.MessageId, .MessagesCount = item.MessagesCount, .Cost = item.Cost, .Currency = item.Currency}
                        messages.Add(success)
                    Else
                        Dim err = New MessageSendingError With {.Phone = item.Phone, .Code = item.[Error]}
                        messages.Add([err])
                    End If
                Next

                Return messages
            Catch ex As Exception
                Throw New MessageSendingResultException(parameters, ex)
            End Try
        End Function

        Public Function CheckStopList(ByVal phone As Int64) As StopList Implements IClient.CheckStopList
            Dim parameters = New NameValueCollection() From {{"phone", phone.ToString()}}
            Try
                Dim content = GetStreamContent("find_on_stop", parameters)
                Dim settings = New DataContractJsonSerializerSettings With {.UseSimpleDictionaryFormat = True}
                Dim serializer = New DataContractJsonSerializer(GetType(Dictionary(Of Int64, StopList)), settings)
                Dim check = TryCast(serializer.ReadObject(content), Dictionary(Of Int64, StopList))
                If check Is Nothing OrElse check.Count <= 0 Then Return Nothing
                Dim one = check.First()
                Dim stopList = one.Value
                stopList.Id = one.Key
                Return stopList
            Catch ex As Exception
                Throw New StopListException(parameters, ex)
            End Try
        End Function

        Public Function AddToStopList(ByVal phone As Int64) As Int64 Implements IClient.AddToStopList
            Dim parameters = New NameValueCollection() From {{"phone", phone.ToString()}}
            Try
                Dim content = GetContent("add2stop", parameters)
                Dim serializer = New JavaScriptSerializer()
                Dim list = serializer.Deserialize(Of Dictionary(Of String, Int64))(content)
                Return list.First().Value
            Catch ex As Exception
                Throw New AddToStopListException(parameters, ex)
            End Try
        End Function

        Public Function GetTemplates() As List(Of Template) Implements IClient.GetTemplates
            Dim parameters = New NameValueCollection()
            Try
                Dim content = GetStreamContent("template", parameters)
                Dim settings = New DataContractJsonSerializerSettings With {.UseSimpleDictionaryFormat = True}
                Dim serializer = New DataContractJsonSerializer(GetType(Dictionary(Of Int64, Template)), settings)
                Dim items = TryCast(serializer.ReadObject(content), Dictionary(Of Int64, Template))
                Dim list = New List(Of Template)()
                If items Is Nothing Then Return list
                For Each one In items
                    Dim item = one.Value
                    item.Id = one.Key
                    list.Add(item)
                Next

                Return list
            Catch ex As Exception
                Throw New TemplateException(parameters, ex)
            End Try
        End Function

        Public Function AddTemplate(ByVal title As String, ByVal template As String) As Int64 Implements IClient.AddTemplate
            Dim parameters = New NameValueCollection() From {{"name", title}, {"text", template}}
            Try
                Dim content = GetContent("add_template", parameters)
                Dim serializer = New JavaScriptSerializer()
                Dim list = serializer.Deserialize(Of Dictionary(Of String, Int64))(content)
                Return list.First().Value
            Catch ex As Exception
                Throw New AddTemplateException(parameters, ex)
            End Try
        End Function

        Public Function EditTemplate(ByVal title As String, ByVal template As String) As Int64 Implements IClient.EditTemplate
            Dim parameters = New NameValueCollection() From {{"name", title}, {"text", template}, {"override", "1"}}
            Try
                Dim content = GetContent("add_template", parameters)
                Dim serializer = New JavaScriptSerializer()
                Dim list = serializer.Deserialize(Of Dictionary(Of String, Int64))(content)
                Return list.First().Value
            Catch ex As Exception
                Throw New AddTemplateException(parameters, ex)
            End Try
        End Function

        Public Function RemoveTemplate(ByVal name As String) As RemoveTemplateResponse Implements IClient.RemoveTemplate
            Dim parameters = New NameValueCollection() From {{"name", name}}
            Try
                Dim content = GetStreamContent("del_template", parameters)
                Dim serializer = New DataContractJsonSerializer(GetType(RemoveTemplateResponse))
                Dim result = TryCast(serializer.ReadObject(content), RemoveTemplateResponse)
                Return result
            Catch ex As Exception
                Throw New RemoveTemplateException(parameters, ex)
            End Try
        End Function

        Public Function GetDailyStatsByMonth(ByVal year As Integer, ByVal month As Integer) As List(Of DailyStats) Implements IClient.GetDailyStatsByMonth
            Dim dt = New DateTime(year, month, 1, 0, 0, 0)
            Dim parameters = New NameValueCollection() From {{"month", dt.ToString("yyyy-MM")}}
            Try
                Dim content = GetStreamContent("stat_by_month", parameters)
                Dim settings = New DataContractJsonSerializerSettings With {.UseSimpleDictionaryFormat = True}
                Dim serializer = New DataContractJsonSerializer(GetType(List(Of DailyStats)), settings)
                Dim items = TryCast(serializer.ReadObject(content), List(Of DailyStats))
                Return items
            Catch ex As Exception
                Throw New DailyStatsException(parameters, ex)
            End Try
        End Function

        Public Function MakeHlrRequest(ByVal phone As Int64()) As List(Of HlrResponse) Implements IClient.MakeHlrRequest
            Dim parameters = New NameValueCollection() From {{"phone", String.Join(",", phone.[Select](Function(p) p.ToString()))}}
            Try
                Dim content = GetStreamContent("hlr", parameters)
                Dim settings = New DataContractJsonSerializerSettings With {.UseSimpleDictionaryFormat = True}
                Dim serializer = New DataContractJsonSerializer(GetType(List(Of HlrResponse)), settings)
                Dim items = TryCast(serializer.ReadObject(content), List(Of HlrResponse))
                Return items
            Catch ex As Exception
                Throw New HlrResponseException(parameters, ex)
            End Try
        End Function

        Public Function GetHlrStats(ByVal from As String, ByVal [to] As String) As List(Of HlrStatItem) Implements IClient.GetHlrStats
            Dim parameters = New NameValueCollection() From {{"from", from}, {"to", [to]}}
            Try
                Dim content = GetStreamContent("hlr_stat", parameters)
                Dim settings = New DataContractJsonSerializerSettings With {.UseSimpleDictionaryFormat = True}
                Dim list = New List(Of HlrStatItem)()
                Dim serializer = New DataContractJsonSerializer(GetType(Dictionary(Of Int64, HlrStatItem)), settings)
                Dim items = TryCast(serializer.ReadObject(content), Dictionary(Of Int64, HlrStatItem))
                If items Is Nothing Then Return list
                list.AddRange(items.[Select](Function(one) one.Value))
                Return list
            Catch ex As Exception
                Throw New HlrStatItemException(parameters, ex)
            End Try
        End Function

        Public Function GetNetworkByPhone(ByVal phone As Int64) As Network Implements IClient.GetNetworkByPhone
            Dim parameters = New NameValueCollection() From {{"phone", phone.ToString()}}
            Try
                Dim content = GetStreamContent("operator", parameters)
                Dim serializer = New DataContractJsonSerializer(GetType(Network))
                Dim network = TryCast(serializer.ReadObject(content), Network)
                Return network
            Catch ex As Exception
                Throw New NetworkException(parameters, ex)
            End Try
        End Function

        Public Function GetIncomingMessages(ByVal dt As String) As List(Of IncomingMessage) Implements IClient.GetIncomingMessages
            Dim parameters = New NameValueCollection() From {{"date", dt}}
            Try
                Dim list = SendQueryIncomingMessages(parameters)
                Return list
            Catch ex As Exception
                Throw New IncomingMessageException(parameters, ex)
            End Try
        End Function

        Public Function GetIncomingMessages(ByVal from As String, ByVal [to] As String) As List(Of IncomingMessage) Implements IClient.GetIncomingMessages
            Dim parameters = New NameValueCollection() From {{"from", from}, {"to", [to]}}
            Try
                Dim list = SendQueryIncomingMessages(parameters)
                Return list
            Catch ex As Exception
                Throw New IncomingMessageException(parameters, ex)
            End Try
        End Function

        Private Function SendQueryIncomingMessages(ByVal parameters As NameValueCollection) As List(Of IncomingMessage)
            Dim content = GetStreamContent("incoming", parameters)
            Dim settings = New DataContractJsonSerializerSettings With {.UseSimpleDictionaryFormat = True}
            Dim list = New List(Of IncomingMessage)()
            Dim serializer = New DataContractJsonSerializer(GetType(Dictionary(Of String, IncomingMessage)), settings)
            Dim items = TryCast(serializer.ReadObject(content), Dictionary(Of String, IncomingMessage))
            If items Is Nothing Then Return list
            For Each one In items
                Dim message = one.Value
                message.MessageId = one.Key
                list.Add(one.Value)
            Next

            Return list
        End Function
    End Class
End Namespace
